using ComponentesRedSocial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DisenoEscritorio
{
    /// <summary>
    /// Form where appears an user's information based on the given name
    /// </summary>
    public partial class Perfil : Form
    {
        private HttpClient client;
        private string nombreUsuarioActual = "";
        private Usuario usuarioActual = new Usuario();
        private string nombreUsuarioLogeado = "";
        Usuario usuarioLogeado = new Usuario();

        /// <summary>
        /// Initializes the Perfil form. It also calls the CargarSesion function to check the current user's log
        /// </summary>
        /// <param name="usuario">Name of the user that wants to be shown</param>
        public Perfil(string usuario)
        {
            InitializeComponent();
            this.cbCategoria.SelectedIndex = 2;
            client = new HttpClient();
            nombreUsuarioActual = usuario;
            CargarSesion();

        }

        /// <summary>
        /// Opens the log.txt and deserializes it as an Usuario object for the current logged user. 
        /// If the file's format is wrong, it sets the information as empty
        /// </summary>
        private void CargarSesion()
        {
            string json = "";
            try
            {
                json = File.ReadAllText("../../Resources/log.json");
                usuarioLogeado = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                usuarioLogeado = new Usuario();
            }
        }

        /// <summary>
        /// Calls the Api to search for current profile user's lastest posts
        /// </summary>
        /// <returns>A list of Post objects with lastest posts from a user</returns>
        private async Task<List<Post>> PostsDeUsuario()
        {
            try
            {
                List<Post> posts;
                string url = "http://localhost:8080/apirest_placegiver/rest/posts/"+nombreUsuarioActual;
                client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                posts = JsonSerializer.Deserialize<List<Post>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return posts ?? new List<Post>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al cargar posts");
                return new List<Post>();
            }
        }

        /// <summary>
        /// Giving the name of a user, searches all the data from them and returns it
        /// </summary>
        /// <returns>An Usuario object with the result data from the api. If it happens to be null, it returns an object with all the data empty</returns>
        private async Task<Usuario> CargarPerfil()
        {
            Usuario u;
            string url = "http://localhost:8080/apirest_placegiver/rest/usuarios?nombre=" + nombreUsuarioActual;
            client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            u = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return u ?? new Usuario();
        }

        /// <summary>
        /// Giving the name and the password of a user, confirms if there is such user in the database with matching data
        /// </summary>
        /// <param name="nombre">Name of the user that wants to be searched</param>
        /// <param name="pass">Password of the user that wants to be searched</param>
        /// <returns>Returns true if the user was found or false if it wasn't</returns>
        private async Task<bool> ComprobarUsuario(string nombre, string pass)
        {
            try
            {
                string url = $"http://localhost:8080/apirest_placegiver/rest/usuarios/login?nombre={Uri.EscapeDataString(nombre)}&pass={Uri.EscapeDataString(pass)}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json); 

                Usuario u = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return u != null && !string.IsNullOrEmpty(u.Nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Event that occurs when Perfil form loads. It loads the profile's data if the it is correct and the current logged user information
        /// Also, makes visible or not certain components if the verified logged user and the user of the current profile are the same or not
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            usuarioActual = await CargarPerfil();
            if (usuarioActual.Nombre == null || usuarioActual.Nombre == "" || !(await ComprobarUsuario(usuarioActual.Nombre, usuarioActual.Password)))
            {
                MessageBox.Show("Hubo un error al abrir el formulario. El usuario que intenta buscar no existe", "Error de perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            lblNombre.Text = usuarioActual.Nombre;
            lblDescripcion.Text = usuarioActual.Descripcion;
            if(lblDescripcion.Text == "")
            {
                lblDescripcion.Visible = false;
            }

            await CargarPosts();
            

            if (await ComprobarUsuario(usuarioLogeado.Nombre, usuarioLogeado.Password) && usuarioActual.Nombre == usuarioLogeado.Nombre)
            {
                this.btnEditar.Visible = true;
                this.btnSeguir.Visible = false;
                this.txtPublicar.Visible = true;
                this.btnPublicar.Visible = true;
                this.cbCategoria.Visible = true;
            }
            else {
                this.btnEditar.Visible = false;
                this.btnSeguir.Visible = true;
                this.txtPublicar.Visible = false;
                this.btnPublicar.Visible = false;
                this.cbCategoria.Visible = false;
            }
        }

        /// <summary>
        /// Function that reloads all the information of the profile.
        /// It combines the verification of the user profile and current logged user.
        /// </summary>
        public async void RecargarDatos()
        {
            usuarioActual = await CargarPerfil();
            if (usuarioActual.Nombre == null || usuarioActual.Nombre == "" || !(await ComprobarUsuario(usuarioActual.Nombre, usuarioActual.Password)))
            {
                MessageBox.Show("Hubo un error al abrir el formulario. El usuario que intenta buscar no existe", "Error de perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            lblNombre.Text = usuarioActual.Nombre;
            lblDescripcion.Text = usuarioActual.Descripcion;
            if (lblDescripcion.Text == "")
            {
                lblDescripcion.Visible = false;
            }
            CargarSesion();
            await CargarPosts();
            if (await ComprobarUsuario(usuarioLogeado.Nombre, usuarioLogeado.Password) && usuarioActual.Nombre == usuarioLogeado.Nombre)
            {
                this.btnEditar.Visible = true;
                this.btnSeguir.Visible = false;
                this.txtPublicar.Visible = true;
                this.btnPublicar.Visible = true;
            }
            else
            {
                this.btnEditar.Visible = false;
                this.btnSeguir.Visible = true;
                this.txtPublicar.Visible = false;
                this.btnPublicar.Visible = false;
            }
        }

        /// <summary>
        /// It loads the pnlPosts with PostControls for each post of the current user's profile
        /// </summary>
        private async Task CargarPosts()
        {
            this.pnlPosts.Controls.Clear();
            List<Post> posts = await PostsDeUsuario();
            int y = 0;
            foreach (Post post in posts)
            {
                PostControl pc = new PostControl();
                pc.PerteneceAUsuario = post.Usuario == usuarioLogeado.Nombre;
                if (pc.PerteneceAUsuario)
                {
                    pc.ClickBorrar += borrarPost;
                }
                pc.Texto = post.Texto;
                pc.Usuario = post.Usuario;
                pc.IdPost = post.Id;
                pc.IdCategoria = post.IdCategoria;
                pc.Location = new Point(0, y);
                pnlPosts.Controls.Add(pc);
                y += pc.Height + 10;
            }
        }

        /// <summary>
        /// Event that occurs when the btnEditar is clicked. It opens the EditarPerfil form as a modal form
        /// If the answer was Ok, then saves the user data in the database and in the log.txt file. After that, reloads the form
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            EditarPerfil ep = new EditarPerfil(usuarioActual);
            DialogResult dr = ep.ShowDialog();
            if (dr == DialogResult.OK) {
                Usuario u = new Usuario();
                u.Nombre = usuarioLogeado.Nombre;
                u.Email = ep.txtEmail.Text;
                u.Password = ep.txtPassword.Text;
                u.Descripcion = ep.txtDescripcion.Text; 
                u.FechaCreacion = usuarioLogeado.FechaCreacion;
                if(await guardarCambiosPerfil(u))
                {
                    string json = JsonSerializer.Serialize(u);
                    File.WriteAllText("../../Resources/log.json", json);
                }
                RecargarDatos();

            }
        }

        /// <summary>
        /// Calls the Api to save the data of a user is sent as a param. It sends a MessageBox announcing the result and also returns it
        /// </summary>
        /// <param name="u">Usuario object with the data that has to be updated</param>
        /// <returns>Returns true or false depending if the changes were saved successfully</returns>
        private async Task<bool> guardarCambiosPerfil(Usuario u)
        {
            try
            {
                string url = "http://localhost:8080/apirest_placegiver/rest/usuarios/actualizar";
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string json = JsonSerializer.Serialize(u, options);
                using (client = new HttpClient()) {
                    StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await client.PutAsync(url, contenido);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se ha aplicado los cambios correctamente", "Publicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al publicar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al publicar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Event that occurs when the btnPublicar is clicked. If the post is valid, it tries to saved it in the database and, then, reloads the posts
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            if(txtPublicar.Text != "")
            {
                Post p = new Post();
                p.Usuario = usuarioLogeado.Nombre;
                p.Texto = this.txtPublicar.Text;
                p.IdCategoria = cbCategoria.SelectedIndex+1;
                await Postear(p);
                await CargarPosts();
            }
            else
            {
                MessageBox.Show("Introduzca algún mensaje para publicar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPublicar.Focus(); 
            }
        }

        /// <summary>
        /// Calls the Api and saves a Post in the database that is sent as a parm. Puts a MessageBox with the result
        /// </summary>
        /// <param name="p">Post that is sent to save</param>
        private async Task Postear(Post p)
        {
            try
            {
                string url = "http://localhost:8080/apirest_placegiver/rest/posts/publicarConCategoria";
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string json = JsonSerializer.Serialize(p, options);
                using (client = new HttpClient())
                {
                    StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await client.PostAsync(url, contenido);

                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se ha creado la publicación correctamente","Publicado",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al publicar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string resultado = await respuesta.Content.ReadAsStringAsync();

                    Console.WriteLine(resultado);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al publicar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Event that occurs when a button with this event is clicked, which are the btnBorrar of each PostControl.
        /// It asks the user if they are sure to delete the post. If the answer is yes, then it calls the borrarPostApi function to delete it from the database. Then, the form's data is reloaded
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void borrarPost(object sender, EventArgs e)
        {
            PostControl pc = (PostControl)sender;
            if (MessageBox.Show("¿Seguro que deseas borrar la publicación?", "Borrar publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                await borrarPostApi(pc.IdPost);
                RecargarDatos();
            }
        }

        /// <summary>
        /// Calls the Api to delete a post from the database with an id is given as a param
        /// </summary>
        /// <param name="id">Post's id that must be deleted</param>
        private async Task borrarPostApi(int id)
        {
            try
            {
                using (client = new HttpClient())
                {
                    string url = "http://localhost:8080/apirest_placegiver/rest/posts/" + id;
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Post eliminado correctamente");
                        MessageBox.Show("Se ha creado la publicación correctamente", "Publicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al publicar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Event that occurs when the form is activated. Calls the RecargarDatos function to reload all the form's data
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void Perfil_Activated(object sender, EventArgs e)
        { 
            RecargarDatos();
        }
    }
}
