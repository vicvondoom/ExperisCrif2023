using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BiblioBlazorWasm.Models
{
    public class WebAPIHelper
    {
        private HttpClient client;
        private string url;

        public WebAPIHelper(string url)
        {
            ChangeUrl(url);
        }

        public void ChangeUrl(string url)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            this.url = url;
            client.BaseAddress = new Uri(this.url);
        }

        public async Task<List<T>> Get<T>()
        {
            List<T> lista = new List<T>();
            string tmp = await client.GetStringAsync(url);
            lista = JsonConvert.DeserializeObject<List<T>>(tmp);
            return lista;
        }

        public async Task<AutorePOCO> GetById(int id)
        {
            AutorePOCO a = new AutorePOCO();
            string tmp = await client.GetStringAsync(url + "/" + id);
            a = JsonConvert.DeserializeObject<AutorePOCO>(tmp);
            return a;
        }

        public async Task<AutorePOCO> Post(AutorePOCO aut)
        {
            var risposta = await client.PostAsJsonAsync<AutorePOCO>(url, aut);
            string json = await risposta.Content.ReadAsStringAsync(); // stringa json di risposta
            AutorePOCO b = JsonConvert.DeserializeObject<AutorePOCO>(json);
            return b;
        }
    }
}
