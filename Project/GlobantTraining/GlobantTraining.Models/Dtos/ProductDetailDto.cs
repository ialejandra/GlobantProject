using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobantTraining.Models.Dtos
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }

        [Display(Name = "TIPO PRODUCTO")]
        public string TypeProductId { get; set; }



        [Display(Name = "INSUMOS")]
        public string ConsumableId { get; set; }




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
