using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inmoCabreraNet.Models
{
    public class Inquilino
    {
        public int inq_id { get; set; }
        public string inq_dni { get; set; }
        public string inq_nombre { get; set; }
        public DateTime inq_fechanac { get; set; }
        public string inq_domicilioTrabajo { get; set; }
        public string inq_telef { get; set; }
        public string inq_email { get; set; }

        // Garante
       // public string DniGarante { get; set; }
//        public string NombreGarante { get; set; }
     //   public string TelefonoGarante { get; set; }
    //    public string EmailGarante { get; set; }
    }
}