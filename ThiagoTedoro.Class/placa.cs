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
    public class Placa
    {
        public int IdPlaca { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public string Preco { get; set; }


        public Placa()
        {
           
        }

        public Placa(string tipo, string tamanho, string preco)
        {

            Tipo = tipo;
            Tamanho = tamanho;
            Preco = preco;

        }

        public Placa(int idPlaca, string tipo, string tamanho, string preco)
        {
            IdPlaca = idPlaca;
            Tipo = tipo;
            Tamanho = tamanho;
            Preco = preco;

        }

        public void Inserir()
        {


            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "placa_insert";
            cmd.Parameters.AddWithValue("tipo", Tipo);
            cmd.Parameters.AddWithValue("tamanho", Tamanho);
            cmd.Parameters.AddWithValue("preco", Preco);
            cmd.Connection.Close();

        }
        public static Placa ObterPorId(int id)
        {
            Placa placa = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from placas whre id = {id}";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                placa = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3)
                    );
            }
            return placa;
        }
        public static List<Placa> ObterPorLista()
        {
            List<Placa> placas = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from placas ordr by descricao asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                placas.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3)

                    ));
            }
            return placas;
        }
        public bool Alterar(Placa placa)

        {
            bool resposta = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "placa_update";
            cmd.Parameters.AddWithValue("idplaca", IdPlaca);
            cmd.Parameters.AddWithValue("tipo", Tipo);
            cmd.Parameters.AddWithValue("tamanho", Tamanho);
            cmd.Parameters.AddWithValue("preco", Preco);

            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd.Connection.Close();
                return true;
            }
            return resposta;
        }
    }
}
