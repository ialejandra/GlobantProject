using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;

namespace GlobantTraining.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Producto";
            var appDbContext = _context.Products.Include(p => p.Consumable).Include(p => p.TypeProduct);
            return View(await appDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Consumable)
                .Include(p => p.TypeProduct)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Producto";
            ViewData["ConsumableId"] = new SelectList(_context.Consumables, "ConsumableId", "ConsumableId");
            ViewData["TypeProductId"] = new SelectList(_context.TypeProducts, "TypeProductId", "TypeProductId");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Titulo = "Crear Producto";
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsumableId"] = new SelectList(_context.Consumables, "ConsumableId", "ConsumableId", product.ConsumableId);
            ViewData["TypeProductId"] = new SelectList(_context.TypeProducts, "TypeProductId", "TypeProductId", product.TypeProductId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                ViewBag.Titulo = "Editar Producto";
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ConsumableId"] = new SelectList(_context.Consumables, "ConsumableId", "ConsumableId", product.ConsumableId);
            ViewData["TypeProductId"] = new SelectList(_context.TypeProducts, "TypeProductId", "TypeProductId", product.TypeProductId);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                ViewBag.Titulo = "Editar Producto";
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["ConsumableId"] = new SelectList(_context.Consumables, "ConsumableId", "ConsumableId", product.ConsumableId);
            ViewData["TypeProductId"] = new SelectList(_context.TypeProducts, "TypeProductId", "TypeProductId", product.TypeProductId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Consumable)
                .Include(p => p.TypeProduct)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
