using ExtraaEdge.DAL.Model;

namespace ExtraaEdge.DAL
{
    public class HandSetRepository
    {
        private readonly ApplicationDbContext dbContext;
        public HandSetRepository(ApplicationDbContext dbContext) 
       {

            this.dbContext = dbContext;
        }

        public void Add(HandSet employee) 
        {
            var result =

            dbContext.handSet.Add(employee);
            dbContext.SaveChanges();

        }
    }
}
