using GlobantTraining.DAL.Entities;
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
        Task<IEnumerable<ProductDetailDto>> GetProductsDetails();
        Task<bool> SaveChanges();

        Task<ProductRegisterDto> GetProductId(int? id);

        void Create(ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts);
        List<Consumable> GetProductData(string para);
        public List<TypeProduct> GetTypes();

        void Edit(ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts);
        bool ProductExists(int id);
    }
}
