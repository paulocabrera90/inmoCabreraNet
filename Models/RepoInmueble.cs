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
                                    inm.inm_id, 
                                    inm.inm_direccion, 
                                    inm.inm_tipo, 
                                    inm.inm_uso, 
                                    inm.inm_ambientes, 
                                    inm.inm_precio, 
                                    inm.inm_disponible, 
                                    inm.inm_pro_id, 
                                    pro.pro_nombre, 
                                    pro.pro_dni, 
                                    pro.pro_email 
                               FROM Inmueble inm
                               INNER JOIN Propietario pro
                                ON inm.inm_pro_id = pro.pro_id;";

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
                            inm_precio = reader.GetDouble(5),
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

        public Inmueble FindByPrimaryKey(int id) {
            Inmueble inm = new Inmueble();
            Propietario pro = new Propietario();
            
            using (MySqlConnection conn = new MySqlConnection(connectionString)){
                string sql = @"SELECT 
                                    inm.inm_id, 
                                    inm.inm_direccion, 
                                    inm.inm_tipo, 
                                    inm.inm_uso, 
                                    inm.inm_ambientes, 
                                    inm.inm_precio, 
                                    inm.inm_disponible, 
                                    inm.inm_pro_id, 
                                    pro.pro_nombre, 
                                    pro.pro_dni, 
                                    pro.pro_email 
                               FROM Inmueble inm
                               INNER JOIN Propietario pro
                                ON inm.inm_pro_id = pro.pro_id
                                WHERE inm.inm_id = @id;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn)){
                    comm.Parameters.AddWithValue("@id", id);

                    conn.Open();

                    var reader = comm.ExecuteReader();

                    if(reader.Read()){
                        inm.inm_id = reader.GetInt32(0);
                        inm.inm_direccion = reader.GetString(1);
                        inm.inm_tipo = reader.GetInt32(2);
                        inm.inm_uso = reader.GetInt32(3);
                        inm.inm_ambientes = reader.GetInt32(4);
                        inm.inm_precio = reader.GetDouble(5);
                        inm.inm_disponible = reader.GetBoolean(6);
                        inm.inm_pro_id = reader.GetInt32(7);
                        pro.pro_nombre = reader.GetString(8);
                        pro.pro_dni = reader.GetString(9);
                        pro.pro_email = reader.GetString(10);
                        inm.propietario = pro;
                    }
                }
            }
           
            return inm;
        }
        
        public bool isTaken(int id){
            bool flag= false;

            string sql = @"SELECT 
                            con.con_id 
                        FROM contrato con 
                        WHERE 
                            con.con_inm_id = @id 
                            AND con.con_valido = 1 
                            AND current_date() 
                            BETWEEN con.con_fecdesde 
                            AND con.con_fechasta;";

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                using (MySqlCommand comm = new MySqlCommand(sql, conn)) {
                    comm.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    flag = (reader.HasRows) ? true : false;
                    conn.Close();
                }
            }

            return flag;
        }
    
        public int Edit (Inmueble inm, bool isTaken){
            int res =-1;

            string sql = @"UPDATE inmueble
                                SET 
                                    inm_direccion = @direccion,
                                    inm_tipo = @tipo,
                                    inm_uso = @uso,
                                    inm_ambientes = @ambientes,
                                    inm_precio = @precio,
                                    inm_disponible = @disponible
                                    inm_pro_id = @pro_id
                                WHERE inm_id = @id;";
            if(isTaken){
                     sql = @"UPDATE inmueble
                                SET 
                                    inm_direccion = @direccion,
                                    inm_tipo = @tipo,
                                    inm_uso = @uso,
                                    inm_ambientes = @ambientes,
                                    inm_precio = @precio,
                                    inm_pro_id = @pro_id
                                WHERE inm_id = @id;";
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString)){
                 using (MySqlCommand comm = new MySqlCommand(sql, conn)){
                     comm.Parameters.AddWithValue("@direccion", inm.inm_direccion);
                    comm.Parameters.AddWithValue("@tipo", inm.inm_tipo);
                    comm.Parameters.AddWithValue("@uso", inm.inm_uso);
                    comm.Parameters.AddWithValue("@ambientes", inm.inm_ambientes);
                    comm.Parameters.AddWithValue("@precio", inm.inm_precio);
                    comm.Parameters.AddWithValue("@id_propietario",inm.inm_pro_id);
                    comm.Parameters.AddWithValue("@id", inm.inm_id);
                    if (!isTaken)
                    {
                        comm.Parameters.AddWithValue("@disponible", inm.inm_disponible);
                    }

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteNonQuery());
                    conn.Close();
                 }
            }
            return res;
        }
    
    }
}