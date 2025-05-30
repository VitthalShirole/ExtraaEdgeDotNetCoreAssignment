using ExtraaEdge.DAL;
using ExtraaEdge.DAL.Model;
using System.Text.Json.Nodes;

namespace ExtraaEdge.BAL
{
    public class HandSetService
    {
        private readonly ApplicationDbContext dbContext;


        public HandSetService(ApplicationDbContext dbContext) 
        {

            this.dbContext = dbContext;
        }


        public JsonObject Add( HandSet handSet)
        {
            var result = new JsonObject();

            var hand = new HandSet();
            hand.Name = handSet.Name;


            new HandSetRepository(dbContext).Add(hand);

            return result;
        }

        public List<HandSet> Get(int brandId)
        {
            var result = dbContext.handSet.Where(i => i.BrandId == brandId).ToList();

            return result;
        }
    }
}
