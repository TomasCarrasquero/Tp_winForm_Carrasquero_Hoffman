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
    public partial class MenuPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        private string imagenDefault = "https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg";
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.imagen);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxLista.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxLista.Load(imagenDefault);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo alta = new FrmAgregarArticulo();
            
            if (alta.ShowDialog() == DialogResult.OK) 
            {
                CargarArticulos();   
            }
        }

        private void CargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            listaArticulo = negocio.listar();
            dgvLista.DataSource = listaArticulo;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["imagen"].Visible = false;

            cargarImagen(ObtenerImagenDefault());
        }

        private string ObtenerImagenDefault()
        {
            if (listaArticulo.Any() && !string.IsNullOrWhiteSpace(listaArticulo[0].imagen))
            {
                return listaArticulo[0].imagen;
            }

            return imagenDefault;
        }
    }
}
