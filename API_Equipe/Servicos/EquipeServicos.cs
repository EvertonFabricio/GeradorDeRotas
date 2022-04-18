using System.Collections.Generic;
using System.Threading.Tasks;
using API_Equipe.Util;
using MongoDB.Driver;
using Servicos;

namespace API_Equipe.Servicos
{
    public class EquipeServicos
    {
        private readonly IMongoCollection<Models.Equipe> _equipe;

        public EquipeServicos(IEquipeDatabase settings)
        {
            var equipe = new MongoClient(settings.ConnectionString);
            var database = equipe.GetDatabase(settings.DatabaseName);
            _equipe = database.GetCollection<Models.Equipe>(settings.EquipeCollectionName);
        }

        public List<Models.Equipe> Get() =>
            _equipe.Find(equipe => true).ToList();

        public Models.Equipe Get(string codigo) =>
            _equipe.Find(equipe => equipe.Codigo.ToUpper() == codigo.ToUpper()).FirstOrDefault();

        public Models.Equipe ChecarEquipe(string codigo) =>
            _equipe.Find(equipe => equipe.Codigo.ToUpper() == codigo.ToUpper()).FirstOrDefault();

        public async Task<Models.Equipe> CreateAsync(Models.Equipe equipe)
        {
            var retornoPessoa = await BuscaPessoa.GetPessoa(equipe.Pessoa.Nome);
            var retornoCidade = await BuscaCidade.GetCidade(equipe.Cidade.Nome);
            
            equipe.Codigo = equipe.Codigo.ToUpper();
            equipe.Pessoa = retornoPessoa;
            equipe.Cidade = retornoCidade;
                       
            _equipe.InsertOne(equipe);
            return equipe;
        }

        public void Update(string codigo, Models.Equipe upEquipe) =>
            _equipe.ReplaceOne(equipe => equipe.Codigo.ToUpper() == codigo.ToUpper(), upEquipe);

        public void Remove(string id) =>
            _equipe.DeleteOne(equipe => equipe.Id == id);

    }
}
