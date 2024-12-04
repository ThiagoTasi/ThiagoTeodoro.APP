using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiagoTeodoroClass;
using static Mysqlx.Notice.Warning.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ThiagoTeodoroClass
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public void Inserir(string connectionString) // Assuming connection string is passed
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var cmd = new SqlCommand("Insert into cliente (Nome, Email, Telefone) values (@nome, @email, @telefone)", connection))
                {
                    cmd.Parameters.AddWithValue("@nome", Nome);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@telefone", Telefone);

                    IdCliente = cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> ListarClientes(string connectionString)
        {
            List<Cliente> lista = new List<Cliente>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var cmd = new SqlCommand("select * from cliente", connection))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                IdCliente = dr.GetInt32(0),
                                Nome = dr.GetString(1),
                                Email = dr.GetString(2),
                                Telefone = dr.GetString(3)
                            });
                        }
                    }
                }
            }

            return lista;
            public void ConsultarPorId(int id, string connectionString)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = new SqlCommand("select * from cliente where id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                IdCliente = dr.GetInt32(0);
                                Nome = dr.GetString(1);
                                Email = dr.GetString(2);
                                Telefone = dr.GetString(3);
                            }
                        }
                    }
                }
            }

            public void Alterar(string connectionString)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = new SqlCommand("update cliente set nome=@nome, email=@email, telefone=@telefone where id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", IdCliente);
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@telefone", Telefone);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}




