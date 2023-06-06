using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Business.Business;
using GlobantTraining.Models.Dtos;

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


        //public async Task<IActionResult> Details(int? id)
        //{
            
        //}


        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Producto";
            var typeProducts = _productBusiness.GetTypes();
            ViewBag.TypeProducts = new SelectList(typeProducts, "TypeProductId", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Titulo = "Crear Producto";
                    
                    _productBusiness.Create(productRegisterDto, typeProducts);
                    
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
            
            return View(productRegisterDto);
        }

       

        [HttpPost]
        public IActionResult GetPartialView(string para)
        {
            
            var model = _productBusiness.GetProductData(para);
            return PartialView("_PopView", model);
        }

        [HttpPost]
        public IActionResult GetData(string data)
        {
            //do anything.
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    var product = await _productBusiness.GetProductId(id.Value);
                    if (product != null)
                    {
                        ViewBag.Titulo = "Editar Producto";
                        var typeProducts = _productBusiness.GetTypes();
                        ViewBag.TypeProducts = new SelectList(typeProducts, "TypeProductId", "Title");
                        return View(product);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductRegisterDto productRegisterDto, List<TypeProduct> typeProducts)
        {
            {
                try
                {
                    _productBusiness.Edit(productRegisterDto, typeProducts);
                    var edit = await _productBusiness.SaveChanges();
                    if (edit)
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productBusiness.Edit(productRegisterDto, typeProducts);
                    var edit = await _productBusiness.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productBusiness.ProductExists(productRegisterDto.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productRegisterDto);
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
