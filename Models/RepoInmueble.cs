using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace inmoCabreraNet.Models {
    public class RepoInmueble{
        string connectionString = "Server=localhost;User=paulo;Password=123456;Database=inmocabrera;SslMode=none";

        public RepoInmueble(){}

        public IList<Inmueble> All() {
            IList<Inmueble> list = new List<Inmueble>();
            
            return list;
        }
        
    }
}