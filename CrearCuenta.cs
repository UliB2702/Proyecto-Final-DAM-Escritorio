using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenoEscritorio
{
    /// <summary>
    /// Form where the users create their account in case they don't have one
    /// </summary>
    public partial class CrearCuenta : Form
    {
        /// <summary>
        /// Initializes the CrearCuenta form.
        /// </summary>
        public CrearCuenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event that occurs when the btnEnviar is clicked
        /// Verifies the data fields are all correct and send it to the API to be saved on the database. It case that goes well, the form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] cadenas = this.txtEmail.Text.Split('@');
            if (this.txtNombre.Text.Trim() == "" || this.txtEmail.Text.Trim() == "" || this.txtPassword.Text.Trim() == "" || this.txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos deben rellenarse para crear una cuenta", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblError.Text = "Todos los campos deben rellenarse para crear una cuenta";
            }
            else if (!this.txtEmail.Text.Contains("@") || cadenas.Length != 2 || this.txtEmail.Text.Contains(' ') || cadenas[0] == "" || cadenas[1] == "")
            {
                MessageBox.Show("El campo email debe contener uno valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lblError.Text = "Tiene que introducirse un email valido";
                this.txtEmail.Focus();
            }
            else if (this.txtPassword.Text != this.txtConfirmPassword.Text)
            {
                MessageBox.Show("Ambos cambos de contraseña deben contener la misma contraseña", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lblError.Text = "Ambos cambos de contraseña deben contener la misma contraseña";
                this.txtConfirmPassword.Focus();
            }
            else
            {
                if(await CrearUsuario())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Hubo un problema con los datos. Revisalos e ingresalos de nuevo", "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lblError.Text = "Algunos de los datos es incorrecto. Intentalo de nuevo";
                }
            }
        }

        /// <summary>
        /// Inserts the user's data on the database and verifies if it can be created or if there is already a user with that name
        /// </summary>
        /// <returns>Returns true if the user was successfully created or false if it wasn't</returns>
        private async Task<bool> CrearUsuario()
        {
            try
            {
                string url = "http://localhost:8080/apirest_placegiver/rest/usuarios/registro";
                Usuario uCrear = new Usuario();
                uCrear.Nombre = txtNombre.Text;
                uCrear.Descripcion = "";
                uCrear.Email = txtEmail.Text;
                uCrear.Password = txtPassword.Text;

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string json = JsonSerializer.Serialize(uCrear, options);
                using (HttpClient client = new HttpClient())
                {
                    StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta = await client.PostAsync(url, contenido);

                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se ha creado el usuario correctamente", "Publicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
