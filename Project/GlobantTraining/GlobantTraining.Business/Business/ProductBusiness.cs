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
    public class ProductBusiness : IProductBusiness
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        //Constructor
        public ProductBusiness(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Create(ProductDto ProductDto)
        {
            if (ProductDto == null)
                throw new ArgumentNullException(nameof(ProductDto));

            var Product = _mapper.Map<Product>(ProductDto);

            _context.Products.Add(Product);
            return await SaveChanges();
        }

        public void Edit(ProductDto ProductDto)
        {
            if (ProductDto != null)
            {
                var Product = _mapper.Map<Product>(ProductDto);

                _context.Update(Product);

            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var Products = await _context.Products.ToListAsync();
            var ProductDtos = _mapper.Map<IEnumerable<ProductDto>>(Products);
            return ProductDtos;
        }

        public async Task<ProductDto> GetProductId(int? id)
        {
            if (id == null)
                return null;

            var Product = await _context.Products.FirstOrDefaultAsync(tp => tp.ProductId == id);

            if (Product == null)
                return null;

            var ProductDto = _mapper.Map<ProductDto>(Product);
            return ProductDto;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(tp => tp.ProductId == id);
        }
    }

}
