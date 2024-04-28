using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using static System.Net.Mime.MediaTypeNames;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class FrmAgregarArticulo : Form
    {
        private Articulo articulo = null;

        public FrmAgregarArticulo()
        {
            InitializeComponent();
            btnAgregarImagenes.Visible = false;
        }

        public FrmAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();

            this.articulo = articulo;
            this.Text = "Modificar artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articuloOperar = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            List<string> resultado = ValidarArticulo();

            if (resultado.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, resultado.ToArray()));
                return;
            }

            try
            {
                if (articulo != null)
                {
                    articuloOperar.id = articulo.id;
                }

                articuloOperar.codigo = txtCodigo.Text;
                articuloOperar.nombre = txtNombre.Text;
                articuloOperar.descripcion = txtDescripcion.Text;
                articuloOperar.marca = (Marca)cboMarca.SelectedItem;
                articuloOperar.categoria = (Categoria)cboCategoria.SelectedItem;

                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    decimal precio = decimal.Parse(txtPrecio.Text);
                    articuloOperar.precio = decimal.Round(precio, 2);
                }

                if (articuloOperar.id > 0)
                {
                    negocio.modificar(articuloOperar);
                    
                    if (!string.IsNullOrWhiteSpace(txtUrl.Text))
                    {
                        negocio.agregarImagen(articuloOperar.id, txtUrl.Text);
                    }

                    MessageBox.Show("Modificado correctamente");
                }
                else
                {
                    if (!negocio.validarCodigoExistente(articuloOperar.codigo))
                    {
                        MessageBox.Show("El codigo ya existe");
                        return;
                    }

                    negocio.agregar(articuloOperar);

                    if (!string.IsNullOrWhiteSpace(txtUrl.Text))
                    {
                        int idArticulo = negocio.obtenerIdArticuloPorCodigo(txtCodigo.Text);
                        negocio.agregarImagen(idArticulo, txtUrl.Text);
                    }

                    MessageBox.Show("Agregado correctamente");
                }

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
                cboMarca.ValueMember = "id";
                cboMarca.DisplayMember = "nombre";
                cboMarca.SelectedIndex = 1;

                cboCategoria.DataSource = categorianegocio.listar();
                cboCategoria.ValueMember = "id";
                cboCategoria.DisplayMember = "nombre";
                cboCategoria.SelectedIndex = 1;

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.codigo;
                    txtNombre.Text = articulo.nombre;
                    txtDescripcion.Text = articulo.descripcion;
                    txtUrl.Text = articulo.imagen.UrlImagen;
                    txtPrecio.Text = Convert.ToString(articulo.precio);

                    cboMarca.SelectedValue = articulo.marca.id;
                    cboCategoria.SelectedValue = articulo.categoria.id;
                }
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

        private List<string> ValidarArticulo()
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

        private void btnAgregarImagenes_Click(object sender, EventArgs e)
        {
            Articulo articuloOperar = new Articulo();

            if (articulo != null)
            {
                articuloOperar.id = articulo.id;
            }

            if (articuloOperar.id > 0)
            {
                FrmAgregarImagen agregarImagen = new FrmAgregarImagen(articuloOperar);
                agregarImagen.ShowDialog();
            }
            else
            {
                FrmAgregarImagen agregarImagen = new FrmAgregarImagen();
                agregarImagen.ShowDialog();
            }


            //if (agregarImagen.ShowDialog() == DialogResult.OK)
            //{
            //}
        }
    }
}
