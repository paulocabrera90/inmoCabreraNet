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
              using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                    i.inm_id, 
                                    i.inm_direccion, 
                                    i.inm_tipo, 
                                    i.inm_uso, 
                                    i.inm_ambientes, 
                                    i.inm_precio, 
                                    i.inm_disponible, 
                                    i.inm_pro_idinmueble, 
                                    p.pro_nombre, 
                                    p.pro_dni, 
                                    p.pro_email 
                               FROM Inmueble i 
                               INNER JOIN Propietario p
                                ON i.IdPropietario = p.Id;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var inm = new Inmueble {

                            inm_id = reader.GetInt32(0),
                            inm_direccion = reader.GetString(1),
                            inm_tipo = reader.GetInt32(2),
                            inm_uso = reader.GetInt32(3),
                            inm_ambientes = reader.GetInt32(4),
                            inm_precio = reader.GetDecimal(5),
                            inm_disponible = reader.GetBoolean(6),
                            inm_pro_id = reader.GetInt32(7),
                        };

                        var pro = new Propietario {
                            pro_id = reader.GetInt32(7),
                            pro_nombre = reader.GetString(8),
                            pro_dni = reader.GetString(9),
                            pro_email = reader.GetString(10),
                        };
                        
                        inm.propietario = pro;

                        list.Add(inm);
                    }
                    conn.Close();
                }
            }
            return list;
        }
        
    }
}