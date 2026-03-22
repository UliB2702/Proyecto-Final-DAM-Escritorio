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

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if(this.txtNombre.Text.Trim() == "" || this.txtEmail.Text.Trim() == "" || this.txtPassword.Text.Trim() == "" || this.txtConfirmPassword.Text.Trim() == "")
            {
                lblError.Text = "Todos los campos deben rellenarse para crear una cuenta";
            }
            else
            {
                if(await CrearUsuario())
                {

                }
                else
                {
                    this.lblError.Text = "Algunos de los datos es incorrecto. Intentalo de nuevo";
                }
            }
        }

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

                string json = JsonSerializer.Serialize(uCrear);
                using (HttpClient client = new HttpClient())
                {
                    StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var respuesta = await client.PostAsync(url, contenido);
                        var resultado = await respuesta.Content.ReadAsStringAsync();

                        return true;
                    }
                    catch (Exception)
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
