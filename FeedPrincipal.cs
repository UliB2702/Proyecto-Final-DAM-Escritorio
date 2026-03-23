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
        }


        private async void FeedPrincipal_Load(object sender, EventArgs e)
        {
            CargarSesion();
            CargarPosts();
        }

        private async void CargarPosts()
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

        private void IrAPerfil(object sender, EventArgs e)
        {
            PostControl p = (PostControl)(sender);
            Perfil perfil = new Perfil(p.Usuario);
            DialogResult dr = perfil.ShowDialog();
        }


        private async Task<List<Post>> PostsFeed()
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
            if (usuarioLogeado.Nombre == null || usuarioLogeado.Nombre == "")
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

        private void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            DialogResult dr = iniciarSesion.ShowDialog();
            if (dr == DialogResult.OK) {
                CargarPosts();
                CargarSesion();
            }

        }

        private void lblCrearCuenta_Click(object sender, EventArgs e)
        {
            CrearCuenta cc = new CrearCuenta();
            DialogResult dr = cc.ShowDialog();
            if (dr == DialogResult.OK) { 
                
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(usuarioLogeado.Nombre);
            DialogResult dr = p.ShowDialog();
        }

        private void lblCerrarSesion_MouseEnter(object sender, EventArgs e)
        {
            this.lblCerrarSesion.ForeColor = Color.Red;
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}
