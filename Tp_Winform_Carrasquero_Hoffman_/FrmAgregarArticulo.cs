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
    public partial class FrmAgregarArticulo : Form
    {
        private object pbxLista;

        private Articulo articulo = null;

        public FrmAgregarArticulo()
        {
            InitializeComponent();
        }
        public FrmAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            Imagen imagen = new Imagen();
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                if(articulo == null)
                    articulo = new Articulo();

                articulo.codigo = txtCodigo.Text;
                if (!soloNumeros(articulo.codigo))
                {
                    MessageBox.Show("Por favor, ingrese solo números en el campo de código.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                articulo.nombre = txtNombre.Text;
                articulo.descripcion = txtDescripcion.Text;

                articulo.marca= (Marca)cboMarca.SelectedItem;
                articulo.categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.precio = decimal.Parse(txtPrecio.Text);

        
                imagen.UrlImagen= txtUrl.Text;
                int ultimoIdArticulo = negocio.ObtenerUltimoId();
                int nuevoIdArticulo = ultimoIdArticulo + 1;
                imagen.idArticulo = nuevoIdArticulo;

                if(articulo.id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado correctamente");

                }
                else
                {
                    negocio.agregar(articulo);
                    imgNegocio.agregar(imagen);
                    MessageBox.Show("Agregado correctamente");
                }
             
                Close();

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
                cboCategoria.DataSource = categorianegocio.listar();
                cboCategoria.ValueMember = "id";
                cboCategoria.DisplayMember = "nombre";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.codigo;
                    txtNombre.Text = articulo.nombre;
                    txtDescripcion.Text = articulo.descripcion;
                    // falta cargar imagen
                    cboMarca.SelectedValue = articulo.marca.id;
                    cboCategoria.SelectedValue = articulo.categoria.id;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                
                pbx_art_nuevo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbx_art_nuevo.Load("https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg");
            }
        }
        private bool soloNumeros(string cadena)
        {
                foreach (char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                        return false;
            }
            return true;
        }


    }
}
