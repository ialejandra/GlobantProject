using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GlobantTraining.Models.Dtos.Product
{
    public class ProductDto
    {
        [Key]
        [Display(Name = "CÓDIGO")]
        public int ProductId { get; set; }



        public int TypeProductId { get; set; }


        public int ConsumableId { get; set; }




        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ingrese mínimo 5 caracteres y máximo 30")]
        [Display(Name = "NOMBRE PRODUCTO")]
        public string Title { get; set; }



        [Display(Name = "COLOR")]
        public string Color { get; set; }




        [Display(Name = "CARACTERISTICAS")]
        public string Characteristic { get; set; }



        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Display(Name = "PRECIO")]
        public decimal Price { get; set; }




        [Display(Name = "ESTADO")]
        public bool Status { get; set; }
    }
}
