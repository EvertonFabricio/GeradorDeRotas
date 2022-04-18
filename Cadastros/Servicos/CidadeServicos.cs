using System.Collections.Generic;
using API_Cidade.Util;
using MongoDB.Driver;

namespace API_Cidade.Servicos
{
    public class CidadeServicos
    {
        private readonly IMongoCollection<Models.Cidade> _cidade;

        public CidadeServicos(ICidadeDatabase settings)
        {
            var cidade = new MongoClient(settings.ConnectionString);
            var database = cidade.GetDatabase(settings.DatabaseName);
            _cidade = database.GetCollection<Models.Cidade>(settings.CidadeCollectionName);
        }

        public List<Models.Cidade> Get() =>
            _cidade.Find(cidade => true).ToList();

        public Models.Cidade Get(string id) =>
            _cidade.Find(cidade => cidade.Id == id).FirstOrDefault();

        public Models.Cidade GetNome(string nome) =>
           _cidade.Find(cidade => cidade.Nome.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Cidade ChecarCidade(string nome) =>
            _cidade.Find(cidade => cidade.Nome.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Cidade Create(Models.Cidade cidade)
        {
            _cidade.InsertOne(cidade);
            return cidade;
        }

        public void Update(string id, Models.Cidade upCidade) =>
            _cidade.ReplaceOne(cidade => cidade.Id == id, upCidade);

        public void Remove(string id) =>
            _cidade.DeleteOne(cidade => cidade.Id == id);
    }
}
