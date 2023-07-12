using GlobantTraining.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Models.Dtos
{
    public class ProductDetailDto
    {
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public int ConsumableId { get; set; }
    }
}
