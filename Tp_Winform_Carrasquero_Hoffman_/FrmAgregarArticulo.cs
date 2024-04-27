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
            Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            Imagen imagen = new Imagen();
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                arti.codigo = txtCodigo.Text;
                arti.nombre = txtNombre.Text;  
                arti.descripcion = txtDescripcion.Text;
                
                arti.marca= (Marca)cboMarca.SelectedItem;
                arti.categoria = (Categoria)cboCategoria.SelectedItem;
                arti.precio = decimal.Parse(txtPrecio.Text);

               // arti.imagen = new Imagen();
               // arti.imagen.UrlImagen = txtUrl.Text;
               // arti.imagen.idArticulo = 1;

                imagen.UrlImagen= txtUrl.Text;
                int ultimoIdArticulo = negocio.ObtenerUltimoId();
                int nuevoIdArticulo = ultimoIdArticulo + 1;
                imagen.idArticulo = nuevoIdArticulo;

                negocio.agregar(arti);
                imgNegocio.agregar(imagen);
                MessageBox.Show("Agregado correctamente");
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
                cboCategoria.DataSource = categorianegocio.listar();
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
    }
}
