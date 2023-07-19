using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}/{nome}")]
        public string Get(int id, string nome)
        {
            return "arrivato numero: " + id + ", nome: " + nome;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post(string value)
        {
            return "Arrivato: " + value;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
