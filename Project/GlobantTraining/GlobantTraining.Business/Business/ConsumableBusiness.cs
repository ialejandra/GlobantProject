using GlobantTraining.DAL;
using GlobantTraining.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Models.Dtos;
using GlobantTraining.Business.Abstract;

namespace GlobantTraining.Business.Business
{
    public class ConsumableBusiness : IConsumableBusiness
    {
        private readonly AppDbContext _context;

        //Constructor
        public ConsumableBusiness(AppDbContext context)
        {
            _context = context;
        }
        //Método

        public async Task<ConsumableDto> GetConsumableId(int? id)
        {
            var consumable = await _context.Consumables.FirstOrDefaultAsync(x => x.ConsumableId == id);

            if (consumable == null)
                return null;

            var consumableDto = new ConsumableDto();
            consumableDto.ConsumableId = consumable.ConsumableId;
            consumableDto.Title = consumable.Title;
            consumableDto.Color = consumable.Color;
            consumableDto.Description = consumable.Description;

            return consumableDto;
        }


        public async Task<IEnumerable<ConsumableDto>> GetConsumables()
        {
            List<ConsumableDto> ListConsumableDto = new();
            var consumables = await _context.Consumables.ToListAsync();
            consumables.ForEach(c =>
            {
                ConsumableDto consumableDto = new()
                {
                    ConsumableId = c.ConsumableId,
                    Title = c.Title,
                    Color = c.Color,
                    Description = c.Description,
                    Status = GetStatus(c.Status) == "Activo"
                };
                ListConsumableDto.Add(consumableDto);
            });
            return ListConsumableDto;
        }

        

        private string GetStatus(bool status)
        {
            if (status)
                return "Activo";
            else
                return "Inactivo";
        }
        public void Create(ConsumableDto consumableDto)
        {
            if (consumableDto == null)
                throw new ArgumentNullException(nameof(Consumable));
            consumableDto.Status = true;

            Consumable consumable = new()
            {
                ConsumableId = consumableDto.ConsumableId,
                Title = consumableDto.Title,
                Color = consumableDto.Color,
                Description = consumableDto.Description,
                Status = consumableDto.Status,
            };
            _context.Add(consumable);

        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Edit(ConsumableDto consumableDto)
        {
            if (consumableDto != null)
            {
                Consumable consumable = new()
                {
                    ConsumableId = consumableDto.ConsumableId,
                    Title = consumableDto.Title,
                    Color = consumableDto.Color,
                    Description = consumableDto.Description,
                    Status = consumableDto.Status,
                };
                _context.Update(consumable);

            }

        }


        public bool ConsumableExists(int id)
        {
            return _context.Consumables.Any(e => e.ConsumableId == id);
        }

        public async Task<IEnumerable<ConsumableDto>> SearchConsumables(string searchTerm)
        {
            List<ConsumableDto> ListConsumableDto = new();
            var consumables = await _context.Consumables
                .Where(c => c.Title.Contains(searchTerm))
                .ToListAsync();

            consumables.ForEach(c =>
            {
                ConsumableDto consumableDto = new()
                {
                    ConsumableId = c.ConsumableId,
                    Title = c.Title,
                    Color = c.Color,
                    Description = c.Description,
                    Status = GetStatus(c.Status) == "Activo"
                };
                ListConsumableDto.Add(consumableDto);
            });

            return ListConsumableDto;
        }


    }
}
