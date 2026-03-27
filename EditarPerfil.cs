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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] cadenas = this.txtEmail.Text.Split('@');
            if (this.txtEmail.Text == "")
            {
                MessageBox.Show("El email es un campo obligatorio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lblError.Text = "El campo de Email es obligatorio"; 
                this.txtEmail.Focus();
            }
            else if (this.txtPassword.Text == "")
            {
                MessageBox.Show("La contraseña es un campo obligatorio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lblError.Text = "El campo de Contraseña es obligatorio";
                this.txtPassword.Focus();
            }
            else if (!this.txtEmail.Text.Contains("@") || cadenas.Length != 2 || this.txtEmail.Text.Contains(' ') || cadenas[0] == "" || cadenas[1] == "")
            {
                MessageBox.Show("El campo email debe contener uno valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lblError.Text = "Tiene que introducirse un email valido";
                this.txtEmail.Focus();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
