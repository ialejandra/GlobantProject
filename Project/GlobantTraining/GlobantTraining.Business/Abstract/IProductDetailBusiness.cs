using GlobantTraining.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Business.Abstract
{
    public interface IProductDetailBusiness
    {
        List<ProductDetailDto> GetAllProductDetails();
        ProductDetailDto GetProductDetailById(int productDetailId);
    }
}
