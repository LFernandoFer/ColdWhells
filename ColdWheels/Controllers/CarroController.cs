using ColdWheels.Models;
using ColdWheels.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdWheels.Controllers
{
    class CarroController
{
        //Criar a instancia com a classe
        //DatabaseService
        private DatabaseService databaseService;

        //Criar a instancia para armazenar
        //a conexão do BD
        private SQLiteConnection connection;

        //Criar o método construtor
        public CarroController()
        {
            //Instanciar a databaseService
            databaseService =
                new DatabaseService();

            //Recuperar a conexão do BD
            connection =
                databaseService.GetConexao();

            connection.CreateTable<Carro>();
        }
        public bool Insert(Carro value)
        {
            return connection.Insert(value) > 0;
        }

        public bool Update(Carro value)
        {
            return connection.Update(value) > 0;
        }

        public bool Delete(Carro value)
        {
            return connection.Delete(value) > 0;
        }
        //Consultar para retornoar todos os dados
        public List<Carro> GetAll()
        {
            return
                connection.Table<Carro>().ToList();
        }

        //Consultar por ID
        public Carro GetById(int value)
        {
            return
                connection.Find<Carro>(value);
        }

        //Consulta filtrando pelo Nome
        public List<Carro> GetByNome(string value)
        {
            return
                connection.Table<Carro>().
                Where(x => x.Nome.Contains(value)).
                ToList();
        }
        public List<Carro> Filtrar(string nome = null, bool? obtido = null, bool? desejado = null)
        {
            
            var query = connection.Table<Carro>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(x => x.Nome.Contains(nome));
            }

            if (obtido.HasValue)
            {
                query = query.Where(x => x.Obtido == obtido.Value);
            }

            if (desejado.HasValue)
            {
                query = query.Where(x => x.Desejado == desejado.Value);
            }

            return query.ToList();
        }
    }
}

