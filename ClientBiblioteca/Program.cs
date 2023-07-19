using ClientBiblioteca.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ClientBiblioteca
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();

            // Pe chiamare qualunque API da C# mi serve questa classe
            HttpClient client = new HttpClient();

            // Ripulisco le intestazioni dei pacchetti
            client.DefaultRequestHeaders.Accept.Clear();

            // Tra client e server ci "parliamo" in json
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Endpoint delle web api
            string sito = "https://localhost:7287/";
            string endPoint = "api/autori"; // Controller Autori
            string url = sito + endPoint;

            // Passo all'HttpClient l'endpoint
            // URI = Uniform Resource Identifier
            client.BaseAddress = new Uri(url);

            // GET
            //// SELECT * => GET
            //// Voglio chiamare in get le api ed ottenere l'elenco degli autori
            //string tmp = await client.GetStringAsync(url);
            //// Ottengo  una stringa in cui c'è scritto tutto l'elenco degli autori
            //Console.WriteLine(tmp);
            //// Però vorrei trasformarlo in una List di oggetti
            //List<AutorePOCO> autori = JsonConvert.DeserializeObject<List<AutorePOCO>>(tmp);
            //foreach(var a in autori)
            //{
            //    Console.WriteLine($"{a.Id}\t{a.Nome}\t{a.Cognome}");
            //}

            //// GET con parametro
            //// SELECT * from Autori where ID=n
            //string tmp = await client.GetStringAsync(url + "/4");
            //Console.WriteLine(tmp);
            //AutorePOCO a = JsonConvert.DeserializeObject<AutorePOCO>(tmp);
            //Console.WriteLine($"{a.Id}\t{a.Nome}\t{a.Cognome}");

            //// POST
            //// Insert into ..... => POST
            //AutorePOCO a = new AutorePOCO();
            //a.Nome = "Arthur Conan";
            //a.Cognome = "Doyle";
            //// Chiamo in POST e mando l'oggetto da aggiungere
            //var risposta = await client.PostAsJsonAsync<AutorePOCO>(url, a);
            //// L'API però risponde rimandandomi l'oggetto con l'id assegnato dal database (che a me potrebbe servire)
            //Console.WriteLine("Server: " + risposta.ReasonPhrase);
            //string json = await risposta.Content.ReadAsStringAsync(); // stringa json di risposta
            //AutorePOCO b = JsonConvert.DeserializeObject<AutorePOCO>(json);
            //Console.WriteLine($"{b.Id}\t{b.Nome} {b.Cognome}");

            //// PUT
            //// Update Autori set....... => PUT
            //// Voglio modificare un autore, quindi devo ottenerlo dall'api al punto sopra
            //// Ottengo dalle API l'autore da modificare "Camilleri" che diventerà "HEinlein"
            //string tmp = await client.GetStringAsync(url + "/3");
            //Console.WriteLine(tmp);
            //AutorePOCO a = JsonConvert.DeserializeObject<AutorePOCO>(tmp);
            //a.Nome = "Robert";
            //a.Cognome = "Heinlein";
            //// Mando sulle API l'oggetto modificato
            //var risposta = await client.PutAsJsonAsync<AutorePOCO>(url + "/3", a);
            //Console.WriteLine("Status code: " + risposta.StatusCode);

            // DELETE
            // delete from tabella where id = n 
            // Voglio cancellare la riga che ha id=99
            var risposta = await client.DeleteAsync(url + "/8");
            Console.WriteLine("Status code: " + risposta.StatusCode);

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}