using ComponentesRedSocial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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
                json = File.ReadAllText("Resources/log.json");
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

        private async Task<List<Post>> PostDeUsuario()
        {
            try
            {
                List<Post> posts;
                string url = "http://10.0.2.2:8080/apirest_placegiver/rest/posts/"+nombreUsuarioActual;
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
            string url = "http://10.0.2.2:8080/apirest_placegiver/rest/usuarios?nombre=" + nombreUsuarioActual;
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


            List<Post> posts = await PostDeUsuario();
            int y = 0;
            foreach (Post post in posts) { 
                PostControl pc = new PostControl();
                pc.Texto = post.Texto;
                pc.Usuario = post.Usuario;
                pc.IdPost = post.Id;
                pc.IdCategoria = post.IdCategoria;
                pc.Location = new Point(0, y);
                pnlPosts.Controls.Add(pc);
                y += pc.Height + 10;
            }

            if (usuarioActual.Nombre == usuarioLogeado.Nombre)
            {
                this.btnEditar.Visible = true;
                this.btnSeguir.Visible = false;
            }
            else {
                this.btnEditar.Visible = false;
                this.btnSeguir.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarPerfil ep = new EditarPerfil();
            DialogResult dr = ep.ShowDialog();
            if (dr == DialogResult.OK) { 
                 

            }
        }
        
    }
}
