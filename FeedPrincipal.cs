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
        public FeedPrincipal()
        {
            InitializeComponent();
            client = new HttpClient();
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
            
            if (usuarioLogeado.Nombre == null || usuarioLogeado.Nombre == "")
            {
                this.pbFotoPerfil.Visible = false;
                this.lblUsuario.Visible = false;
                this.lblIniciarSesion.Visible = true;
                this.lblCrearCuenta.Visible = true;
            }
            else
            {
                this.pbFotoPerfil.Visible = true;
                this.lblUsuario.Visible = true;
                this.lblIniciarSesion.Visible = false;
                this.lblCrearCuenta.Visible = false;
            }
        }

        private async Task<List<Post>> PostFeed()
        {
            try
            {
                List<Post> posts;
                string url = "http://localhost:8080/apirest_placegiver/rest/posts";
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

        private async void FeedPrincipal_Load(object sender, EventArgs e)
        {
            List<Post> posts = await PostFeed();
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
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Blue;
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }
    }
}
