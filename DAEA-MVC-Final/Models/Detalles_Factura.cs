using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAEA_MVC_Final.Models
{
    public class Detalles_Factura
    {
        public int Detalles_FacturaID { get; set; }
        public string cantidad { get; set; }
        public string precio { get; set; }
        public int total { get; set; }
        public int ProductoID { get; set; }
        public int FacturaID { get; set; }
    }
}