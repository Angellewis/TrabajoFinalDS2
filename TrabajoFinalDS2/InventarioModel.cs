using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalDS2
{
    public class InventarioModel
    {
        public Guid Id { get; set; }
        public int Seq { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
