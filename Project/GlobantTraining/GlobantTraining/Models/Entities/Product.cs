using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GlobantTraining.Models.Entities
{
    public class Product
    {
        [Key]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Characteristic { get; set; }
        public decimal Price { get; set; }

    }
}
