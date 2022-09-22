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
         public string tipoNombre => inm_tipo > 0 ? ((enTipos)inm_tipo).ToString() : "";
        public int inm_uso { get; set; }
        public string usoNombre => inm_uso > 0 ? ((enUsos)inm_uso).ToString() : "";
        public int inm_ambientes { get; set; }
        public decimal inm_precio { get; set; }
        public bool inm_disponible { get; set; }
        public string disponibleNombre => inm_disponible ? "Sí" : "No";
        public int inm_pro_id { get; set; }

        public Propietario propietario { get; set; }

        public static IDictionary<int, string> ObtenerTipos(){
           SortedDictionary<int, string> tipos = new SortedDictionary<int, string>();
           Type tipoEnumTipo = typeof(enTipos);
           foreach (var valor in Enum.GetValues(tipoEnumTipo)){
                tipos.Add((int)valor, Enum.GetName(tipoEnumTipo, valor));
           }
           return tipos;
        }

        public static IDictionary<int, string> ObtenerUsos(){
           SortedDictionary<int, string> usos = new SortedDictionary<int, string>();
           Type tipoEnumUso = typeof(enUsos);
           foreach (var valor in Enum.GetValues(tipoEnumUso)){
                usos.Add((int)valor, Enum.GetName(tipoEnumUso, valor));
           }
           return usos;
        }
    }
}