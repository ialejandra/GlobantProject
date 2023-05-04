namespace GlobantTraining.DAL.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }


        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }



        public int NumberPurchase { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
