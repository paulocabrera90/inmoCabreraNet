using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inmoCabreraNet.Models
{
    public enum enTipos
    {
        Local = 1,
        Depósito = 2,
        Casa = 3,
        Depto = 4,
        Otros = 5
    }
    public enum enUsos
    {
        Comercial = 1,
        Residencial = 2
    }
    public class Inmueble
    {
        public int inm_id { get; set; }
        public string inm_direccion { get; set; }
        public int inm_tipo { get; set; }
        public int inm_uso { get; set; }
        public string UsoNombre => inm_uso > 0 ? ((enUsos)inm_uso).ToString() : "";
        public int inm_ambientes { get; set; }
        public decimal inm_precio { get; set; }
        public bool inm_disponible { get; set; }
        public string DisponibleNombre => inm_disponible ? "Sí" : "No";
        public int inm_pro_id { get; set; }

        public Propietario Propietario { get; set; }
    }
}