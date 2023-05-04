namespace GlobantTraining.Models.Dtos
{
    public class PurchaseDto
    {
        public int PurchaseId { get; set; }


        public int ProviderId { get; set; }
        public virtual ProviderDto Provider { get; set; }



        public int NumberPurchase { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
