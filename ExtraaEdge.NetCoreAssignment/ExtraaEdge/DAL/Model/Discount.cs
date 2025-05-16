using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdge.DAL.Model
{
    [Table(name:"Discounts")]
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public double Percentage { get; set; }
        public string Description { get; set; }
    }
}
