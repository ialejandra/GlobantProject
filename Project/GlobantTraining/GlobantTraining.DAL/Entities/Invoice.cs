
namespace GlobantTraining.DAL.Entities

{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime CreationDate { get; set; }



        public int DocumentNumberId { get; set; }
        public virtual User User { get; set; }


        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
