using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace inmoCabreraNet.Models {
    public class RepoContrato{
        string connectionString = "Server=localhost;User=paulo;Password=123456;Database=inmocabrera;SslMode=none";

        public RepoContrato(){}

        public IList<Contrato> All() {
            IList<Contrato> list = new List<Contrato>();
            
            return list;
        }
        
    }
}