using GlobantTraining.Models.Dtos;
using GlobantTraining.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;
using Microsoft.EntityFrameworkCore;

namespace GlobantTraining.Business.Business
{
    public class TypeProductBusiness: ITypeProductBusiness
    {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;


            //Constructor
            public TypeProductBusiness(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public void Create(TypeProductDto TypeProductDto)
            {
                if (TypeProductDto == null)
                    throw new ArgumentNullException(nameof(TypeProductDto));
                    TypeProductDto.Status = true;

                var TypeProduct = _mapper.Map<TypeProduct>(TypeProductDto);

                _context.TypeProducts.Add(TypeProduct);
                
            }

            public void Edit(TypeProductDto typeProductDto)
            {
                if (typeProductDto != null)
                {
                    var typeProduct = _mapper.Map<TypeProduct>(typeProductDto);
                    _context.Update(typeProduct);
                }
            }

            public async Task<IEnumerable<TypeProductDto>> GetTypeProducts()
            {
               
                var typeProduct = await _context.TypeProducts.ToListAsync();
                var typeProductDto = _mapper.Map<IEnumerable<TypeProductDto>>(typeProduct);
                
                return typeProductDto;
            }



            public async Task<TypeProductDto> GetTypeProductId(int? id)
            {
                if (id == null)
                    return null;

                var typeProduct = await _context.TypeProducts.FirstOrDefaultAsync(tp => tp.TypeProductId == id);

                if (typeProduct == null)
                    return null;

                var typeProductDto = _mapper.Map<TypeProductDto>(typeProduct);
                return typeProductDto;
            }

            public async Task<bool> SaveChanges()
            {
                return await _context.SaveChangesAsync() > 0;
            }

            public bool TypeProductExists(int id)
            {
                return _context.TypeProducts.Any(tp => tp.TypeProductId == id);
            }
        }
    
}
