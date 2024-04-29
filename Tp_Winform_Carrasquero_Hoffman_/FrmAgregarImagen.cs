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
using static System.Net.Mime.MediaTypeNames;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class FrmAgregarImagen : Form
    {
        private Articulo articuloOperar;
        private List<string> imagenes;
        public FrmAgregarImagen()
        {
            InitializeComponent();
        }

        public FrmAgregarImagen(Articulo articulo)
        {
            InitializeComponent();
            articuloOperar = articulo;
        }

        private void FrmAgregarImagen_Load(object sender, EventArgs e)
        {
            CargarImagenes();
        }

        private void CargarImagenes()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (articuloOperar != null)
            {
                imagenes = negocio.obtenerImagenes(articuloOperar.id);

                if (imagenes.Any())
                {
                    imagenes = imagenes.Skip(1).ToList();

                    foreach (var imagen in imagenes)
                    {
                        if (string.IsNullOrWhiteSpace(txtBoxImagen1.Text))
                        {
                            txtBoxImagen1.Text = imagen;
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(txtBoxImagen2.Text))
                        {
                            txtBoxImagen2.Text = imagen;
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(txtBoxImagen3.Text))
                        {
                            txtBoxImagen3.Text = imagen;
                            continue;
                        }
                    }
                }
            }
        }

        private void btnGuardarImagenes_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<int> imagenes = negocio.obtenerImagenesSinPrincipal(articuloOperar.id);

            foreach (var imagen in imagenes)
            {
                negocio.eliminarImagen(imagen);
            }

            if (!string.IsNullOrWhiteSpace(txtBoxImagen1.Text))
            {
                negocio.agregarImagen(articuloOperar.id, txtBoxImagen1.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtBoxImagen2.Text))
            {
                negocio.agregarImagen(articuloOperar.id, txtBoxImagen2.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtBoxImagen3.Text))
            {
                negocio.agregarImagen(articuloOperar.id, txtBoxImagen3.Text);
            }

            MessageBox.Show("Imagenes procesadas correctamente");
            Close();
        }
    }
}
