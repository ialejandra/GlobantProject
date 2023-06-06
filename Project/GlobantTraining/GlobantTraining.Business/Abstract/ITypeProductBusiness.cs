using GlobantTraining.Models.Dtos;


namespace GlobantTraining.Business.Abstract
{
    public interface ITypeProductBusiness
    {
        Task<IEnumerable<TypeProductDto>> GetTypeProducts();
        Task<bool> SaveChanges();

        Task<TypeProductDto> GetTypeProductId(int? id);

        void Create(TypeProductDto typeProductDto);

        void Edit(TypeProductDto typeProductDto);
        bool TypeProductExists(int id);
    }
}
