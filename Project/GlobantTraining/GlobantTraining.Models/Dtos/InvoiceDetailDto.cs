namespace GlobantTraining.Models.Dtos
{
    public class InvoiceDetailDto
    {
        public int InvoiceDetailId { get; set; }



        public int InvoiceId { get; set; }


        public int ProductId { get; set; }


        public int QuantityUnit { get; set; }
        public int PriceUnit { get; set; }


    }
}
