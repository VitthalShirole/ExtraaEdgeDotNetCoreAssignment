namespace ExtraaEdge.DAL.DTO
{
    public class BrandWiseSalesReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BrandSalesDto> BrandSales { get; set; }
    }
}
