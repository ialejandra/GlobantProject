
namespace GlobantTraining.Models.Dtos

{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public DateTime CreationDate { get; set; }



        public int DocumentNumberId { get; set; }
        public virtual UserDto User { get; set; }


        public int StoreId { get; set; }
        public virtual StoreDto Store { get; set; }
    }
}
