using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class FrmDetalles : Form
    {
        private Articulo articulo;
        private string imagenDefault = "https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg";
        public FrmDetalles()
        {
            InitializeComponent();
        }

        public FrmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmDetalles_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<string> imagenesAdicionales = new List<string>();

            txtNombreDetalle.Text = articulo.nombre;
            txtCodigoDetalle.Text = articulo.codigo;
            txtDescripcionDetalle.Text = articulo.descripcion;
            txtImagenDetalle.Text = articulo.imagen.UrlImagen;
            txtPrecioDetalle.Text = articulo.precio.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            txtCategoriaDetalle.Text = articulo.categoria.nombre;
            txtMarcaDetalle.Text = articulo.marca.nombre;

            cargarImagen(articulo.imagen.UrlImagen);

            imagenesAdicionales = negocio.obtenerImagenes(articulo.id);

            if (imagenesAdicionales.Any())
            {
                imagenesAdicionales = imagenesAdicionales.Skip(1).ToList();

                foreach (var imagen in imagenesAdicionales)
                {
                    if (string.IsNullOrWhiteSpace(pbxImagenAdicional1.ImageLocation))
                    {
                        cargarImagenAdicional(imagen, 1);
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(pbxImagenAdicional2.ImageLocation))
                    {
                        cargarImagenAdicional(imagen, 2);
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(pbxImagenAdicional3.ImageLocation))
                    {
                        cargarImagenAdicional(imagen, 3);
                        continue;
                    }
                }
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagenDetalle.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagenDetalle.Load(imagenDefault);
            }
        }

        private void cargarImagenAdicional(string imagen, int numeroImagen)
        {
            try
            {
                switch (numeroImagen)
                {
                    case 1:
                        pbxImagenAdicional1.Load(imagen);
                        break;
                    case 2:
                        pbxImagenAdicional2.Load(imagen);
                        break;

                    default:
                        pbxImagenAdicional3.Load(imagen);
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSalirDetalle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
