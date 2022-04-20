using System.Collections.Generic;
using API_Pessoa.Util;
using MongoDB.Driver;

namespace API_Pessoa.Servicos
{
    public class PessoaServicos
    {
        private readonly IMongoCollection<Models.Pessoa> _pessoa;

        public PessoaServicos(IPessoaDatabase settings)
        {
            var pessoa = new MongoClient(settings.ConnectionString);
            var database = pessoa.GetDatabase(settings.DatabaseName);
            _pessoa = database.GetCollection<Models.Pessoa>(settings.PessoaCollectionName);
        }

        public List<Models.Pessoa> Get() =>
            _pessoa.Find(pessoa => true).ToList();

        public Models.Pessoa Get(string id) =>
            _pessoa.Find(pessoa => pessoa.Id == id).FirstOrDefault();

        public Models.Pessoa GetNome(string nome) =>
          _pessoa.Find(pessoa => pessoa.Nome.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Pessoa ChecarPessoa(string nome) =>
            _pessoa.Find(pessoa => pessoa.Nome.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Pessoa Create(Models.Pessoa pessoa)
        {
            _pessoa.InsertOne(pessoa);
            return pessoa;
        }

        public void Update(string id, Models.Pessoa upPessoa)
        {
            upPessoa.Id = id;
            _pessoa.ReplaceOne(pessoa => pessoa.Id == id, upPessoa);

        }

        public void Remove(string id) =>
            _pessoa.DeleteOne(pessoa => pessoa.Id == id);


    }
}
