using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        
        public int id { get; set; }
        public string codigo { get; set; }
        [DisplayName ("Nombre")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public Imagen imagen { get; set; }
        public decimal precio { get; set; }
    }
}
