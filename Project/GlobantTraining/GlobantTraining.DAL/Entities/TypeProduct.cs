using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GlobantTraining.DAL.Entities
{
    public class TypeProduct
    {
        [Display(Name = "CÓDIGO")]
        public int TypeProductId { get; set; }





        [Display(Name = "NOMBRE TIPO DE PRODUCTO")]
        [Required(ErrorMessage = "El nombre del tipo de producto es requerido")]
        public string Title { get; set; }



        [Display(Name = "ESTADO")]
        public bool Status { get; set; }
    }
}
