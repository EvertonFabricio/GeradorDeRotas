using System.Collections.Generic;
using System.Threading.Tasks;
using API_Equipe.Util;
using Models;
using MongoDB.Driver;
using Servicos;

namespace API_Equipe.Servicos
{
    public class EquipeServicos
    {
        private readonly IMongoCollection<Equipe> _equipe;

        public EquipeServicos(IEquipeDatabase settings)
        {
            var equipe = new MongoClient(settings.ConnectionString);
            var database = equipe.GetDatabase(settings.DatabaseName);
            _equipe = database.GetCollection<Equipe>(settings.EquipeCollectionName);
        }

        //buscar todas as equipes
        public List<Equipe> Get() =>
            _equipe.Find(equipe => true).ToList();
               
        //buscar equipe pelo id
        public Equipe GetId(string id) =>
           _equipe.Find(equipe => equipe.Id == id).FirstOrDefault();

        //buscar equipe pelo codigo
        public Equipe GetCodigo(string codigo) =>
           _equipe.Find(equipe => equipe.Codigo.ToUpper() == codigo.ToUpper()).FirstOrDefault();

       
        //buscar equipe pelo id da cidade
        public List<Equipe> GetCidadeId(string id) =>
          _equipe.Find(equipe => equipe.Cidade.Id == id).ToList();

        //checar se a equipe existe
        public Models.Equipe ChecarEquipe(string codigo) =>
            _equipe.Find(equipe => equipe.Codigo.ToUpper() == codigo.ToUpper()).FirstOrDefault();

         //criar equipe
        public async Task<Equipe> CreateAsync(Equipe equipe)
        {


            var retornoPessoa = new List<Pessoa>();

            foreach (var item in equipe.Pessoa)
            {
                Pessoa pessoa = await BuscaPessoa.BuscarPessoaPeloNome(item.Nome);
                retornoPessoa.Add(pessoa);
            }


            var retornoCidade = await BuscaCidade.BuscarCidadePeloNome(equipe.Cidade.Nome);

            equipe.Codigo = equipe.Codigo.ToUpper();
            equipe.Pessoa = retornoPessoa;
            equipe.Cidade = retornoCidade;

            _equipe.InsertOne(equipe);
            return equipe;
        }

        //atualizar equipe
        public async Task<Equipe> Update(string id, Equipe upEquipe)
        {
            upEquipe.Id = id;

            if (upEquipe.Pessoa != null)
            {
                var retornoPessoa = new List<Pessoa>();

                foreach (var item in upEquipe.Pessoa)
                {
                    Pessoa pessoa = await BuscaPessoa.BuscarPessoaPeloNome(item.Nome);
                    retornoPessoa.Add(pessoa);
                }
                upEquipe.Pessoa = retornoPessoa;
            }

            if (upEquipe.Cidade.Nome != null)
            {
                var retornoCidade = await BuscaCidade.BuscarCidadePeloNome(upEquipe.Cidade.Nome);
                upEquipe.Cidade = retornoCidade;
            }

            if (upEquipe.Codigo == null)
            {
                var codigo = GetId(id);
                upEquipe.Codigo = codigo.Codigo.ToUpper();
            }
            if (upEquipe.Codigo != null)
            {
                upEquipe.Codigo = upEquipe.Codigo.ToUpper();
            }



            _equipe.ReplaceOne(equipe => equipe.Id == id, upEquipe);

            return upEquipe;
        }

        //remover equipe
        public void Remove(string id) =>
            _equipe.DeleteOne(equipe => equipe.Id == id);

    }
}
