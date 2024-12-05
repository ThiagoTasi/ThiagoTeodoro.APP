using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ThiagoTeodoroClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ThiagoTeodoroClass
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }


        public Cliente()
        {
          
        }
        public Cliente(string nome, string email, string telefone, string endereco)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente(int idCliente, string nome, string email, string telefone, string endereco)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void Inserir()
        {


            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "cliente_insert";
            cmd.Parameters.AddWithValue("nome", Nome);
            cmd.Parameters.AddWithValue("email", Email);
            cmd.Parameters.AddWithValue("telefone", Telefone);
            cmd.Parameters.AddWithValue("endereco", Endereco);

            cmd.Connection.Close();

        }
        public static Cliente ObterPorId(int id)
        {
            Cliente cliente = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from clientes whre id = {id}";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cliente = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3),
                    dr.GetDouble(4)
                    );
            }
            return cliente;
        }
        public static List<Cliente> ObterPorLista()
        {
            List<Cliente> clientes = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from clientes ordr by descricao asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clientes.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4)

                    ));
            }
            return clientes;
        }
        public bool Alterar(Cliente cliente)

        {
            bool resposta = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "cliente_update";
            cmd.Parameters.AddWithValue("idcliente", IdCliente);
            cmd.Parameters.AddWithValue("nome", Nome);
            cmd.Parameters.AddWithValue("email", Email);
            cmd.Parameters.AddWithValue("telefone", Telefone);
            cmd.Parameters.AddWithValue("endereco", Endereco);

            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd.Connection.Close();
                return true;
            }
            return resposta;
        }
    }
}



