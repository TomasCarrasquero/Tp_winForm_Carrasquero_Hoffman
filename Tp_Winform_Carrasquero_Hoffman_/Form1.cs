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
        private List<Imagen> listaImagenes;
        private int indiceImagenActual = 0;
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
                cargarImagen(seleccionado.imagen.UrlImagen);

                CargarImagenesArticulo(seleccionado.id);
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
            if (listaArticulo.Any())
            {
                if (!string.IsNullOrWhiteSpace(listaArticulo[0].imagen.UrlImagen))
                {
                    return listaArticulo[0].imagen.UrlImagen;
                }
            }

            return imagenDefault;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el registro?", "eliminar registro", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ArticuloNegocio artiBusines = new ArticuloNegocio();
                artiBusines.eliminar(seleccionado);

                MessageBox.Show("El registro se ha eliminado con exito");

                CargarArticulos();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            FrmAgregarArticulo editar = new FrmAgregarArticulo(seleccionado);

            if (editar.ShowDialog() == DialogResult.OK)
            {
                CargarArticulos();
            }
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscar != null)
            {
                List<Articulo> filtrar = listaArticulo.FindAll(x => x.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                             x.marca.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                             x.codigo.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                             x.descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                             x.categoria.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                dgvLista.DataSource = filtrar;
            }
            else
            {
                dgvLista.DataSource = listaArticulo;
            }
        }
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            FrmDetalles detalle = new FrmDetalles(seleccionado);

            detalle.ShowDialog();
        }
        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            FrmMarca alta = new FrmMarca();

            if (alta.ShowDialog() == DialogResult.OK)
            {
                CargarArticulos();
            }
        }
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria alta = new FrmCategoria();

            if (alta.ShowDialog() == DialogResult.OK)
            {
                CargarArticulos();
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual + 1) % listaImagenes.Count;
                cargarImagen(listaImagenes[indiceImagenActual].UrlImagen);
            }

        }
            private void btnAnterior_Click(object sender, EventArgs e)
        {

            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual - 1 + listaImagenes.Count) % listaImagenes.Count;
                cargarImagen(listaImagenes[indiceImagenActual].UrlImagen);
            }
        }

        private void CargarImagenesArticulo(int idArticulo)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            listaImagenes = negocio.listar().Where(img => img.idArticulo == idArticulo).ToList();
            
            if (listaImagenes.Count > 0)
            {
                cargarImagen(listaImagenes[0].UrlImagen);
                indiceImagenActual = 0;
            }
            else
            {
                cargarImagen(imagenDefault);
            }
        }
    }
}
