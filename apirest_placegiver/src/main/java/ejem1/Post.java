package ejem1;

import java.io.Serializable;

import jakarta.xml.bind.annotation.XmlRootElement;


@XmlRootElement
public class Post implements Serializable {
    int id;
    String texto;
    String fechaPublicacion;
    String usuario;
    int idCategoria;

    public Post(){
        
    }

    public Post( int id, String texto, String fechaPublicacion, String usuario, int idCategoria) {
        this.fechaPublicacion = fechaPublicacion;
        this.id = id;
        this.idCategoria = idCategoria;
        this.texto = texto;
        this.usuario = usuario;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public String getFechaPublicacion() {
        return fechaPublicacion;
    }

    public void setFechaPublicacion(String fechaPublicacion) {
        this.fechaPublicacion = fechaPublicacion;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public int getIdCategoria() {
        return idCategoria;
    }

    public void setIdCategoria(int idCategoria) {
        this.idCategoria = idCategoria;
    }


}
