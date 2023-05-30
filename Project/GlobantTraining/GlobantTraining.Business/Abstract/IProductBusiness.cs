using GlobantTraining.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Business.Abstract
{
    public interface IProductBusiness
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<bool> SaveChanges();

        Task<ProductDto> GetProductId(int? id);

        Task<bool> Create(ProductDto ProductDto);

        void Edit(ProductDto ProductDto);
        bool ProductExists(int id);
    }
}
