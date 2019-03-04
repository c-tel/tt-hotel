using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace TTHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static string сonnectionString = 
            "Host=ec2-54-243-128-95.compute-1.amazonaws.com;" +
            "Port=5432;" +
            "Username=tyoigfycditakg;" +
            "Password=1bd83bca8ab334c28d2b311b0a713543c66a3288d3327aad1f910dea63fd372cd;" +
            "Database=dcvtt5pjns4r4v";
        private NpgsqlConnection conn;

        public ValuesController()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = "ec2-54-243-128-95.compute-1.amazonaws.com",
                Port = 5432,
                Username = "tyoigfycditakg",
                Password = "1bd83bca8ab334c28d2b311b0a713543c66a3288d3327aad1f910dea63fd372cd",
                Database = "dcvtt5pjns4r4v",
                SslMode = SslMode.Require
            };
            conn = new NpgsqlConnection(builder.ToString());
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("Select * From public.\"Users\"", conn))
            {
                var reader = cmd.ExecuteReader();
            }
            conn.Dispose();
            return new string[] { "value0", "value1" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
