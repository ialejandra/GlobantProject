using GlobantTraining.DAL;
using GlobantTraining.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Models.Dtos;
using GlobantTraining.Business.Abstract;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace GlobantTraining.Business.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly AppDbContext _context;

        public ProductBusiness(AppDbContext context)
        {
            _context = context;
        }
        public void Create(ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts)
        {
            if(productRegisterDto == null)
            
                throw new ArgumentNullException(nameof(Product));
            productRegisterDto.Status = true;

            Product product = new()
            {
                ProductId = productRegisterDto.ProductId,
                TypeProductId = productRegisterDto.TypeProductId,
                ConsumableId = productRegisterDto.ConsumableId,
                Title = productRegisterDto.Title,
                Color = productRegisterDto.Color,
                Characteristic= productRegisterDto.Characteristic,
                Price= productRegisterDto.Price,
                Status= productRegisterDto.Status,
            };
            _context.Add(product);
        }

        public List<Consumable> GetProductData(string para)
        {
            
            var consumable = _context.Consumables.Where(p => p.Title == para).ToList();

            return consumable;
        }

        public List<TypeProduct> GetTypes()
        {
            var types = _context.TypeProducts
                        .Where(t => t.Status)
                        .OrderBy(t => t.Title)
                        .ToList();

            return types;
        }

        public void Edit(ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts)
        {
            if (productRegisterDto != null)
            {
                Product product = new()
                {
                    ProductId = productRegisterDto.ProductId,
                    TypeProductId = productRegisterDto.TypeProductId,
                    ConsumableId = productRegisterDto.ConsumableId,
                    Title = productRegisterDto.Title,
                    Color = productRegisterDto.Color,
                    Characteristic = productRegisterDto.Characteristic,
                    Price = productRegisterDto.Price,
                    Status = productRegisterDto.Status,
                };
                _context.Update(product);
            }
        }

        public async Task<ProductRegisterDto> GetProductId(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            
            if (product == null)
                return null;

            var productRegisterDto = new ProductRegisterDto();
            productRegisterDto.ProductId = product.ProductId;
            productRegisterDto.TypeProductId = product.TypeProductId;
            productRegisterDto.ConsumableId = product.ConsumableId;
            productRegisterDto.Title = product.Title;
            productRegisterDto.Color = product.Color;
            productRegisterDto.Characteristic = product.Characteristic;
            productRegisterDto.Price = product.Price;

            return productRegisterDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<ProductDto> ListProductDto = new();
            var products= await _context.Products.Include(x=> x.TypeProduct).ToListAsync();
            products.ForEach(p =>
            {
                ProductDto productDto = new()
                {
                    ProductId= p.ProductId,
                    TypeProductId= p.TypeProduct.Title,
                    Title = p.Title,
                    Characteristic= p.Characteristic,
                    Price= p.Price,
                    Status= (GetEstado(p.Status)== "Activo")
                };
                ListProductDto.Add(productDto);
            });
            return ListProductDto;
        }

        public async Task<IEnumerable<ProductDetailDto>> GetProductsDetails()
        {
            List<ProductDetailDto> ListProductDto = new();
            var products = await _context.Products.Include(x=> x.TypeProduct).ToListAsync();
            products.ForEach(p =>
            {
                ProductDetailDto productDetailDto = new()
                {
                    ProductId = p.ProductId,
                    TypeProductId = p.TypeProduct.Title,
                    ConsumableId = p.Consumable.Title,
                    Title = p.Title,
                    Color = p.Color,
                    Characteristic = p.Characteristic,
                    Price = p.Price,
                    Status = (GetEstado(p.Status) == "Activo")
                };
                ListProductDto.Add(productDetailDto);
            });
            return ListProductDto;
        }

        private string GetEstado(bool status)
        {
            if (status)
                return "Activo";
            else
                return "Inactivo";
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
