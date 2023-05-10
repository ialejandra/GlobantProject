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
    public class TypeProductsController : Controller
    {
        private readonly AppDbContext _context;

        public TypeProductsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
              return _context.TypeProducts != null ? 
                          View(await _context.TypeProducts.ToListAsync()) :
                          Problem("No se encuentra los tipos de productos");
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeProductId,Title")] TypeProduct typeProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProduct);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeProducts == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProducts.FindAsync(id);
            if (typeProduct == null)
            {
                return NotFound();
            }
            return View(typeProduct);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeProductId,Title")] TypeProduct typeProduct)
        {
            if (id != typeProduct.TypeProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeProductExists(typeProduct.TypeProductId))
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
            return View(typeProduct);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeProducts == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProducts
                .FirstOrDefaultAsync(m => m.TypeProductId == id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            return View(typeProduct);
        }

        // POST: TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeProducts == null)
            {
                return Problem("Entity set 'AppDbContext.TypeProducts'  is null.");
            }
            var typeProduct = await _context.TypeProducts.FindAsync(id);
            if (typeProduct != null)
            {
                _context.TypeProducts.Remove(typeProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProductExists(int id)
        {
          return (_context.TypeProducts?.Any(e => e.TypeProductId == id)).GetValueOrDefault();
        }
    }
}
