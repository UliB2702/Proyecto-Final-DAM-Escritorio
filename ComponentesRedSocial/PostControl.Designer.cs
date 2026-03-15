namespace ComponentesRedSocial
{
    partial class PostControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostControl));
            this.pbFotoUsuario = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFotoUsuario
            // 
            this.pbFotoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("pbFotoUsuario.Image")));
            this.pbFotoUsuario.Location = new System.Drawing.Point(17, 14);
            this.pbFotoUsuario.Name = "pbFotoUsuario";
            this.pbFotoUsuario.Size = new System.Drawing.Size(54, 54);
            this.pbFotoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoUsuario.TabIndex = 0;
            this.pbFotoUsuario.TabStop = false;
            this.pbFotoUsuario.Click += new System.EventHandler(this.pbFotoUsuario_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(91, 32);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(71, 20);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            this.lblUsuario.MouseEnter += new System.EventHandler(this.lblUsuario_MouseEnter);
            this.lblUsuario.MouseLeave += new System.EventHandler(this.lblUsuario_MouseLeave);
            // 
            // lblTexto
            // 
            this.lblTexto.Location = new System.Drawing.Point(-3, 87);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.lblTexto.Size = new System.Drawing.Size(365, 56);
            this.lblTexto.TabIndex = 2;
            this.lblTexto.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(362, 253);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Red;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.Location = new System.Drawing.Point(320, 3);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(39, 23);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // PostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(207)))), ((int)(((byte)(153)))));
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pbFotoUsuario);
            this.Name = "PostControl";
            this.Size = new System.Drawing.Size(362, 399);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnBorrar;
    }
}
