using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenoEscritorio
{
    public partial class EditarPerfil : Form
    {
        private Usuario datos = new Usuario();
        public EditarPerfil(Usuario u)
        {
            InitializeComponent();
            this.datos = u;
            this.lblUsuario.Text = datos.Nombre;
            this.txtDescripcion.Text = datos.Descripcion;
            this.txtEmail.Text = datos.Email;
            this.txtPassword.Text = datos.Password;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtEmail.Text == "")
            {
                this.lblError.Text = "El campo de Email es obligatorio";
            }
            else if (this.txtPassword.Text == "")
            {
                this.lblError.Text = "El campo de Contraseña es obligatorio";
            }
            else if (!this.txtEmail.Text.Contains("@"))
            {
                this.lblError.Text = "Tiene que introducirse un email valido";
            }
            else
            {

            }
        }
    }
}
