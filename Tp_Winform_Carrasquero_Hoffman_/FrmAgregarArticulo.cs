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
using static System.Net.Mime.MediaTypeNames;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class FrmAgregarArticulo : Form
    {
        public FrmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            List<string> resultado = ValidarAregarArticulo();

            if (resultado.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, resultado.ToArray()));
                return;
            }

            try
            {
                articulo.codigo = txtCodigo.Text;
                articulo.nombre = txtNombre.Text;  
                articulo.descripcion = txtDescripcion.Text;
                articulo.imagen = txtUrl.Text;
                articulo.marca= (Marca)cboMarca.SelectedItem;
                articulo.categoria = (Categoria)cboCategoria.SelectedItem;

                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    articulo.precio = decimal.Parse(txtPrecio.Text);
                }

                negocio.agregar(articulo);
                MessageBox.Show("Agregado correctamente");
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmAgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcanegocio = new MarcaNegocio();
            CategoriaNegocio categorianegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcanegocio.listar();
                cboCategoria.DataSource = categorianegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private List<string> ValidarAregarArticulo()
        {
            List<string> errores = new List<string>();
            
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                errores.Add("El codigo es Requerido");
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errores.Add("El nombre es Requerido");
            }

            return errores;
        }

        private void m(object sender, EventArgs e)
        {

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(txtUrl.Text);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg");
            }
        }
    }
}
