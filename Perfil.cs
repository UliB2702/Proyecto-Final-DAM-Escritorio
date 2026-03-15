using ComponentesRedSocial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Perfil()
        {
            InitializeComponent();
            client = new HttpClient();
            
        }

        private async Task<List<Post>> PostDeUsuario()
        {
            try
            {
                List<Post> posts;
                string url = "http://10.0.2.2:8080/apirest_placegiver/rest/posts/as";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                posts = JsonSerializer.Deserialize<List<Post>>(json);

                return posts ?? new List<Post>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al cargar posts");
                return new List<Post>();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
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
        }
    }
}
