using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class frmAgregarMarca : Form
    {
        private MarcaNegocio marcanegocio = new MarcaNegocio();
        public frmAgregarMarca()
        {
            InitializeComponent();
        }



        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregarMarca_Load(object sender, EventArgs e)
        {
            txtId.Text = Convert.ToString(marcanegocio.ProximoID());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                if (marcanegocio.Existencia(txtDescripcion.Text))
                {
                    MessageBox.Show("La marca ya existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                marcanegocio.agregarMar(txtDescripcion.Text);
                MessageBox.Show("Marca agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
