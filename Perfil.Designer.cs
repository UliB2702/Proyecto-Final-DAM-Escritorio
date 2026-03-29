namespace DisenoEscritorio
{
    partial class Perfil
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Perfil));
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnSeguir = new System.Windows.Forms.Button();
            this.pnlPosts = new System.Windows.Forms.Panel();
            this.lblSeguidores = new System.Windows.Forms.Label();
            this.lblSeguidos = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPublicar = new System.Windows.Forms.TextBox();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(207)))), ((int)(((byte)(153)))));
            this.lblDescripcion.Location = new System.Drawing.Point(173, 211);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Padding = new System.Windows.Forms.Padding(8);
            this.lblDescripcion.Size = new System.Drawing.Size(470, 53);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss" +
    "sssssssss";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSeguir
            // 
            this.btnSeguir.BackColor = System.Drawing.Color.Blue;
            this.btnSeguir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeguir.ForeColor = System.Drawing.Color.White;
            this.btnSeguir.Location = new System.Drawing.Point(577, 116);
            this.btnSeguir.Name = "btnSeguir";
            this.btnSeguir.Size = new System.Drawing.Size(70, 26);
            this.btnSeguir.TabIndex = 3;
            this.btnSeguir.Text = "Seguir +";
            this.btnSeguir.UseVisualStyleBackColor = false;
            // 
            // pnlPosts
            // 
            this.pnlPosts.AutoScroll = true;
            this.pnlPosts.Location = new System.Drawing.Point(173, 430);
            this.pnlPosts.Name = "pnlPosts";
            this.pnlPosts.Size = new System.Drawing.Size(470, 437);
            this.pnlPosts.TabIndex = 4;
            // 
            // lblSeguidores
            // 
            this.lblSeguidores.AutoSize = true;
            this.lblSeguidores.Location = new System.Drawing.Point(302, 177);
            this.lblSeguidores.Name = "lblSeguidores";
            this.lblSeguidores.Size = new System.Drawing.Size(72, 13);
            this.lblSeguidores.TabIndex = 5;
            this.lblSeguidores.Text = "Seguidores: 0";
            // 
            // lblSeguidos
            // 
            this.lblSeguidos.AutoSize = true;
            this.lblSeguidos.Location = new System.Drawing.Point(442, 179);
            this.lblSeguidos.Name = "lblSeguidos";
            this.lblSeguidos.Size = new System.Drawing.Size(63, 13);
            this.lblSeguidos.TabIndex = 6;
            this.lblSeguidos.Text = "Seguidos: 0";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Blue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::DisenoEscritorio.Properties.Resources.edit;
            this.btnEditar.Location = new System.Drawing.Point(445, 116);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(28, 23);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pbFotoPerfil
            // 
            this.pbFotoPerfil.Image = global::DisenoEscritorio.Properties.Resources.fotoperfil;
            this.pbFotoPerfil.Location = new System.Drawing.Point(358, 25);
            this.pbFotoPerfil.Name = "pbFotoPerfil";
            this.pbFotoPerfil.Size = new System.Drawing.Size(100, 101);
            this.pbFotoPerfil.TabIndex = 0;
            this.pbFotoPerfil.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(290, 142);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(249, 25);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "label1";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPublicar
            // 
            this.txtPublicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(207)))), ((int)(((byte)(153)))));
            this.txtPublicar.Location = new System.Drawing.Point(173, 288);
            this.txtPublicar.MaxLength = 500;
            this.txtPublicar.Multiline = true;
            this.txtPublicar.Name = "txtPublicar";
            this.txtPublicar.Size = new System.Drawing.Size(470, 81);
            this.txtPublicar.TabIndex = 8;
            // 
            // btnPublicar
            // 
            this.btnPublicar.BackColor = System.Drawing.Color.Blue;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPublicar.ForeColor = System.Drawing.Color.White;
            this.btnPublicar.Location = new System.Drawing.Point(568, 401);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(75, 23);
            this.btnPublicar.TabIndex = 9;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = false;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Items.AddRange(new object[] {
            "Desarrollo",
            "Propuestas de Trabajo",
            "Preguntas Generales"});
            this.cbCategoria.Location = new System.Drawing.Point(176, 375);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(464, 21);
            this.cbCategoria.TabIndex = 10;
            // 
            // Perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(800, 866);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.txtPublicar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblSeguidos);
            this.Controls.Add(this.lblSeguidores);
            this.Controls.Add(this.pnlPosts);
            this.Controls.Add(this.btnSeguir);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pbFotoPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Perfil";
            this.Text = "Perfil";
            this.Activated += new System.EventHandler(this.Perfil_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoPerfil;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnSeguir;
        private System.Windows.Forms.Panel pnlPosts;
        private System.Windows.Forms.Label lblSeguidores;
        private System.Windows.Forms.Label lblSeguidos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPublicar;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.ComboBox cbCategoria;
    }
}

