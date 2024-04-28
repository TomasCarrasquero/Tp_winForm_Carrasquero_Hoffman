namespace Tp_Winform_Carrasquero_Hoffman_
{
    partial class MenuPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMenuPrincipal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.pbxLista = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLista)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.labelMenuPrincipal);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 132);
            this.panel1.TabIndex = 0;
            // 
            // labelMenuPrincipal
            // 
            this.labelMenuPrincipal.AutoSize = true;
            this.labelMenuPrincipal.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuPrincipal.Location = new System.Drawing.Point(337, 28);
            this.labelMenuPrincipal.Name = "labelMenuPrincipal";
            this.labelMenuPrincipal.Size = new System.Drawing.Size(358, 55);
            this.labelMenuPrincipal.TabIndex = 0;
            this.labelMenuPrincipal.Text = "Menú Principal";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 395);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 44);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Agregar articulo";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Location = new System.Drawing.Point(177, 395);
            this.btnDetalles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(160, 44);
            this.btnDetalles.TabIndex = 2;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(511, 395);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 44);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtBuscar.Location = new System.Drawing.Point(23, 462);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(415, 30);
            this.txtBuscar.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(461, 462);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 38);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(12, 183);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.RowTemplate.Height = 24;
            this.dgvLista.Size = new System.Drawing.Size(685, 187);
            this.dgvLista.TabIndex = 6;
            this.dgvLista.SelectionChanged += new System.EventHandler(this.dgvLista_SelectionChanged);
            // 
            // pbxLista
            // 
            this.pbxLista.Location = new System.Drawing.Point(739, 178);
            this.pbxLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxLista.Name = "pbxLista";
            this.pbxLista.Size = new System.Drawing.Size(349, 314);
            this.pbxLista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLista.TabIndex = 7;
            this.pbxLista.TabStop = false;
            
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(344, 395);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(160, 44);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 511);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.pbxLista);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMenuPrincipal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.PictureBox pbxLista;
        private System.Windows.Forms.Button btnEditar;
    }
}

