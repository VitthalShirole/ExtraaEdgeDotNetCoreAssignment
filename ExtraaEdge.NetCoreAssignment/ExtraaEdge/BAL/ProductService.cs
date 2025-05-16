using ExtraaEdge.DAL;
using ExtraaEdge.DAL.Model;

namespace ExtraaEdge.BAL
{
    public class ProductService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly ProductRepository _repository;

        public ProductService(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;
            this._repository = new ProductRepository(dbContext);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _repository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }

        public async Task BulkInsertAsync(IEnumerable<Product> products)
        {
            await _repository.BulkInsertAsync(products);
        }

        public async Task BulkUpdateAsync(IEnumerable<Product> products)
        {
            await _repository.BulkUpdateAsync(products);
        }


        public async Task<IEnumerable<Sales>> GetMonthlySalesAsync(DateTime fromDate, DateTime toDate)
        {
            return await _repository.GetMonthlySalesAsync(fromDate, toDate);
        }

        public async Task<IEnumerable<IGrouping<int, Sales>>> GetBrandWiseSalesAsync(DateTime fromDate, DateTime toDate)
        {
            return await _repository.GetBrandWiseSalesAsync(fromDate, toDate);
        }

        public async Task<decimal> CalculateProfitLossAsync(DateTime fromDate, DateTime toDate, DateTime compareWith)
        {
            return await _repository.CalculateProfitLossAsync(fromDate, toDate, compareWith);
        }

        public async Task<decimal> GetBestPriceAsync(int productId)
        {
            return await _repository.GetBestPriceAsync(productId);
        }
    }
}
