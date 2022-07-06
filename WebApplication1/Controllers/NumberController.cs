using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NumberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public NumberController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult getNumber()
        {
            int x = 0;
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                ++x;
            }
            Console.WriteLine(x);
            return View(x);
        }

        // GET: Numbers
        public async Task<IActionResult> Index()
        {
              return _context.Number != null ? 
                          View(await _context.Number.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Number'  is null.");
        }

        // GET: Numbers/Details/5
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

        // GET: Numbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numbers/Create
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

        // GET: Numbers/Edit/5
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

        // POST: Numbers/Edit/5
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

        // GET: Numbers/Delete/5
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

        // POST: Numbers/Delete/5
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
