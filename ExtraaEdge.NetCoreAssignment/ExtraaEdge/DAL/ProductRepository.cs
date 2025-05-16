using ExtraaEdge.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.DAL
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext)
        {

            this._context = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.Brand).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Brand).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task BulkInsertAsync(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateAsync(IEnumerable<Product> products)
        {
            _context.Products.UpdateRange(products);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Sales>> GetMonthlySalesAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.Sales
                .Include(s => s.Product)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<int, Sales>>> GetBrandWiseSalesAsync(DateTime fromDate, DateTime toDate)
        {
            var sales = await _context.Sales
                .Include(s => s.Product)
                .ThenInclude(p => p.Brand)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync(); 

            return sales
                .GroupBy(s => s.Product.BrandId); 
        }

        public async Task<decimal> CalculateProfitLossAsync(DateTime fromDate, DateTime toDate, DateTime compareWith)
        {
            var currentPeriodSales = await _context.Sales
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();

            var previousPeriodSales = await _context.Sales
                .Where(s => s.SaleDate >= compareWith && s.SaleDate < fromDate)
                .ToListAsync();

            var currentProfit = currentPeriodSales.Sum(s => s.TotalAmount);
            var previousProfit = previousPeriodSales.Sum(s => s.TotalAmount);

            return currentProfit - previousProfit;
        }

        public async Task<decimal> GetBestPriceAsync(int productId)
        {
            var sales = await _context.Sales
                .Where(s => s.ProductId == productId)
                .ToListAsync();

            if (!sales.Any()) return 0;

            return sales.Average(s => s.TotalAmount / s.Quantity);
        }
    }
}
