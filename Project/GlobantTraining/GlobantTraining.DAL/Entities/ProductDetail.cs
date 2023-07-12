

namespace GlobantTraining.DAL.Entities
{
    public class ProductDetail
    {
       
        public int ProductDetailId { get; set; }


        public int ProductId { get; set; }
        public  Product Product { get; set; }


        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
    }
}
