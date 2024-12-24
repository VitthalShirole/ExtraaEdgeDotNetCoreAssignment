using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdge.DAL.Model
{
    [Table (name:"Brand")]
    public class Brand
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Discount { get; set; }
    }
}
