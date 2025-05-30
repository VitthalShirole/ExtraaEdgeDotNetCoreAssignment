using ExtraaEdge.DAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.DAL
{
    public class ReportRepository
    {

        private readonly ApplicationDbContext _context;
        public ReportRepository(ApplicationDbContext dbContext)
        {

            this._context = dbContext;
        }


        public async Task<MonthlySalesReportDto> GetMonthlySalesReportAsync(DateTime from, DateTime to)
        {
            var salesData = await _context.Sales
                .Where(s => s.SaleDate >= from && s.SaleDate <= to)
                .ToListAsync();

            return new MonthlySalesReportDto
            {
                StartDate = from,
                EndDate = to,
                TotalQuantity = salesData.Sum(s => s.Quantity),
                TotalAmount = salesData.Sum(s => s.TotalAmount)
            };
        }

        public async Task<BrandWiseSalesReportDto> GetBrandWiseSalesReportAsync(DateTime from, DateTime to)
        {
            var brandSales = await _context.Sales
                .Where(s => s.SaleDate >= from && s.SaleDate <= to)
                .Include(s => s.Product)
                .ThenInclude(p => p.Brand)
                .GroupBy(s => s.Product.Brand.Name)
                .Select(g => new BrandSalesDto
                {
                    BrandName = g.Key,
                    UnitsSold = g.Sum(s => s.Quantity),
                    TotalRevenue = g.Sum(s => s.TotalAmount)
                })
                .ToListAsync();

            return new BrandWiseSalesReportDto
            {
                StartDate = from,
                EndDate = to,
                BrandSales = brandSales
            };
        }
    }
}
