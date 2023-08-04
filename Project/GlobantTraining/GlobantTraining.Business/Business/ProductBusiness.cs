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
using AutoMapper.Execution;



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

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {

            var Products = await _context.Products.Include(p => p.TypeProduct).ToListAsync();

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

        public List<Consumable> GetConsumable()
        {
            var types = _context.Consumables
                        .Where(t => t.Status)
                        .OrderBy(t => t.Title)
                        .ToList();

            return types;
        }

        public List<TypeProduct> GetTypes()
        {
            var types = _context.TypeProducts
                        .Where(t => t.Status)
                        .OrderBy(t => t.Title)
                        .ToList();

            return types;
        }


        public async Task<IEnumerable<ConsumableDto>> SearchConsumables(string searchForm)
        {
            List<ConsumableDto> ListConsumableDto = new List<ConsumableDto>();
            var consumables = await _context.Consumables
                .Where(c => c.Title.Contains(searchForm))
                .ToListAsync();

            consumables.ForEach(c =>
            {
                ConsumableDto consumableDto = new ConsumableDto
                {
                    ConsumableId = c.ConsumableId,
                    Title = c.Title,
                    Color = c.Color,
                    Description = c.Description,

                };
                ListConsumableDto.Add(consumableDto);
            });

            return ListConsumableDto;
        }


        //public void Create(ProductDto ProductDto, List<TypeProduct> typeProducts) //quitar listas
        //{
        //    if (ProductDto == null)
        //        throw new ArgumentNullException(nameof(ProductDto));

        //    var Product = _mapper.Map<Product>(ProductDto);

        //    _context.Products.Add(Product);

        //}

        public void Create(ProductDto ProductDto, List<TypeProduct> typeProducts, List<ProductDetail>productsDetail)
        {
            if (ProductDto == null)
                throw new ArgumentNullException(nameof(ProductDto));

            var Product = _mapper.Map<Product>(ProductDto);
            var productDetailIds = ProductDto.ProductDetail;
            var productDetails = new List<ProductDetail>();

            //foreach (var productDetailId in productDetailIds)
            //{
            //    var productDetail = _context.ProductsDetails.FirstOrDefault(pd => pd.ProductDetailId == productDetailId);
            //    if (productDetail != null)
            //    {
            //        productDetails.Add(productDetail);
            //    }
            //}

            _context.Products.Add(Product);

        }

        public bool ExistsProductWithTitle(string title)
        {
            return _context.Products.Any(p => p.Title == title);
        }


        public void Edit(ProductDto ProductDto, List<TypeProduct> typeProducts, List<Consumable> consusmables)
        {
            if (ProductDto != null)
            {
                var Product = _mapper.Map<Product>(ProductDto);

                _context.Update(Product);

            }
        }


        public bool ProductExists(int id)
        {
            return _context.Products.Any(tp => tp.ProductId == id);
        }

        

        public async Task<Consumable> GetConsumableById(int? id)
        {
            var consumable = await _context.Consumables.FirstOrDefaultAsync(x => x.ConsumableId == id);

            if (consumable == null)
                return null;

            return consumable;
        }


    }

}
