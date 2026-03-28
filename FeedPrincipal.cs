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

namespace DisenoEscritorio
{
    /// <summary>
    /// Main form where you can see the most recent posts.
    /// </summary>
    public partial class FeedPrincipal : Form
    {
        private HttpClient client;
        Usuario usuarioLogeado;
        
        /// <summary>
        /// Initializes the FeedPrincipal form. It also initializes the HttpClient for it's use later
        /// </summary>
        public FeedPrincipal()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        /// <summary>
        /// Event that occurs when the form loads. It loads the most recent posts and the user's session in case there was one already
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void FeedPrincipal_Load(object sender, EventArgs e)
        {
            await CargarSesion();
            await CargarPosts();
        }

        /// <summary>
        /// Calls the Api for the most recent posts and creates a PostController for each of them. It also gives them properties if they belong to the current logged user
        /// </summary>
        private async Task CargarPosts()
        {
            this.pnlPosts.Controls.Clear();
            List<Post> posts = await PostsFeed();
            int y = 0;
            foreach (Post post in posts)
            {
                PostControl pc = new PostControl();
                pc.Texto = post.Texto;
                if (post.Usuario == usuarioLogeado.Nombre)
                {
                    pc.PerteneceAUsuario = true;
                    pc.ClickBorrar += borrarPost;
                }
                else
                {
                    pc.PerteneceAUsuario = false;
                }
                pc.Usuario = post.Usuario;
                pc.ClickPerfil += IrAPerfil;
                pc.IdPost = post.Id;
                pc.IdCategoria = post.IdCategoria;
                pc.Location = new Point(0, y);
                pnlPosts.Controls.Add(pc);
                y += pc.Height + 10;
            }
        }

        /// <summary>
        /// Event that occurs when the User's name from a post is clicked. It opens the Account form of that user
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void IrAPerfil(object sender, EventArgs e)
        {
            PostControl p = (PostControl)(sender);
            Perfil perfil = new Perfil(p.Usuario);
            DialogResult dr = perfil.ShowDialog();
        }

        /// <summary>
        /// Calls the API for the most recent posts from the database
        /// </summary>
        /// <returns>Returns a list with all the posts found or a empty list in case there was some error with the server</returns>
        private async Task<List<Post>> PostsFeed()
        {
            try
            {
                List<Post> posts;
                string url = "http://localhost:8080/apirest_placegiver/rest/posts";
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
        /// It loads the log.txt file from the resources and verifies if it is a valid user and, if it is, puts visible the user buttons.
        /// </summary>
        private async Task CargarSesion()
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
            if (usuarioLogeado.Nombre == null || usuarioLogeado.Nombre == "" || !(await ComprobarUsuario(usuarioLogeado.Nombre, usuarioLogeado.Password)))
            {
                this.pbFotoPerfil.Visible = false;
                this.lblUsuario.Visible = false;
                this.lblIniciarSesion.Visible = true;
                this.lblCrearCuenta.Visible = true;
                this.lblCerrarSesion.Visible = false;
            }
            else
            {
                this.pbFotoPerfil.Visible = true;
                this.lblUsuario.Visible = true;
                this.lblUsuario.Text = usuarioLogeado.Nombre;
                this.lblIniciarSesion.Visible = false;
                this.lblCrearCuenta.Visible = false;
                this.lblCerrarSesion.Visible = true;
            }
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
        /// Event that occurs when the mouse is over a label that has the event. It changes the Foreground color to blue to emphasize this
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Blue;
        }

        /// <summary>
        /// Event that occurs when the mouse stops being over a label that has the event. It changes the Foreground color to black to emphasize this
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        /// <summary>
        /// Event that occurs when the lblIniciarSesion is clicked. It opens the IniciarSesion form as a modal form and, if the user logged correctly, it loads the log.txt session and reloads the posts
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            DialogResult dr = iniciarSesion.ShowDialog();
            if (dr == DialogResult.OK) {
                await CargarPosts();
                await CargarSesion();
            }

        }

        /// <summary>
        /// Event that occurs when the lblCrearCuenta is clicked. It opens the CrearCuenta form as a modal form.
        /// If the user created the account successfully, it confirms the user was created currectly and saves the data in the log.txt file. Finally, it reloads the current form's data
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void lblCrearCuenta_Click(object sender, EventArgs e)
        {
            CrearCuenta cc = new CrearCuenta();
            DialogResult dr = cc.ShowDialog();
            if (dr == DialogResult.OK) {
                try
                {
                    Usuario u;
                    string url = "http://localhost:8080/apirest_placegiver/rest/usuarios?nombre=" + cc.txtNombre.Text;
                    client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    u = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    File.WriteAllText("../../Resources/log.json", json);
                }
                catch (Exception ex)
                {

                }
                await CargarPosts();
                CargarSesion();
            }
        }

        /// <summary>
        /// Event that occurs when the lblUsuario is clicked. It opens the Perfil form as a modal form of the current logged user.
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lblUsuario_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(usuarioLogeado.Nombre);
            DialogResult dr = p.ShowDialog();
        }

        /// <summary>
        /// Event that occurs when the mouse is over the lblCerrarSesion. It changes the Foreground color to red to emphasize this
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lblCerrarSesion_MouseEnter(object sender, EventArgs e)
        {
            this.lblCerrarSesion.ForeColor = Color.Red;
        }

        /// <summary>
        /// Event that occurs when the lblCerrarSesion is clicked. It deletes the log.txt file so the user can be logged out. Then, the forms data is reloaded
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            if (File.Exists("../../Resources/log.json"))
            {
                File.Delete("../../Resources/log.json");
            }
            await CargarSesion();
            await CargarPosts();
        }

        /// <summary>
        /// Event that occurs when the Form is activated. It reloads the data of the form in case there was some kind of change
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private async void FeedPrincipal_Activated(object sender, EventArgs e)
        {
            await CargarPosts();
            await CargarSesion();
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
            if (MessageBox.Show("¿Seguro que deseas borrar la publicación?","Borrar publicación",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                borrarPostApi(pc.IdPost);
                await CargarSesion();
                await CargarPosts();
            }
        }

        /// <summary>
        /// Calls the Api to delete a post from the database with an id is given as a param
        /// </summary>
        /// <param name="id">Post's id that must be deleted</param>
        private async void borrarPostApi(int id)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:8080/apirest_placegiver/rest/posts/"+id;
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Post eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
