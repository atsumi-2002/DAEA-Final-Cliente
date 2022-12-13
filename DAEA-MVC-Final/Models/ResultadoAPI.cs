using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAEA_MVC_Final.Models
{
    public class ResultadoAPI
    {
        public string mensaje { get; set; }
        public List<Cliente> ListaC { get; set; }
        public List<Detalles_Factura> ListaD { get; set; }
        public List<Factura> ListaF { get; set; }
        public List<Producto> ListaP { get; set; }
        public Cliente Cliente { get; set; }
        public Detalles_Factura Detalles_Factura { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}