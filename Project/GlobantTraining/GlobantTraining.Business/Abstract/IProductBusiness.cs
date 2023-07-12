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
        Task<bool> SaveChanges();

        Task<ProductDto> GetProductId(int? id);

        void Create(ProductDto ProductDto, List<TypeProduct> typeProducts, List<ProductDetail> productsDetail);

        bool ExistsProductWithTitle(string title);
        List<TypeProduct> GetTypes();
        List<Consumable> GetConsumable();

        void Edit(ProductDto ProductDto, List<TypeProduct> typeProducts, List<Consumable> consusmables);
        bool ProductExists(int id);

        Task<IEnumerable<ConsumableDto>> SearchConsumables(string searchTerm);

        Task<Consumable> GetConsumableById(int? id);
    }
}
