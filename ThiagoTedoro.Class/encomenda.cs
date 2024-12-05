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
    public class Encomenda
    {
        public int IdEncomenda { get; set; }
        Cliente cliente { get; set; }
        public DateTime Data_encomenda { get; set; }
        public string Status { get; set; }
        public DateTime Data_entrega { get; set; }
        public string Endereco { get; set; }


        public Encomenda()
        {

        }
        public Encomenda(Cliente cliente, DateTime data_encomenda, string status, DateTime data_entrega, string endereco)
        {
            Cliente = cliente;
            Data_encomenda = data_encomenda;
            Status = status;
            Data_entrega = data_entrega;
            Endereco = endereco;
        }

        public Encomenda(int idEncomenda, Cliente cliente, DateTime data_encomenda, string status, DateTime data_entrega, string endereco)
        {
            IdEncomenda = idEncomenda;
            Cliente = cliente;
            Data_encomenda = data_encomenda;
            Status = status;
            Data_entrega = data_entrega;
            Endereco = endereco;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "encomenda_insert";
            cmd.Parameters.AddWithValue("cliente_id", Cliente_id);
            cmd.Parameters.AddWithValue("data_encomenda", Data_encomenda);
            cmd.Parameters.AddWithValue("status", Status);
            cmd.Parameters.AddWithValue("data_entrega", Data_entrega);

            cmd.Connection.Close();

        }
        public static Encomenda ObterPorId(int id)
        {
            Encomenda encomenda = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from encomendas whre id = {id}";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                encomenda = new(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetDate(2),
                    dr.GetString(3),
                    dr.GetData(4),
                    dr.GetString(5)
                    );
            }
            return encomenda;
        }
        public static List<Encomenda> ObterPorLista()
        {
            List<Encomenda> encomendas = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from encomendas order by descricao asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                encomendas.Add(new(
                   dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetDate(2),
                    dr.GetString(3),
                    dr.GetData(4),
                    dr.GetString(5)

                    ));
            }
            return encomendas;
        }
        public bool Alterar(Encomenda encomenda)

        {
            bool resposta = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "encomenda_update";
            cmd.Parameters.AddWithValue("cliente_id", Cliente_id);
            cmd.Parameters.AddWithValue("data_encomenda", Data_encomenda);
            cmd.Parameters.AddWithValue("status", Status);
            cmd.Parameters.AddWithValue("data_entrega", Data_entrega);

            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd.Connection.Close();
                return true;
            }
            return resposta;
        }
    }
}