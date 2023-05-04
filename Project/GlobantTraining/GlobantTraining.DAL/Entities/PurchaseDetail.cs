namespace GlobantTraining.DAL.Entities
{
    public class PurchaseDetail
    {
        public int PurchaseDetailId { get; set; }


        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }


        public int ConsumableId { get; set; }
        public virtual Consumable Consumable { get; set; }


        public int QuantityConsumable { get; set; }
        public int PriceUnit { get; set; }


    }
}
