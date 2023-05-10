using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GlobantTraining.DAL.Entities
{
    public class TypeProduct
    {
        public int TypeProductId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
