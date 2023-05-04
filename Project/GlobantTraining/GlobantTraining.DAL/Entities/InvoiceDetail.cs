namespace GlobantTraining.DAL.Entities
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }



        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }



        public int ProductId { get; set; }
        public virtual Product Product { get; set; }




        public int QuantityUnit { get; set; }
        public int PriceUnit { get; set; }


    }
}
