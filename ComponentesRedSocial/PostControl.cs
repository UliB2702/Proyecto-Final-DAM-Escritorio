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
    /// <summary>
    /// Control that is used to show a Post in the forms
    /// </summary>
    [
        DefaultEvent(""),
        DefaultProperty("Texto")
        ]
    public partial class PostControl: UserControl
    {

        private int idPost;
        private int idCategoria;
        private bool perteneceAUsuario = true;

        public PostControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        [Category("My properties")]
        [Description("Id of the post")]
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

        [Category("My properties")]
        [Description("Id of the post's category")]
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



        [Category("My properties")]
        [Description("Text of the post")]
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

        [Category("My properties")]
        [Description("Name of the user who owns the post")]
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

        [Category("My properties")]
        [Description("Determines is the post is owned by the current logged user or not")]
        public bool PerteneceAUsuario
        {
            set
            {
                this.perteneceAUsuario = value;
                if (this.perteneceAUsuario) {
                    this.btnBorrar.Visible = true;
                }
                else
                {
                    this.btnBorrar.Visible = false;
                }
            }
            get
            {
                return this.perteneceAUsuario;
            }
        }



        [Category("My events")]
        [Description("It activates when the btnBorras is clicked")]
        public event EventHandler ClickBorrar;

        /// <summary>
        /// Event that occurs that when the btnBorrar is clicked. It calls to OnClickBorrar
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
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

        [Category("My events")]
        [Description("It activates when the user profile image or name is clicked")]
        public event EventHandler ClickPerfil;



        protected void OnClickPerfil(object sender, EventArgs e)
        {
            if (ClickPerfil != null)
            {
                ClickPerfil(this, e);
            }
        }

        /// <summary>
        /// Event that occurs that when the pbFotoUsuario is clicked. It calls to OnClickPerfil
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void pbFotoUsuario_Click(object sender, EventArgs e)
        {
            OnClickPerfil(sender, e);
        }

        /// <summary>
        /// Event that occurs that when the lblUsuario is clicked. It calls to OnClickPerfil
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lblUsuario_Click(object sender, EventArgs e)
        {
            OnClickPerfil(sender, e);
        }

        /// <summary>
        /// Event that occurs when the mouse is over the lblUsuario. It changes the Foreground color to blue to emphasize this
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lblUsuario_MouseEnter(object sender, EventArgs e)
        {
            this.lblUsuario.ForeColor = Color.Blue;
        }

        /// <summary>
        /// Event that occurs when the mouse stops being over the lblUsuario. It changes the Foreground color to black to emphasize this
        /// </summary>
        /// <param name="sender">Object that activated the event</param>
        /// <param name="e">Data related to the event</param>
        private void lblUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.lblUsuario.ForeColor = Color.Black;
        }
    }
}
