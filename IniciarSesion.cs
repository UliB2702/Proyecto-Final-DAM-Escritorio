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
    /// Form where the users log in with their account
    /// </summary>
    public partial class IniciarSesion : Form
    {
        private HttpClient client;

        /// <summary>
        /// Initializes the IniciarSesion form.
        /// </summary>
        public IniciarSesion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event that occurs when the btnEnviar is clicked
        /// Verifies the data fields are all correct and calls the api the search for them in the database. It case that goes well, sends OK as DialogResult and it the form closes
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
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

        /// <summary>
        /// Calls the Api to verify if the is a user with the name and password sent in the form. If there is, saves the result in log.txt
        /// </summary>
        /// <returns>Returns trye or false if a user was found with the password and name sent</returns>
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
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
        
    }
}
