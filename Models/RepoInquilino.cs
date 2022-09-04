using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace inmoCabreraNet.Models {
 public class RepoInquilino {
        //string connectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\\Users\\Ezequiel\\OneDrive\\ULP\\4to Cuatrimestre\\Programación .NET\\segunda_clase\\WebApplication1\\Data\\WebApp1.mdf";
        //string connectionString = "server=localhost;user=root;password=;database=inmobiliaria;SslMode=none";
        string connectionString = "Server=localhost;User=paulo;Password=123456;Database=inmocabrera;SslMode=none";
     

        public int Edit(Inquilino inq)
        {
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"UPDATE Inquilino SET inq_nombre = @nombre , inq_dni = @dni , inq_fechanac = @fecha_n , 
                            inq_domicilioTrabajo = @domicilio , inq_email = @email , inq_telef = @telefono 
                            WHERE inq_id = @id ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {

                    comm.Parameters.AddWithValue("@nombre", inq.inq_nombre);
                    comm.Parameters.AddWithValue("@dni", inq.inq_dni);
                    comm.Parameters.AddWithValue("@fecha_n", inq.inq_fechanac);
                    comm.Parameters.AddWithValue("@domicilio", inq.inq_domicilioTrabajo);
                    comm.Parameters.AddWithValue("@email", inq.inq_email);
                    comm.Parameters.AddWithValue("@telefono", inq.inq_telef);
                     comm.Parameters.AddWithValue("@id", inq.inq_id);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteNonQuery());
                    conn.Close();
                }
            }
            return res;
        }

        public int Delete(int id)
        {
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string delete = @"DELETE FROM Inquilino WHERE inq_id = @id ;";

                using (MySqlCommand comm = new MySqlCommand(delete, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteNonQuery());
                    conn.Close();
                }
            }
            return res;
        }


        public Inquilino Details(string dni)
        {
            Inquilino inq = new Inquilino();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT * 
                                FROM Inquilino WHERE Dni = @dni ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@dni", dni);

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        inq.inq_id = reader.GetInt32(0);
                        inq.inq_nombre = reader.GetString(1);
                        inq.inq_dni = reader.GetString(2);
                        inq.inq_fechanac = reader.GetDateTime(3);
                        inq.inq_domicilioTrabajo = reader.GetString(4);
                        inq.inq_email = reader.GetString(5);
                        inq.inq_telef = reader.GetString(6);
                    }

                    conn.Close();

                }
            }
            return inq;
        }
        public int Put(Inquilino inq)
        {
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Inquilino (inq_nombre, inq_dni, inq_fechaNac, inq_domicilioTrabajo, inq_email, inq_telef) 
                            VALUES(@nombre, @dni, @fecha_n, @domicilio, @email, @telefono);
                            SELECT LAST_INSERT_ID();";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", inq.inq_nombre);
                    comm.Parameters.AddWithValue("@dni", inq.inq_dni);
                    comm.Parameters.AddWithValue("@fecha_n", inq.inq_fechanac);
                    comm.Parameters.AddWithValue("@Domicilio", inq.inq_domicilioTrabajo);
                    comm.Parameters.AddWithValue("@email", inq.inq_email);
                    comm.Parameters.AddWithValue("@telefono", inq.inq_telef);

                    conn.Open();

                    res = Convert.ToInt32(comm.ExecuteScalar());
                    inq.inq_id = res;

                    conn.Close();
                }
            }
            return res;
        }

        public IList<Inquilino> All()
        {
            IList<Inquilino> list = new List<Inquilino>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT *
                                FROM Inquilino;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var p = new Inquilino
                        {
                            inq_id = reader.GetInt32(0),
                            inq_nombre = reader.GetString(1),
                            inq_dni = reader.GetString(2),
                            inq_fechanac = reader.GetDateTime(3),
                            inq_domicilioTrabajo = reader.GetString(4),
                            inq_email = reader.GetString(5),
                            inq_telef = reader.GetString(6),
                        };

                        list.Add(p);
                    }
                    conn.Close();
                }
            }
            return list;
        }
        public Inquilino FindByPrimaryKey(int id) {

            Inquilino inq = new Inquilino();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT *
                                FROM Inquilino WHERE inq_id = @id ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    
                    conn.Open();
                    
                    var reader = comm.ExecuteReader();
                    
                    if (reader.Read()) {

                        inq.inq_id = reader.GetInt32(0);
                        inq.inq_dni = reader.GetString(1);
                        inq.inq_nombre = reader.GetString(2);                        
                        inq.inq_fechanac = reader.GetDateTime(3);
                        inq.inq_domicilioTrabajo = reader.GetString(4);
                        inq.inq_telef = reader.GetString(5);
                        inq.inq_email = reader.GetString(6);
                    }
                    
                    conn.Close();
                }
            }

            return inq;
        }

        public Inquilino FindByPrimaryKey(string dni)
        {

            Inquilino inq = new Inquilino();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT * 
                                FROM Inquilino WHERE inq_dni = @dni ;";

                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@dni", dni);

                    conn.Open();

                    var reader = comm.ExecuteReader();

                    if (reader.Read())
                    {
                        inq.inq_id = reader.GetInt32(0);
                        inq.inq_nombre = reader.GetString(1);
                        inq.inq_dni = reader.GetString(2);
                        inq.inq_fechanac = reader.GetDateTime(3);
                        inq.inq_domicilioTrabajo = reader.GetString(4);
                        inq.inq_email = reader.GetString(5);
                        inq.inq_telef = reader.GetString(6);
                    }

                    conn.Close();
                }
            }

            return inq;
        }
    }

}