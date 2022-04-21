using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Servicos
{
    public class BuscaEquipe
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Equipe> BuscarEquipePeloCodigo(string Codigo)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44339/api/Equipes/Codigo?codigo=" + Codigo);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var equipe = JsonConvert.DeserializeObject<Equipe>(corpoResposta);

                return equipe;

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public static async Task<List<Equipe>> BuscarTodasEquipes()
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44339/api/Equipes");
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var equipe = JsonConvert.DeserializeObject<List<Equipe>>(corpoResposta);

                return equipe;

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


      
        public static async Task<Equipe> BuscarEquipePeloId(string Id)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44339/api/Equipes/" + Id);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var equipe = JsonConvert.DeserializeObject<Equipe>(corpoResposta);

                return equipe;

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        public static void CadastrarEquipe(Equipe equipe)
        {
            client.PostAsJsonAsync("https://localhost:44339/api/Equipes/", equipe);
        }

        public static void UpdateEquipe(string id, Equipe equipe)
        {
            client.PutAsJsonAsync("https://localhost:44339/api/Equipes/" + id, equipe);
        }

        public static void RemoverEquipe(string id)
        {
            client.DeleteAsync("https://localhost:44339/api/Equipes/" + id);
        }
    }
}
