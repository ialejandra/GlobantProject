using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GlobantTraining.DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int ConsumableId { get; set; }
        public virtual Consumable Consumable { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Characteristic { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
