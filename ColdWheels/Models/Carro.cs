using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Diagnostics;
namespace ColdWheels.Models
{
    public class Carro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Lote { get; set; }
        public string Ano { get; set; }
        public  bool Obtido { get; set; }
        public bool Desejado { get; set; }
        public string DirImagem { get; set; }
    }
}
