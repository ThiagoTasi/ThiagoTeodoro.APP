using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiagoTeodoroClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ThiagoTeodoroClass
{
    public class Placa
    {
        public Placa(int idPlaca, string tipo, string tamanho, string preco)
        {
            IdPlaca = idPlaca;
            Tipo = tipo;
            Tamanho = tamanho;
            Preco = preco;

        }
        public int IdPlaca { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public string Preco { get; set; }

        public void Inserir()
        {
            var cmd = banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Insert placa values(int,'" + Tipo + "','" + Tamanho + "','" + Preco + "')";
            IdPlaca = cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@identify";


        }
        public List<Placa> ListarPlacas()

        {
            List<Placa> lista = new List<Placa>();
            var cmd = banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            return lista;
        }
        public void ConsultarPorId(int id)
        {
            var cmd = banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from placas where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IdPlaca = dr.GetInt32(0);
                Tipo = dr.GetString(1);
                Tamanho = dr.GetString(2);
                Preco = dr.GetString(3);

            }
        }

    }
    public void Alterar(Placa placa)
    {
        var cmd = banco.Abrir();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "update placa set tipo='" + placa.Tipo + "', tamanho='" + placa.Tamanho + "',preco='" + placa.Preco + "'where id = +placa.Id;";
        cmd.ExecuteNonQuery();
    }
}
