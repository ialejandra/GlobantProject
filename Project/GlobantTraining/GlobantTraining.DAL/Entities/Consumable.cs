using System.ComponentModel.DataAnnotations;


namespace GlobantTraining.DAL.Entities
{
    public class Consumable
    {

        [Key]
        public int ConsumableId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
