namespace DisenoEscritorio
{
    partial class Form1
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnSeguir = new System.Windows.Forms.Button();
            this.panelPosts = new System.Windows.Forms.Panel();
            this.lblSeguidores = new System.Windows.Forms.Label();
            this.lblSeguidos = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(373, 144);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 25);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "label1";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(178, 191);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(457, 13);
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
            // panelPosts
            // 
            this.panelPosts.AutoScroll = true;
            this.panelPosts.Location = new System.Drawing.Point(229, 303);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Size = new System.Drawing.Size(349, 405);
            this.panelPosts.TabIndex = 4;
            // 
            // lblSeguidores
            // 
            this.lblSeguidores.AutoSize = true;
            this.lblSeguidores.Location = new System.Drawing.Point(288, 238);
            this.lblSeguidores.Name = "lblSeguidores";
            this.lblSeguidores.Size = new System.Drawing.Size(72, 13);
            this.lblSeguidores.TabIndex = 5;
            this.lblSeguidores.Text = "Seguidores: 0";
            // 
            // lblSeguidos
            // 
            this.lblSeguidos.AutoSize = true;
            this.lblSeguidos.Location = new System.Drawing.Point(452, 238);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblSeguidos);
            this.Controls.Add(this.lblSeguidores);
            this.Controls.Add(this.panelPosts);
            this.Controls.Add(this.btnSeguir);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pbFotoPerfil);
            this.Name = "Form1";
            this.Text = "Perfil";
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoPerfil;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnSeguir;
        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.Label lblSeguidores;
        private System.Windows.Forms.Label lblSeguidos;
        private System.Windows.Forms.Button btnEditar;
    }
}

