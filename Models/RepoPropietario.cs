using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace inmoCabreraNet.Models {
    public class RepoPropietario {
         string connectionString = "Server=localhost;User=paulo;Password=123456;Database=inmocabrera;SslMode=none";

         public RepoPropietario(){}

         public IList<Propietario> All() {
            IList<Propietario> list = new List<Propietario>();
            using (MySqlConnection conn = new MySqlConnection(connectionString)){
                string sql = @"SELECT * FROM propietario";

                 using (MySqlCommand comm = new MySqlCommand(sql, conn)) {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read()) {
                        var pro = new Propietario {
                            pro_id = reader.GetInt32(0),
                            pro_nombre = reader.GetString(1),
                            pro_dni= reader.GetString(2),
                            pro_fechanac = reader.GetDateTime(3),
                            pro_direc = reader.GetString(4),
                            pro_email = reader.GetString(5),
                            pro_telef = reader.GetString(6)
                        };

                        list.Add(pro);
                    }
                    conn.Close();
                }
            }
            return list;
        }

        public int Put(Propietario pro){
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString)){
                string sql = @"INSERT INTO propietario (pro_nombre, pro_dni, pro_fechanac, pro_direc, pro_email, pro_telef) 
                            VALUES(@nombre, @dni, @fecha_n, @domicilio, @email, @telefono);
                            SELECT LAST_INSERT_ID();";

                using (MySqlCommand comm = new MySqlCommand(sql, conn)) {
                    comm.Parameters.AddWithValue("@nombre", pro.pro_nombre);
                    comm.Parameters.AddWithValue("@dni", pro.pro_dni);
                    comm.Parameters.AddWithValue("@fecha_n", pro.pro_fechanac);
                    comm.Parameters.AddWithValue("@Domicilio", pro.pro_direc);
                    comm.Parameters.AddWithValue("@email", pro.pro_email);
                    comm.Parameters.AddWithValue("@telefono", pro.pro_telef);

                    conn.Open();

                    res = Convert.ToInt32(comm.ExecuteScalar());
                    pro.pro_id = res;

                    conn.Close();
                }
            }
            return res;
        }
      
        public int Delete(int pro_id) {
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"DELETE FROM propietario WHERE pro_id = @id ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id", pro_id);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteNonQuery());
                    conn.Close();
                }
            }
            return res;
        }

          public Propietario FindByPrimaryKey(int id) {

            Propietario pro = new Propietario();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Propietario WHERE pro_id = @id ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    
                    conn.Open();
                    
                    var reader = comm.ExecuteReader();
                    
                    if (reader.Read()) {
                        pro.pro_id = reader.GetInt32(0);
                        pro.pro_dni = reader.GetString(1);
                        pro.pro_nombre = reader.GetString(2);
                        pro.pro_fechanac = reader.GetDateTime(3);
                        pro.pro_direc = reader.GetString(4);
                        pro.pro_telef = reader.GetString(5);
                        pro.pro_email = reader.GetString(6);
                    }
                    
                    conn.Close();
                }
            }

            return pro;
        }
    }
    
}