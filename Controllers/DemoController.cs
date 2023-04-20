using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_using_Microservices___.Net_6._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // GET: api/<DemoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Instead of using SQL queries, microservices use " +
                "APIs to communicate with other services and retrieve data. Each " +
                "service exposes a well-defined API that other services can use to " +
                "retrieve the data they need. This approach provides loose coupling" +
                " between services and helps to ensure that each service can be " +
                "developed, deployed, and scaled independently." };
        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DemoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<DemoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
     
        }

    }
}
