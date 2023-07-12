
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Models.Dtos;
using GlobantTraining.DAL;
using GlobantTraining.DAL.Entities;
using GlobantTraining.Controllers;

namespace GlobantTraining.Controllers
{
    public class TypeProductsController : Controller
    {
        private readonly ITypeProductBusiness _typeProductBusiness;
        public TypeProductsController(ITypeProductBusiness typeProductBusiness)
        {
            _typeProductBusiness = typeProductBusiness;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Tipo Producto";
            return View(await _typeProductBusiness.GetTypeProducts());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Tipo de Producto";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeProductDto typeProductDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Titulo = "Crear Tipo Producto";
                    _typeProductBusiness.Create(typeProductDto);
                    var save = await _typeProductBusiness.SaveChanges();
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
            return View(typeProductDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    var typeProduct = await _typeProductBusiness.GetTypeProductId(id.Value);
                    if (typeProduct != null)
                    {
                        ViewBag.Titulo = "Editar Tipo Producto";
                        return View(typeProduct);
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
        public async Task<IActionResult> Edit(int id, TypeProductDto typeProductDto)
        {
            if (id != typeProductDto.TypeProductId)
            {
                try
                {
                    _typeProductBusiness.Edit(typeProductDto);
                    var edit = await _typeProductBusiness.SaveChanges();
                    if (edit)
                    {
                        return RedirectToAction();
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
                    _typeProductBusiness.Edit(typeProductDto);
                    var edit = await _typeProductBusiness.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_typeProductBusiness.TypeProductExists(typeProductDto.TypeProductId))
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
            return View(typeProductDto);
        }
    }
}


//private readonly AppDbContext _context;

//public TypeProductsController(AppDbContext context)
//{
//    _context = context;
//}


//public async Task<IActionResult> Index()
//{
//    ViewBag.Titulo = "Tipo de Producto";
//    return _context.TypeProducts != null ?
//                  View(await _context.TypeProducts.ToListAsync()) :
//                  Problem("No se encuentra el tipo de producto");

//}


//[HttpGet]
//public IActionResult Create()
//{
//    ViewBag.Titulo = "Crear Tipo de Producto";
//    return View();
//}


//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create(TypeProduct typeProduct)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(typeProduct);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    return View(typeProduct);
//}


//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null || _context.TypeProducts == null)
//    {
//        return NotFound();
//    }

//    var typeProduct = await _context.TypeProducts.FindAsync(id);
//    if (typeProduct == null)
//    {
//        return NotFound();
//    }
//    return View(typeProduct);
//}


//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, TypeProduct typeProduct)
//{
//    if (id != typeProduct.TypeProductId)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(typeProduct);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!TypeProductExists(typeProduct.TypeProductId))
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
//    return View(typeProduct);
//}

//private bool TypeProductExists(int id)
//{
//    return (_context.TypeProducts?.Any(e => e.TypeProductId == id)).GetValueOrDefault();
//}
