using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inmoCabreraNet.Models
{
    public class Propietario
    {
        public int pro_id { get; set; }
        public string pro_dni { get; set; }
        public string pro_nombre { get; set; }
        public DateTime pro_fechanac { get; set; }
        public string pro_direc { get; set; }
        public string pro_telef { get; set; }
        public string pro_email { get; set; }
    }
}