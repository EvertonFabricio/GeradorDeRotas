using System.Collections.Generic;
using API_Usuario.Util;
using MongoDB.Driver;

namespace API_Usuario.Servicos
{
    public class UsuarioServicos
    {
        private readonly IMongoCollection<Models.Usuario> _usuario;

        public UsuarioServicos(IUsuarioDatabase settings)
        {
            var usuario = new MongoClient(settings.ConnectionString);
            var database = usuario.GetDatabase(settings.DatabaseName);
            _usuario = database.GetCollection<Models.Usuario>(settings.UsuarioCollectionName);
        }

        public List<Models.Usuario> Get() =>
            _usuario.Find(usuario => true).ToList();

        public Models.Usuario Get(string id) =>
            _usuario.Find(usuario => usuario.Id == id).FirstOrDefault();

        public Models.Usuario GetNome(string nome) =>
          _usuario.Find(usuario => usuario.NomeUsuario.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Usuario ChecarUsuario(string nome) =>
            _usuario.Find(usuario => usuario.NomeUsuario.ToLower() == nome.ToLower()).FirstOrDefault();

        public Models.Usuario Create(Models.Usuario usuario)
        {
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Models.Usuario upUsuario) =>
            _usuario.ReplaceOne(usuario => usuario.Id == id, upUsuario);

        public void Remove(string id) =>
            _usuario.DeleteOne(usuario => usuario.Id == id);


    }
}
