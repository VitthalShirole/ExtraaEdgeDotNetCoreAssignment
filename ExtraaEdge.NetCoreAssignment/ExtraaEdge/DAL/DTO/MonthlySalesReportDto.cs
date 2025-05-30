namespace ExtraaEdge.DAL.DTO
{
    public class MonthlySalesReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
