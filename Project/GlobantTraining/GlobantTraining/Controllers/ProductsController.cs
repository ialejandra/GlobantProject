using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Models.Dtos;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;
using FluentAssertions;

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
            IEnumerable<ProductDto> productDto =  await _productBusiness.GetProducts();
            return productDto != null?
                          View(productDto):
                          Problem("No se encuentra e producto");

        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Producto";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto Product)
        {
            if (ModelState.IsValid)
            {
                await _productBusiness.Create(Product);
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }


        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _productBusiness.ProductExists == null)
        //    {
        //        return NotFound();
        //    }

        //    var Product = await _productBusiness.GetProductId.FindAsync(id);
        //    if (Product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Product);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ProductDto Product)
        //{
        //    if (id != Product.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _productBusiness.Edit(Product);
        //            await _productBusiness.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(Product.ProductId))
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
        //    return View(Product);
        //}

        //private bool ProductExists(int id)
        //{
        //    return (_productBusiness.GetProducts.Any(e => e.ProductId == id)).GetValueOrDefault();
        //}
    
    }

    //public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null || _productBusiness.Products == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _productBusiness.Products
    //            .Include(p => p.Consumable)
    //            .Include(p => p.TypeProduct)
    //            .FirstOrDefaultAsync(m => m.ProductId == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }


    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _productBusiness.Products == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _productBusiness.Products
    //            .Include(p => p.Consumable)
    //            .Include(p => p.TypeProduct)
    //            .FirstOrDefaultAsync(m => m.ProductId == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }


    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_productBusiness.Products == null)
    //        {
    //            return Problem("Entity set 'AppDbContext.Products'  is null.");
    //        }
    //        var product = await _productBusiness.Products.FindAsync(id);
    //        if (product != null)
    //        {
    //            _productBusiness.Products.Remove(product);
    //        }

    //        await _productBusiness.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

 
    }

