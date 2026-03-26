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

    public partial class Perfil : Form
    {
        private HttpClient client;
        private string nombreUsuarioActual = "";
        private Usuario usuarioActual = new Usuario();
        private string nombreUsuarioLogeado = "";
        Usuario usuarioLogeado = new Usuario();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public Perfil(string usuario)
        {
            InitializeComponent();
            client = new HttpClient();
            nombreUsuarioActual = usuario;
            CargarSesion();

        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            usuarioActual = await CargarPerfil();
            lblNombre.Text = usuarioActual.Nombre;
            lblDescripcion.Text = usuarioActual.Descripcion;
            if(lblDescripcion.Text == "")
            {
                lblDescripcion.Visible = false;
            }

            await CargarPosts();
            

            if (usuarioActual.Nombre == usuarioLogeado.Nombre)
            {
                this.btnEditar.Visible = true;
                this.btnSeguir.Visible = false;
                this.txtPublicar.Visible = true;
                this.btnPublicar.Visible = true;
            }
            else {
                this.btnEditar.Visible = false;
                this.btnSeguir.Visible = true;
                this.txtPublicar.Visible = false;
                this.btnPublicar.Visible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async void RecargarDatos()
        {
            CargarSesion();
            await CargarPosts();
            if (usuarioActual.Nombre == usuarioLogeado.Nombre)
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
            Usuario u = await CargarPerfil();
            if (u != null || u.Nombre != "") { 
                this.lblNombre.Text = u.Nombre;
                this.lblDescripcion.Text = u.Descripcion;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            if(txtPublicar.Text != "")
            {
                Post p = new Post();
                p.Usuario = usuarioLogeado.Nombre;
                p.Texto = this.txtPublicar.Text;
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
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private async Task Postear(Post p)
        {
            try
            {
                string url = "http://localhost:8080/apirest_placegiver/rest/posts/publicar";
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Perfil_Activated(object sender, EventArgs e)
        {
            RecargarDatos();
        }
    }
}
