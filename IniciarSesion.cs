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
    public partial class IniciarSesion : Form
    {
        private HttpClient client;
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Trim() == "" || this.txtPassword.Text.Trim() == "")
            {
                lblError.Text = "Todos los campos deben rellenarse para iniciar sesión";
            }
            else
            {
                client = new HttpClient();
                if (await ComprobarUsuario())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos. Intentalo de nuevo";
                }
            }
        }

        private async Task<bool> ComprobarUsuario()
        {
            try
            {
                Usuario u;
                string url = "http://localhost:8080/apirest_placegiver/rest/usuarios?nombre=" + this.txtNombre.Text + "&pass=" + this.txtPassword.Text;
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                u = JsonSerializer.Deserialize<Usuario>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (u.Nombre == null || u.Nombre == "")
                {
                    return false;
                }
                else
                {
                    File.WriteAllText("../../Resources/log.json", json);
                    return true;
                }
            }
            catch (Exception ex) {
                return false;
            }
            
        }
        
    }
}
