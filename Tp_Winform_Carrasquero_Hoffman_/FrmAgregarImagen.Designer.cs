namespace Tp_Winform_Carrasquero_Hoffman_
{
    partial class FrmAgregarImagen
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
            this.txtBoxImagen1 = new System.Windows.Forms.TextBox();
            this.txtBoxImagen2 = new System.Windows.Forms.TextBox();
            this.txtBoxImagen3 = new System.Windows.Forms.TextBox();
            this.lblImagen1 = new System.Windows.Forms.Label();
            this.lblImagen2 = new System.Windows.Forms.Label();
            this.lblImagen3 = new System.Windows.Forms.Label();
            this.btnGuardarImagenes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxImagen1
            // 
            this.txtBoxImagen1.Location = new System.Drawing.Point(98, 44);
            this.txtBoxImagen1.Name = "txtBoxImagen1";
            this.txtBoxImagen1.Size = new System.Drawing.Size(657, 22);
            this.txtBoxImagen1.TabIndex = 0;
            // 
            // txtBoxImagen2
            // 
            this.txtBoxImagen2.Location = new System.Drawing.Point(98, 85);
            this.txtBoxImagen2.Name = "txtBoxImagen2";
            this.txtBoxImagen2.Size = new System.Drawing.Size(657, 22);
            this.txtBoxImagen2.TabIndex = 1;
            // 
            // txtBoxImagen3
            // 
            this.txtBoxImagen3.Location = new System.Drawing.Point(98, 130);
            this.txtBoxImagen3.Name = "txtBoxImagen3";
            this.txtBoxImagen3.Size = new System.Drawing.Size(657, 22);
            this.txtBoxImagen3.TabIndex = 2;
            // 
            // lblImagen1
            // 
            this.lblImagen1.AutoSize = true;
            this.lblImagen1.Location = new System.Drawing.Point(23, 47);
            this.lblImagen1.Name = "lblImagen1";
            this.lblImagen1.Size = new System.Drawing.Size(62, 16);
            this.lblImagen1.TabIndex = 3;
            this.lblImagen1.Text = "Imagen 1";
            // 
            // lblImagen2
            // 
            this.lblImagen2.AutoSize = true;
            this.lblImagen2.Location = new System.Drawing.Point(23, 89);
            this.lblImagen2.Name = "lblImagen2";
            this.lblImagen2.Size = new System.Drawing.Size(62, 16);
            this.lblImagen2.TabIndex = 4;
            this.lblImagen2.Text = "Imagen 2";
            // 
            // lblImagen3
            // 
            this.lblImagen3.AutoSize = true;
            this.lblImagen3.Location = new System.Drawing.Point(23, 134);
            this.lblImagen3.Name = "lblImagen3";
            this.lblImagen3.Size = new System.Drawing.Size(62, 16);
            this.lblImagen3.TabIndex = 5;
            this.lblImagen3.Text = "Imagen 3";
            // 
            // btnGuardarImagenes
            // 
            this.btnGuardarImagenes.Location = new System.Drawing.Point(26, 192);
            this.btnGuardarImagenes.Name = "btnGuardarImagenes";
            this.btnGuardarImagenes.Size = new System.Drawing.Size(90, 23);
            this.btnGuardarImagenes.TabIndex = 6;
            this.btnGuardarImagenes.Text = "Guardar";
            this.btnGuardarImagenes.UseVisualStyleBackColor = true;
            this.btnGuardarImagenes.Click += new System.EventHandler(this.btnGuardarImagenes_Click);
            // 
            // FrmAgregarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 227);
            this.Controls.Add(this.btnGuardarImagenes);
            this.Controls.Add(this.lblImagen3);
            this.Controls.Add(this.lblImagen2);
            this.Controls.Add(this.lblImagen1);
            this.Controls.Add(this.txtBoxImagen3);
            this.Controls.Add(this.txtBoxImagen2);
            this.Controls.Add(this.txtBoxImagen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAgregarImagen";
            this.Text = "Agregar Imagen";
            this.Load += new System.EventHandler(this.FrmAgregarImagen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxImagen1;
        private System.Windows.Forms.TextBox txtBoxImagen2;
        private System.Windows.Forms.TextBox txtBoxImagen3;
        private System.Windows.Forms.Label lblImagen1;
        private System.Windows.Forms.Label lblImagen2;
        private System.Windows.Forms.Label lblImagen3;
        private System.Windows.Forms.Button btnGuardarImagenes;
    }
}