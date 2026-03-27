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
    public partial class FeedPrincipal : Form
    {
        private HttpClient client;
        Usuario usuarioLogeado;
        
        /// <summary>
        /// Main form where you can see the most recent posts
        /// </summary>
        public FeedPrincipal()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        /// <summary>
        /// Event that activates when the form loads. It loads the most recent posts and the user's session in case there was one already
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private async void FeedPrincipal_Load(object sender, EventArgs e)
        {
            await CargarSesion();
            await CargarPosts();
        }

        /// <summary>
        /// Calls the Api for the most recent posts and creates a PostController for each of them and gives them properties if they are from the current logged user
        /// </summary>
        /// <returns></returns>
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
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
                Console.WriteLine(json); // DEBUG

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
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Blue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private async void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            DialogResult dr = iniciarSesion.ShowDialog();
            if (dr == DialogResult.OK) {
                await CargarPosts();
                CargarSesion();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private void lblUsuario_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(usuarioLogeado.Nombre);
            DialogResult dr = p.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private void lblCerrarSesion_MouseEnter(object sender, EventArgs e)
        {
            this.lblCerrarSesion.ForeColor = Color.Red;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private async void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            if (File.Exists("../../Resources/log.json"))
            {
                File.Delete("../../Resources/log.json");
            }
            CargarSesion();
            await CargarPosts();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private async void FeedPrincipal_Activated(object sender, EventArgs e)
        {
            await CargarPosts();
            CargarSesion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e"></param>
        private async void borrarPost(object sender, EventArgs e)
        {
            PostControl pc = (PostControl)sender;   
            if (MessageBox.Show("¿Seguro que deseas borrar la publicación?","Borrar publicación",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                borrarPostApi(pc.IdPost);
                CargarSesion();
                await CargarPosts();
            }
        }

        /// <summary>
        /// 
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
