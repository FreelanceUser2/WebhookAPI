using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.

namespace WebhookAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public IHttpActionResult ReceiveWebhook()
        {
            // Process the payload received from the webhook
            // You can perform any desired actions with the data
            //StringJSONFromWebHook table name
            string str = "insert into StringJSONFromWebHook (StrJSON) values (' payload ')";
            using (SqlConnection sCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString.ToString()))
            {
                using (SqlCommand sCmd = sCon.CreateCommand())
                {
                    sCmd.CommandType = CommandType.StoredProcedure;
                    sCmd.CommandText = str;

                    sCmd.ExecuteNonQuery();
                }
            }

            // Return a success response
            return Ok();
        }
        //// POST api/values
        //public void Post([FromBody] object value)
        //{
           
        //        // Process the payload received from the webhook
        //        // You can perform any desired actions with the data

        //        // Return a success response
               
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
