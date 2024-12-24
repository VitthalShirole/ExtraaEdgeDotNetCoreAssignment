using ExtraaEdge.DAL;
using System.Text.Json.Nodes;

namespace ExtraaEdge.BAL
{
    public class ReportService
    {

        private readonly ApplicationDbContext dbContext;


        public ReportService(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;
        }


        public JsonObject Get(JsonObject requestDta)
        {
            var result = new JsonObject();
            var fromDate = request.RequestData.FromDate;
            var toDate = request.RequestData.ToDate;




            return result;
        }
    }
}
