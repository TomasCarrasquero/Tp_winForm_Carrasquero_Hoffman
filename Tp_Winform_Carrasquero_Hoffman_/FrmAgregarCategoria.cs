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
    public partial class FrmAgregarCategoria : Form
    {
        private CategoriaNegocio categorianegocio = new CategoriaNegocio();
        private Categoria categoria = null;

        public FrmAgregarCategoria()
        {
            InitializeComponent();
        }

        public FrmAgregarCategoria(Categoria categoria)
        {
            InitializeComponent();

            this.categoria = categoria;
            this.Text = "Modificar  Categoria";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para la categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (categorianegocio.Existencia(txtDescripcion.Text))
                {
                    MessageBox.Show("La categoria ya existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (categoria == null)
                {

                    categorianegocio.agregarCat(txtDescripcion.Text);
                    MessageBox.Show("Categoria agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    categoria.nombre = txtDescripcion.Text;
                    categorianegocio.modificar(categoria);
                    MessageBox.Show("Categoria modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar/modificar la Categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarCategoria_Load(object sender, EventArgs e)
        {
            if (categoria != null)
            {
                txtId.Text = categoria.id.ToString();
                txtDescripcion.Text = categoria.nombre;
            }
            else
            {
                txtId.Text = Convert.ToString(categorianegocio.ProximoID());
            }
        }
    }
}
