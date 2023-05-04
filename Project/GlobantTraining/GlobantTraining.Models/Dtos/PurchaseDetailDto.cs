namespace GlobantTraining.Models.Dtos
{
    public class PurchaseDetailDto
    {
        public int PurchaseDetailId { get; set; }


        public int PurchaseId { get; set; }
  
        public int ConsumableId { get; set; }

        public int QuantityConsumable { get; set; }
        public int PriceUnit { get; set; }


    }
}
