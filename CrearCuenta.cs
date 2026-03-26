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
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if(this.txtNombre.Text.Trim() == "" || this.txtEmail.Text.Trim() == "" || this.txtPassword.Text.Trim() == "" || this.txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos deben rellenarse para crear una cuenta", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblError.Text = "Todos los campos deben rellenarse para crear una cuenta";
            }
            else
            {
                if(await CrearUsuario())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Hubo un problema con el servidor. Informa a los creadores del error", "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lblError.Text = "Algunos de los datos es incorrecto. Intentalo de nuevo";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
