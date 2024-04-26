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

            try
            {
                arti.codigo = txtCodigo.Text;
                arti.nombre = txtNombre.Text;  
                arti.descripcion = txtDescripcion.Text;
                arti.imagen = txtUrl.Text;
                arti.precio = decimal.Parse(txtPrecio.Text);

                negocio.agregar(arti);
                MessageBox.Show("Agregado correctamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
