using ExtraaEdge.DAL;
using ExtraaEdge.DAL.DTO;
using System.Text.Json.Nodes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ExtraaEdge.BAL
{
    public class ReportService
    {



        private readonly ApplicationDbContext dbContext;
        private readonly ReportRepository _repository;

        public ReportService(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;
            this._repository = new ReportRepository(dbContext);
        }



        public async Task<MonthlySalesReportDto> GetMonthlySalesReportAsync(DateTime from, DateTime to)
        {
            return await _repository.GetMonthlySalesReportAsync(from, to);
        }


            public async Task<BrandWiseSalesReportDto> GetBrandWiseSalesReportAsync(DateTime from, DateTime to)
        {

            return await _repository.GetBrandWiseSalesReportAsync(from, to);
        }

        
    }
}
