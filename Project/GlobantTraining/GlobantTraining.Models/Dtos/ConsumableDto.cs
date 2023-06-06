using System.ComponentModel.DataAnnotations;

namespace GlobantTraining.Models.Dtos
{
    public class ConsumableDto
    {

        [Key]
        [Display(Name = "CÓDIGO")]
        public int ConsumableId { get; set; }



        [Required(ErrorMessage = "El nombre del insumo es requerido")]
        [Display(Name = "NOMBRE INSUMO")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 5 caracteres y máximo 30")]
        public string Title { get; set; }



        [Required(ErrorMessage = "El color del insumo es requerido")]
        [Display(Name = "COLOR")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 15")]
        public string Color { get; set; }




        [Required(ErrorMessage = "La descripción del insumo es requerido")]
        [Display(Name = "DESCRIPCIÓN")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Ingrese mínimo 3 caracteres y máximo 500")]
        public string Description { get; set; }




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
