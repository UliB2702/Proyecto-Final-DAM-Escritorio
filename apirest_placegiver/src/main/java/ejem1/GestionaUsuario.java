package ejem1;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;

import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;

@Path("/usuarios")
public class GestionaUsuario {

    private static final String URL = "jdbc:mariadb://localhost:3306/placegiver";
    private static final String USER = "root";
    private static final String PASS = "";
    private static PreparedStatement ps = null;

    public static void main(String[] args) {
    try {
        Connection con = DriverManager.getConnection(
            "jdbc:mariadb://localhost:3306/placegiver",
            "root",
            ""
        );
        System.out.println("Conectado correctamente");
    } catch (Exception e) {
        e.printStackTrace();
    }
}

    
    @GET
    @Produces({MediaType.APPLICATION_JSON})
    public Response getUsuario(@QueryParam("nombre") String nombre) {
        Usuario usuario = null;
        try {
            Class.forName("org.mariadb.jdbc.Driver");
            String sql = "Select * from usuarios WHERE nombre = ?";
            try (Connection conexion = DriverManager.getConnection(URL, USER, PASS)) {
                ps = conexion.prepareStatement(sql);
                ps.setString(1, nombre);
                ResultSet rs = ps.executeQuery();
                if (rs.next()) {
                    usuario = new Usuario(rs.getString("nombre"), rs.getString("descripcion"), rs.getString("email"), rs.getString("password"),
                            (rs.getDate("fechaCreacion").toString()));
                }
                return Response.ok(usuario).build();
            } catch (Exception e) {
                e.printStackTrace();
                return Response.status(Response.Status.INTERNAL_SERVER_ERROR)
                        .entity(e.getMessage())
                        .build();
            }
        } catch (ClassNotFoundException e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).entity("No encuentra el driver").build();
        }
    }
    
    
    
    @GET
    @Path("/login")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getUsuario(@QueryParam("nombre") String nombre, @QueryParam("pass") String password) {
        Usuario usuario = null;
        try {
            Class.forName("org.mariadb.jdbc.Driver");
            String sql = "Select * from usuarios WHERE nombre = ? AND password = ?";
            try (Connection conexion = DriverManager.getConnection(URL, USER, PASS)) {
                ps = conexion.prepareStatement(sql);
                ps.setString(1, nombre);
                ps.setString(2, password);
                ResultSet rs = ps.executeQuery();
                while (rs.next()) {
                    usuario = (new Usuario(rs.getString("nombre"), rs.getString("descripcion"), rs.getString("email"), rs.getString("password"), rs.getDate("fechaCreacion").toString()));
                }
                return Response.ok(usuario).build();
            } catch (Exception e) {
                return Response.status(Response.Status.INTERNAL_SERVER_ERROR).entity("No encuentra el Driver").build();
            }
        } catch (ClassNotFoundException e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).entity("No encuentra el driver").build();
        }
    }

    @POST
    @Path("/registro")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response postUsuario(Usuario u){
        try {
            Class.forName("org.mariadb.jdbc.Driver");
            String sql = "INSERT INTO usuarios (nombre, descripcion, email, password, fechaCreacion) VALUES (?,?,?,?,CURRENT_TIMESTAMP)";
            try (Connection conexion = DriverManager.getConnection(URL, USER, PASS); Statement st = conexion.createStatement();) {
                ps = conexion.prepareStatement(sql);
                ps.setString(1, u.nombre);
                ps.setString(2, u.descripcion);
                ps.setString(3, u.email);
                ps.setString(4, u.password);
                int num = ps.executeUpdate();
                return Response.ok("{\"success\": true, \"filas\": " + num + "}").build();
            } catch (Exception e) {
                System.out.println(e.getLocalizedMessage());
                return Response.status(Response.Status.INTERNAL_SERVER_ERROR)
                .entity("{\"success\": false, \"message\": \"Error en BD\"}")
                .build();
            }
        } catch (ClassNotFoundException e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR)
            .entity("{\"success\": false, \"message\": \"Driver no encontrado\"}")
            .build();
        }
    }
    
    @PUT
    @Path("/actualizar")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response updateUsuario(Usuario u){
        try {
            Class.forName("org.mariadb.jdbc.Driver");
            String sql = "UPDATE usuarios SET descripcion = ?, email = ?, password = ? WHERE nombre = ?";
            try (Connection conexion = DriverManager.getConnection(URL, USER, PASS); Statement st = conexion.createStatement();) {
                ps = conexion.prepareStatement(sql);
                ps.setString(1, u.descripcion);
                ps.setString(2, u.email);
                ps.setString(3, u.password);
                ps.setString(4, u.nombre);
                int num = ps.executeUpdate();
                return Response.ok("{\"success\": true, \"filas\": " + num + "}").build();
            } catch (Exception e) {
                System.out.println(e.getLocalizedMessage());
                return Response.status(Response.Status.INTERNAL_SERVER_ERROR)
                .entity("{\"success\": false, \"message\": \"Error en BD\"}")
                .build();
            }
        } catch (ClassNotFoundException e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR)
            .entity("{\"success\": false, \"message\": \"Driver no encontrado\"}")
            .build();
        }
    }

} 
