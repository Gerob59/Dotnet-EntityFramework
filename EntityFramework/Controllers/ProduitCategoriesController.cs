using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;

namespace EntityFramework.Controllers
{
    public class ProduitCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProduitCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProduitCategories.Include(p => p.Categorie).Include(p => p.Produit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProduitCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProduitCategories == null)
            {
                return NotFound();
            }

            var produitCategorie = await _context.ProduitCategories
                .Include(p => p.Categorie)
                .Include(p => p.Produit)
                .FirstOrDefaultAsync(m => m.ProduitId == id);
            if (produitCategorie == null)
            {
                return NotFound();
            }

            return View(produitCategorie);
        }

        // GET: ProduitCategories/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categories, "ID", "ID");
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ID", "ID");
            return View();
        }

        // POST: ProduitCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduitId,CategorieId")] ProduitCategorie produitCategorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produitCategorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "ID", "ID", produitCategorie.CategorieId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ID", "ID", produitCategorie.ProduitId);
            return View(produitCategorie);
        }

        // GET: ProduitCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProduitCategories == null)
            {
                return NotFound();
            }

            var produitCategorie = await _context.ProduitCategories.FindAsync(id);
            if (produitCategorie == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "ID", "ID", produitCategorie.CategorieId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ID", "ID", produitCategorie.ProduitId);
            return View(produitCategorie);
        }

        // POST: ProduitCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduitId,CategorieId")] ProduitCategorie produitCategorie)
        {
            if (id != produitCategorie.ProduitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produitCategorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitCategorieExists(produitCategorie.ProduitId))
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
            ViewData["CategorieId"] = new SelectList(_context.Categories, "ID", "ID", produitCategorie.CategorieId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ID", "ID", produitCategorie.ProduitId);
            return View(produitCategorie);
        }

        // GET: ProduitCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProduitCategories == null)
            {
                return NotFound();
            }

            var produitCategorie = await _context.ProduitCategories
                .Include(p => p.Categorie)
                .Include(p => p.Produit)
                .FirstOrDefaultAsync(m => m.ProduitId == id);
            if (produitCategorie == null)
            {
                return NotFound();
            }

            return View(produitCategorie);
        }

        // POST: ProduitCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProduitCategories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProduitCategories'  is null.");
            }
            var produitCategorie = await _context.ProduitCategories.FindAsync(id);
            if (produitCategorie != null)
            {
                _context.ProduitCategories.Remove(produitCategorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitCategorieExists(int id)
        {
          return (_context.ProduitCategories?.Any(e => e.ProduitId == id)).GetValueOrDefault();
        }
    }
}
