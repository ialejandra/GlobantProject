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
    public class TypeUsersController : Controller
    {
        private readonly AppDbContext _context;

        public TypeUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TypeUsers
        public async Task<IActionResult> Index()
        {
              return _context.TypeUsers != null ? 
                          View(await _context.TypeUsers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TypeUsers'  is null.");
        }

        // GET: TypeUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeUsers == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUsers
                .FirstOrDefaultAsync(m => m.TypeUserId == id);
            if (typeUser == null)
            {
                return NotFound();
            }

            return View(typeUser);
        }

        // GET: TypeUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeUserId,Title")] TypeUser typeUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeUser);
        }

        // GET: TypeUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeUsers == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUsers.FindAsync(id);
            if (typeUser == null)
            {
                return NotFound();
            }
            return View(typeUser);
        }

        // POST: TypeUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeUserId,Title")] TypeUser typeUser)
        {
            if (id != typeUser.TypeUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeUserExists(typeUser.TypeUserId))
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
            return View(typeUser);
        }

        // GET: TypeUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeUsers == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUsers
                .FirstOrDefaultAsync(m => m.TypeUserId == id);
            if (typeUser == null)
            {
                return NotFound();
            }

            return View(typeUser);
        }

        // POST: TypeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeUsers == null)
            {
                return Problem("Entity set 'AppDbContext.TypeUsers'  is null.");
            }
            var typeUser = await _context.TypeUsers.FindAsync(id);
            if (typeUser != null)
            {
                _context.TypeUsers.Remove(typeUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeUserExists(int id)
        {
          return (_context.TypeUsers?.Any(e => e.TypeUserId == id)).GetValueOrDefault();
        }
    }
}
