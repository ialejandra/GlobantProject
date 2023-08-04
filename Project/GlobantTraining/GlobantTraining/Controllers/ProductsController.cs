using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Models.Dtos;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;
using GlobantTraining.Business.Business;

namespace GlobantTraining.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        


        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
           
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Producto";
            return View(await _productBusiness.GetProducts());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var productDto = await _productBusiness.GetProductId(id);

            if (productDto == null)
                return NotFound();

            return View(productDto);
        }



        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Producto";
            var typeProducts = _productBusiness.GetTypes();
            //var consumables = _productBusiness.GetConsumable();
            ViewBag.TypeProducts = new SelectList(typeProducts, "TypeProductId", "Title");
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto, List<TypeProduct> typeProducts, List<ProductDetail> productsDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Titulo = "Crear Producto";
                    var typeProduct = _productBusiness.GetTypes();
                    var consumables = _productBusiness.GetConsumable();
                    ViewBag.TypeProducts = new SelectList(typeProduct, "TypeProductId", "Title");
                    

                    _productBusiness.Create(productDto, typeProducts, productsDetail);

                    var save = await _productBusiness.SaveChanges();
                    if (save)
                    {

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {


                    throw;
                }
            }
            

            return View(productDto);
        }


        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    List<Consumable> consumables;
        //    if (id != null)
        //    {
        //        try
        //        {
        //            var product = await _productBusiness.GetProductId(id.Value);
        //            if (product != null)
        //            {
        //                ViewBag.Titulo = "Editar Producto";
        //                var typeProducts = _productBusiness.GetTypes();
        //                ViewBag.TypeProducts = new SelectList(typeProducts, "TypeProductId", "Title");

        //                ProductDetail = new List<ProductDetail>();
        //                foreach (var productDetail in product.ProductDetailId)
        //                {
        //                    var porductDetail = await _productBusiness.GetConsumableById(id);
        //                    ProductDetail.Add(ProductDetail);
        //                }
        //                ViewBag.consumable = new SelectList(consumables, "ConsumableId", "Title");
        //                return View(product);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return NotFound();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ProductDto productDto, List<TypeProduct> typeProducts, List<Consumable> consumables)
        //{
        //    if(id != productDto.ProductId)
        //    {
        //        try
        //        {

        //            _productBusiness.Edit(productDto, typeProducts, consumables);
        //            var edit = await _productBusiness.SaveChanges();
        //            if (edit)
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _productBusiness.Edit(productDto, typeProducts, consumables);
        //            var edit = await _productBusiness.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!_productBusiness.ProductExists(productDto.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productDto);
        //}


        public async Task<IActionResult> SearchConsumables(string searchForm)
        {
            var consumables = await _productBusiness.SearchConsumables(searchForm);
            return Json(consumables);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Products == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.Products'  is null.");
        //    }
        //    var product = await _context.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _context.Products.Remove(product);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
    

}

