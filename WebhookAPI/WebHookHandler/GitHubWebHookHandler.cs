using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebhookAPI.WebHookHandler
{
    public class GitHubWebHookHandler : Microsoft.AspNet.WebHooks.WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if ("GitHub".Equals(receiver, StringComparison.CurrentCultureIgnoreCase))
            {
                string action = context.Actions.First();
                JObject data = context.GetDataOrDefault<JObject>();
                var dataAsString = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            string str = "insert into StringJSONFromWebHook (StrJSON) values (' payload ')";
            using (SqlConnection sCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString.ToString()))
            {
                using (SqlCommand sCmd = sCon.CreateCommand())
                {
                    sCmd.CommandType = CommandType.Text;
                    sCmd.CommandText = str;

                    sCmd.ExecuteNonQuery();
                }
            }
            return Task.FromResult(true);
        }
    }
}