using GlobantTraining.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Business.Abstract
{
    public interface ITypeProductBusiness
    {
        Task<IEnumerable<TypeProductDto>> GetTypeProducts();
        Task<bool> SaveChanges();

        Task<TypeProductDto> GetTypeProductId(int? id);

        void Create(TypeProductDto TypeProductDto);

        void Edit(TypeProductDto typeProductDto);
        bool TypeProductExists(int id);
    }
}
