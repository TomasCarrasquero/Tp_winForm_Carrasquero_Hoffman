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
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvLista.DataSource = listaArticulo;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["imagen"].Visible = false;
            cargarImagen(listaArticulo[0].imagen);
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.imagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxLista.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxLista.Load("https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg");
            }
        }
    }
}
