using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    namespace GlobantTraining.Models.Dtos
    {
        public class TypeProductDto
        {
        [Display(Name = "CÓDIGO")]
        public int TypeProductId { get; set; }


        
        [Required(ErrorMessage = "El nombre del tipo de producto es requerido")]
        [Display(Name = "NOMBRE TIPO DE PRODUCTO")]
        public string Title { get; set; }



        [Display(Name = "ESTADO")]
        public bool Status { get; set; }
       



    }
}
