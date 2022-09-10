using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inmoCabreraNet.Models
{
    public class Contrato
    {
         public int con_id { get; set; }
        public int con_inm_id { get; set; }
        public int con_inq_id { get; set; }
        public DateTime con_fecdesde { get; set; }
        public DateTime con_fechasta { get; set; }
        public string con_dniGarante { get; set; }
        public string con_nombreGarante { get; set; }
        public string con_telefonoGarante { get; set; }
        public string con_emailGarante { get; set; }
        public bool con_valido { get; set; }

        public string ValidoNombre => con_valido ? "Sí" : "No";

        //Relaciones
        public Inmueble Inmueble { get; set; }
        public Inquilino Inquilino { get; set; }
    }
}