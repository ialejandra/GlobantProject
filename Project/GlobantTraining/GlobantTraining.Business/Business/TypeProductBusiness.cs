using GlobantTraining.DAL;
using GlobantTraining.Business.Abstract;
using GlobantTraining.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Models.Dtos;


namespace GlobantTraining.Business.Business
{
    public class TypeProductBusiness : ITypeProductBusiness
    {
        private readonly AppDbContext _context;
        

        //Constructor
        public TypeProductBusiness(AppDbContext context)
        {
            _context = context;
       
        }

        public void Create(TypeProductDto typeProductDto)
        {
            if (typeProductDto == null)
                throw new ArgumentNullException(nameof(TypeProductDto));
            typeProductDto.Status = true;


            TypeProduct typeProduct = new()
            {
                TypeProductId = typeProductDto.TypeProductId,
                Title = typeProductDto.Title,
                Status = typeProductDto.Status,
            };          
            _context.TypeProducts.Add(typeProduct);
        }

        public void Edit(TypeProductDto typeProductDto)
        {
            if (typeProductDto != null)
            {
                TypeProduct typeProduct = new()
                {
                    TypeProductId = typeProductDto.TypeProductId,
                    Title = typeProductDto.Title,
                    Status = typeProductDto.Status,
                };
                _context.Update(typeProduct);
            }
        }

        public async Task<IEnumerable<TypeProductDto>> GetTypeProducts()
        {
            List<TypeProductDto> ListTypeProductDto = new();
            var typeProduct = await _context.TypeProducts.ToListAsync();
            typeProduct.ForEach(tp =>
            {
                TypeProductDto typeProductDto = new()
                {
                    TypeProductId = tp.TypeProductId,
                    Title = tp.Title,
                    Status = (GetEstado(tp.Status) == "Activo"),
                };
                ListTypeProductDto.Add(typeProductDto);
            });

            return ListTypeProductDto;
        }



        private string GetEstado(bool Status)
        {
            if (Status)
                return "Activo";
            else
                return "Inactivo";
        }


        public async Task<TypeProductDto> GetTypeProductId(int? id)
        {
            var typeProduct = await _context.TypeProducts.FirstOrDefaultAsync(x => x.TypeProductId == id);
            if (typeProduct == null)
                return null;

            var typeProductDto = new TypeProductDto();
            typeProductDto.TypeProductId = typeProduct.TypeProductId;
            typeProductDto.Title = typeProduct.Title;

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
