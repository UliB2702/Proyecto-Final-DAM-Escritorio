using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentesRedSocial
{
    [
        DefaultEvent(""),
        DefaultProperty("Texto")
        ]
    public partial class PostControl: UserControl
    {

        private int idPost;
        private int idCategoria;

        public PostControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public int IdPost
        {
            set
            {
                this.idPost = value;
            }
            get
            {
                return this.idPost;
            }
        }

        public int IdCategoria
        {
            set
            {
                this.idCategoria = value;
            }
            get
            {
                return this.idCategoria;
            }
        }

        [Category("Mis propiedades")]
        [Description("El texto que viene en la publicación")]
        public string Texto
        {
            set
            {
                this.lblTexto.Text = value;
            }
            get
            {
                return this.lblTexto.Text;
            }
        }

        [Category("Mis propiedades")]
        [Description("Nombre del usuario que publico el post")]
        public string Usuario
        {
            set
            {
                this.lblUsuario.Text = value;
            }
            get
            {
                return this.lblUsuario.Text;
            }
        }

        [Category("Mis eventos")]
        [Description("Se acriva cuando se preciona el boton de borrar")]
        public event EventHandler ClickBorrar;
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            OnClickBorrar(sender, e);
        }

        protected void OnClickBorrar(object sender, EventArgs e) {
            if (ClickBorrar != null)
            {
                ClickBorrar(this, e);
            }
        }

        [Category("Mis eventos")]
        [Description("Se acriva cuando se preciona el boton de borrar")]
        public event EventHandler ClickPerfil;


        protected void OnClickPerfil(object sender, EventArgs e)
        {
            if (ClickPerfil != null)
            {
                ClickPerfil(this, e);
            }
        }

        private void pbFotoUsuario_Click(object sender, EventArgs e)
        {
            OnClickPerfil(sender, e);
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            OnClickPerfil(sender, e);
        }

        private void lblUsuario_MouseEnter(object sender, EventArgs e)
        {
            this.lblUsuario.ForeColor = Color.Blue;
        }

        private void lblUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.lblUsuario.ForeColor = Color.Black;
        }
    }
}
