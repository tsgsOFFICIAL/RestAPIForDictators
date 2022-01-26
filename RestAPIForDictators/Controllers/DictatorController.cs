using Microsoft.AspNetCore.Mvc;
using RestAPIForDictators.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIForDictators.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictatorController : ControllerBase
    {
        private List<DictatorItem> _dictators = new List<DictatorItem>();

        // GET: api/<DictatorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DictatorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{id}";
        }

        // POST api/<DictatorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine($"{value}");
        }

        // PATCH api/<DictatorController>/5
        [HttpPatch("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DictatorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
