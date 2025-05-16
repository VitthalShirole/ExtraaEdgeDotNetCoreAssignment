using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdge.DAL.Model
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }
    
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
  
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public int? DiscountId { get; set; }
        [ForeignKey(nameof(DiscountId))]
        public Discount? Discount { get; set; }
    }
}
