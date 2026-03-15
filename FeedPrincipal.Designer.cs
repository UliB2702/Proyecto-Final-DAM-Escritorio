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
            this.pnlPosts = new System.Windows.Forms.Panel();
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPosts
            // 
            this.pnlPosts.AutoScroll = true;
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
            // 
            // FeedPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pbFotoPerfil);
            this.Controls.Add(this.pnlPosts);
            this.Name = "FeedPrincipal";
            this.Text = "FeedPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPosts;
        private System.Windows.Forms.PictureBox pbFotoPerfil;
        private System.Windows.Forms.Label lblUsuario;
    }
}