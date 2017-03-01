using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using WipDod.Dal;

namespace WipDod.Controllers
{
    public class AgentsController : Controller
    {
        private DodContext db = new DodContext();

        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        public ActionResult AgentList(string start, string end)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DodContext"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getAgentsByOperationWithTheirAvarage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@start", SqlDbType.VarChar).Value = start;
                    cmd.Parameters.Add("@end", SqlDbType.VarChar).Value = end;

                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }

            return Content(JsonConvert.SerializeObject(dt, Formatting.Indented));
        }
    }
}