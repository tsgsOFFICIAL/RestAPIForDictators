﻿using Microsoft.AspNetCore.Mvc;
using RestAPIForDictators.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIForDictators.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictatorController : ControllerBase
    {
        private List<DictatorItem> _dictators = new List<DictatorItem>();
        private string _dictatorFile = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\dictators.json";

        public DictatorController()
        {
            try
            {
                _dictators = JsonSerializer.Deserialize<List<DictatorItem>>(System.IO.File.ReadAllText(_dictatorFile));
            }
            catch (Exception)
            { }
        }

        // GET: api/<DictatorController>
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dictators);
        }

        // GET api/<DictatorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                return JsonSerializer.Serialize(_dictators[id]);
            }
            catch (Exception)
            {
                return "No dictator found";
            }
        }

        // POST api/<DictatorController>
        [HttpPost]
        public string Post([FromBody] DictatorItem dictator)
        {
            DictatorItem _dictator = dictator;
            _dictator.Id = _dictators.Count;
            _dictators.Add(_dictator);

            try
            {
                System.IO.File.WriteAllText(_dictatorFile, JsonSerializer.Serialize(_dictators));
            }
            catch (Exception)
            { }

            return JsonSerializer.Serialize(_dictator);
        }

        // PATCH api/<DictatorController>/5
        [HttpPatch("{id}")]
        public string Patch(int id, [FromBody] DictatorItem dictator)
        {
            try
            {
                _dictators[id] = dictator;
                _dictators[id].Id = id;

                try
                {
                    System.IO.File.WriteAllText(_dictatorFile, JsonSerializer.Serialize(_dictators));
                }
                catch (Exception)
                { }
            }
            catch (Exception)
            {
                return "No dictator found to update";
            }

            return $"Successfully updated dictator {id}";
        }

        // DELETE api/<DictatorController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                _dictators.RemoveAt(id);

                try
                {
                    System.IO.File.WriteAllText(_dictatorFile, JsonSerializer.Serialize(_dictators));
                }
                catch (Exception)
                { }
            }
            catch (Exception)
            {
                return "No dictator found to remove";
            }

            return $"Successfully removed dictator {id}";
        }
    }
}
