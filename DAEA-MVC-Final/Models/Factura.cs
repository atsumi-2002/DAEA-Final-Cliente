using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAEA_MVC_Final.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
        public int cancelado { get; set; }
        public int ClienteID { get; set; }
    }
}