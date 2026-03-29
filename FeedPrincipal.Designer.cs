namespace DisenoEscritorio
{
    partial class FeedPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedPrincipal));
            this.pnlPosts = new System.Windows.Forms.Panel();
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.lblCrearCuenta = new System.Windows.Forms.Label();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPosts
            // 
            this.pnlPosts.AutoScroll = true;
            this.pnlPosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPosts.Location = new System.Drawing.Point(192, 86);
            this.pnlPosts.Name = "pnlPosts";
            this.pnlPosts.Size = new System.Drawing.Size(405, 363);
            this.pnlPosts.TabIndex = 0;
            // 
            // pbFotoPerfil
            // 
            this.pbFotoPerfil.Image = global::DisenoEscritorio.Properties.Resources.fotoperfil;
            this.pbFotoPerfil.Location = new System.Drawing.Point(12, 12);
            this.pbFotoPerfil.Name = "pbFotoPerfil";
            this.pbFotoPerfil.Size = new System.Drawing.Size(49, 50);
            this.pbFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoPerfil.TabIndex = 1;
            this.pbFotoPerfil.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(67, 29);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 16);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "label2";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            this.lblUsuario.MouseEnter += new System.EventHandler(this.lbl_MouseEnter);
            this.lblUsuario.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.AutoSize = true;
            this.lblIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciarSesion.Location = new System.Drawing.Point(584, 9);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(101, 16);
            this.lblIniciarSesion.TabIndex = 4;
            this.lblIniciarSesion.Text = "Iniciar Sesión";
            this.lblIniciarSesion.Click += new System.EventHandler(this.lblIniciarSesion_Click);
            this.lblIniciarSesion.MouseEnter += new System.EventHandler(this.lbl_MouseEnter);
            this.lblIniciarSesion.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
            // 
            // lblCrearCuenta
            // 
            this.lblCrearCuenta.AutoSize = true;
            this.lblCrearCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCuenta.Location = new System.Drawing.Point(691, 9);
            this.lblCrearCuenta.Name = "lblCrearCuenta";
            this.lblCrearCuenta.Size = new System.Drawing.Size(97, 16);
            this.lblCrearCuenta.TabIndex = 5;
            this.lblCrearCuenta.Text = "Crear Cuenta";
            this.lblCrearCuenta.Click += new System.EventHandler(this.lblCrearCuenta_Click);
            this.lblCrearCuenta.MouseEnter += new System.EventHandler(this.lbl_MouseEnter);
            this.lblCrearCuenta.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCerrarSesion.Location = new System.Drawing.Point(686, 29);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(102, 16);
            this.lblCerrarSesion.TabIndex = 6;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            this.lblCerrarSesion.MouseEnter += new System.EventHandler(this.lblCerrarSesion_MouseEnter);
            this.lblCerrarSesion.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Items.AddRange(new object[] {
            "(Todos los posts)",
            "Desarrollo",
            "Propuestas de Trabajo",
            "Preguntas Generales"});
            this.cbCategoria.Location = new System.Drawing.Point(192, 60);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(405, 21);
            this.cbCategoria.TabIndex = 11;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(189, 41);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(79, 16);
            this.lblCategoria.TabIndex = 12;
            this.lblCategoria.Text = "Categoria:";
            // 
            // FeedPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.lblCrearCuenta);
            this.Controls.Add(this.lblIniciarSesion);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pbFotoPerfil);
            this.Controls.Add(this.pnlPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeedPrincipal";
            this.Text = "Placegiver";
            this.Activated += new System.EventHandler(this.FeedPrincipal_Activated);
            this.Load += new System.EventHandler(this.FeedPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPosts;
        private System.Windows.Forms.PictureBox pbFotoPerfil;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.Label lblCrearCuenta;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblCategoria;
    }
}