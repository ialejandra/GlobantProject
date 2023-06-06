using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GlobantTraining.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }


        [Display(Name = "TIPO PRODUCTO")]
        public string TypeProductId { get; set; }


        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ingrese mínimo 5 caracteres y máximo 30")]
        [Display(Name = "NOMBRE PRODUCTO")]
        public string Title { get; set; }




        [Display(Name = "CARACTERISTICAS")]
        public string Characteristic { get; set; }



        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Display(Name = "PRECIO")]
        public decimal Price { get; set; }




        [Display(Name = "ESTADO")]
        public bool Status { get; set; }

        public string ShowStatus
        {
            get
            {
                if (Status)
                { return "Activo"; }
                else
                { return "Inactivo"; }
            }
        }
    }
}
