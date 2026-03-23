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
    public partial class Perfil : Form
    {
        private HttpClient client;
        private string nombreUsuarioActual = "";
        private Usuario usuarioActual = new Usuario();
        private string nombreUsuarioLogeado = "";
        Usuario usuarioLogeado = new Usuario();

        public Perfil(string usuario)
        {
            InitializeComponent();
            client = new HttpClient();
            nombreUsuarioActual = usuario;
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

        private async Task<List<Post>> PostsDeUsuario()
        {
            try
            {
                List<Post> posts;
                string url = "http://localhost:8080/apirest_placegiver/rest/posts/"+nombreUsuarioActual;
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
        private async Task<Usuario> CargarPerfil()
        {
            Usuario u;
            string url = "http://localhost:8080/apirest_placegiver/rest/usuarios?nombre=" + nombreUsuarioActual;
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            u = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return u ?? new Usuario();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            usuarioActual = await CargarPerfil();
            lblNombre.Text = usuarioActual.Nombre;
            lblDescripcion.Text = usuarioActual.Descripcion;
            if(lblDescripcion.Text == "")
            {
                lblDescripcion.Visible = false;
            }

            CargarPosts();
            

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

        private async void CargarPosts()
        {
            this.pnlPosts.Controls.Clear();
            List<Post> posts = await PostsDeUsuario();
            int y = 0;
            foreach (Post post in posts)
            {
                PostControl pc = new PostControl();
                pc.PerteneceAUsuario = post.Usuario == usuarioLogeado.Nombre;
                pc.Texto = post.Texto;
                pc.Usuario = post.Usuario;
                pc.IdPost = post.Id;
                pc.IdCategoria = post.IdCategoria;
                pc.Location = new Point(0, y);
                pnlPosts.Controls.Add(pc);
                y += pc.Height + 10;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarPerfil ep = new EditarPerfil(usuarioActual);
            DialogResult dr = ep.ShowDialog();
            if (dr == DialogResult.OK) { 
                 

            }
        }

        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            if(txtPublicar.Text != "")
            {
                Post p = new Post();
                p.Usuario = usuarioLogeado.Nombre;
                p.Texto = this.txtPublicar.Text;
                Postear(p);
                CargarPosts();
            }
            else
            {
                txtPublicar.Focus(); 
            }
        }

        private async void Postear(Post p)
        {
            try
            {
                string url = "http://localhost:8080/apirest_placegiver/rest/posts/publicar";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = JsonSerializer.Serialize(p);
                using (HttpClient client = new HttpClient())
                {
                    StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var respuesta = await client.PostAsync(url, contenido);
                        var resultado = await respuesta.Content.ReadAsStringAsync();

                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
