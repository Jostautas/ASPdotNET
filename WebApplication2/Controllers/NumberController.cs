using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class NumberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public NumberController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetNumber()
        {
            var users = _userManager.Users;
            return View(users);
        }

        // GET: Number
        public async Task<IActionResult> Index()
        {
              return _context.Number != null ? 
                          View(await _context.Number.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Number'  is null.");
        }

        // GET: Number/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Number == null)
            {
                return NotFound();
            }

            var number = await _context.Number
                .FirstOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // GET: Number/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Number/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Number number)
        {
            if (ModelState.IsValid)
            {
                _context.Add(number);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(number);
        }

        // GET: Number/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Number == null)
            {
                return NotFound();
            }

            var number = await _context.Number.FindAsync(id);
            if (number == null)
            {
                return NotFound();
            }
            return View(number);
        }

        // POST: Number/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Number number)
        {
            if (id != number.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(number);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberExists(number.Id))
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
            return View(number);
        }

        // GET: Number/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Number == null)
            {
                return NotFound();
            }

            var number = await _context.Number
                .FirstOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // POST: Number/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Number == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Number'  is null.");
            }
            var number = await _context.Number.FindAsync(id);
            if (number != null)
            {
                _context.Number.Remove(number);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberExists(int id)
        {
          return (_context.Number?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
