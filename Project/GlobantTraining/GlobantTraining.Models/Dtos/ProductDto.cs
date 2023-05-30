using GlobantTraining.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int TypeProductId { get; set; }     
        public int ConsumableId { get; set; }


        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [Display(Name = "NOMBRE PRODUCTO")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 5 caracteres y máximo 30")]
        public string Title { get; set; }


        [Required(ErrorMessage = "El color del producto es requerido")]
        [Display(Name = "COLOR")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 15")]
        public string Color { get; set; }



        [Required(ErrorMessage = "La descripción del producto es requerido")]
        [Display(Name = "DESCRIPCIÓN")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 500")]
        public string Characteristic { get; set; }



        [Display(Name = "PRECIO VENTA")]
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
