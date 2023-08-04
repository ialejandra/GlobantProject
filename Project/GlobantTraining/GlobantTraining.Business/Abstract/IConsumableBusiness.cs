using GlobantTraining.DAL.Entities;
using GlobantTraining.Models.Dtos;

namespace GlobantTraining.Business.Abstract
{
    public interface IConsumableBusiness
    {
        Task<IEnumerable<ConsumableDto>> GetConsumables();
        Task<bool> SaveChanges();

        Task<ConsumableDto> GetConsumableId(int? id);

        void Create(ConsumableDto consumableDto);

        void Edit(ConsumableDto consumableDto);
        bool ConsumableExists(int id);


        //Task Delete(int consumableId);
    }


}
