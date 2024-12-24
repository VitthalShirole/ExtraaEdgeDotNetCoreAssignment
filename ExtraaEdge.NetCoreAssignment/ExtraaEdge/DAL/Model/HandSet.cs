using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdge.DAL.Model
{
    [Table(name: "HandSet")]
    public class HandSet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ModelNumber { get; set; }

        public DateTime? SellDate { get; set; }

        public bool IsSold { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }


    }
}
