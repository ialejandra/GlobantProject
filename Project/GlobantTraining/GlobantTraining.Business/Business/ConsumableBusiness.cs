﻿using GlobantTraining.DAL;
using GlobantTraining.Models.Abstract;
using GlobantTraining.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Models.Dtos.Consumable;

namespace GlobantTraining.Business
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
                    ConsumableId= c.ConsumableId,
                    Title= c.Title,
                    Color= c.Color,
                    Description= c.Description,
                };
                ListConsumableDto.Add(consumableDto);
            });
            return ListConsumableDto;   
        }
        // private string Getestado(bool estado)
        //{
        //    if (estado)
        //        return "Activo";
        //    else
        //        return "Inactivo";
        //}

        public void Create(ConsumableDto consumableDto)
        {
            if (consumableDto == null)
                throw new ArgumentNullException(nameof(Consumable));

            Consumable consumable = new()
            {
                ConsumableId = consumableDto.ConsumableId,
                Title = consumableDto.Title,
                Color = consumableDto.Color,
                Description = consumableDto.Description,
            };
            _context.Add(consumable);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >0;
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
                };
                _context.Update(consumable);
            }
  
        }


        public bool ConsumableExists(int id)
        {
            return _context.Consumables.Any(e => e.ConsumableId == id);
        }


        //public async Task Delete(int consumableId)
        //{
        //    var consumableToDelete = await _context.Consumables.FindAsync(consumableId);

        //    if (consumableToDelete != null)
        //    {
        //        _context.Consumables.Remove(consumableToDelete);
        //        await _context.SaveChangesAsync();
        //    }
        //}

    }
}