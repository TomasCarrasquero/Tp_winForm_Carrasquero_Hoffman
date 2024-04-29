using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public partial class FrmCategoria : Form
    {
        private List<Categoria> listaCategoria;
        public FrmCategoria()
        {
            InitializeComponent();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CargarCategoria();
        }
        private void CargarCategoria()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            listaCategoria = negocio.listar();
            dgvCategoria.DataSource = listaCategoria;

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
        
           FrmAgregarCategoria alta = new FrmAgregarCategoria();

            if (alta.ShowDialog() == DialogResult.OK)
            {
                CargarCategoria();
            }
             
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Categoria seleccionado = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

            FrmAgregarCategoria editar = new FrmAgregarCategoria(seleccionado);

            if (editar.ShowDialog() == DialogResult.OK)
            {
                CargarCategoria();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;

            }
            Categoria seleccionado = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el registro?", "eliminar registro", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CategoriaNegocio categorianegocio = new CategoriaNegocio();
                categorianegocio.eliminar(seleccionado.id);

                MessageBox.Show("El registro se ha eliminado con exito");

                CargarCategoria();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
