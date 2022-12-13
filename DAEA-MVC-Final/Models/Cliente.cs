using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAEA_MVC_Final.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
    }
}