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
            cargar();
    
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulo = negocio.listar();
                dgvLista.DataSource = listaArticulo;
                dgvLista.Columns["id"].Visible = false;
                dgvLista.Columns["imagen"].Visible = false;
                //cargarImagen(listaArticulo[0].imagen);
                cargarImagen(listaArticulo[0].imagen.UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.imagen.UrlImagen);
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
                pbxLista.Load("https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo alta = new FrmAgregarArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow != null)
            {
                Articulo seleccionado;
                seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

                FrmAgregarArticulo editar = new FrmAgregarArticulo(seleccionado);
                editar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}
