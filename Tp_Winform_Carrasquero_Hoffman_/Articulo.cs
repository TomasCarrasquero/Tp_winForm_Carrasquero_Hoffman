using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tp_Winform_Carrasquero_Hoffman_
{
    public class Articulo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public decimal precio { get; set; }
    }
}
