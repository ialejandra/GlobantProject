using GlobantTraining.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlobantTraining.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Display(Name = "TIPO PRODUCTO")]
        public string TypeProductId { get; set; }


        [Display(Name = "INSUMOS")]
        public ICollection<ProductDetail> ProductDetail { get; set; }


        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [Display(Name = "NOMBRE PRODUCTO")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 30")]
        //[Remote(action: "VerifyName", controller: "Products")]
        public string Title { get; set; }


        [Required(ErrorMessage = "El color del producto es requerido")]
        [Display(Name = "COLOR")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 15")]
        public string Color { get; set; }



        [Required(ErrorMessage = "La descripción del producto es requerido")]
        [Display(Name = "DESCRIPCIÓN")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Ingrese mínimo 2 caracteres y máximo 500")]
        public string Characteristic { get; set; }



        [Display(Name = "PRECIO VENTA")]
        [Required]
        public decimal Price { get; set; } = 0;
        



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

        //public List<ProductDetail> ProductDetails { get; set; }
    }

    
}
