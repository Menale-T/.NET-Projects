using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using SUP_INV1._0.ViewModel;

namespace SPM_INV_1._0.Controllers
{
    public class TOOLSSALESRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TOOLSSALESRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TOOLSSALESRECORDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TOOLSSALESRECORD.ToListAsync());
        }



        public async Task<IActionResult> TFutureDemandPrediction()
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                var itemNames = await _context.TOOLSSALESRECORD
                     .Select(f => f.TOOLSRecName)
                     .Distinct()
                     .OrderBy(itemName => itemName)
                     .ToListAsync();

                selectListItems = itemNames.Select(item => new SelectListItem { Value = item, Text = item }).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception (using a proper logging framework)
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500); //Or a more user friendly error page
            }
            var viewModel = new ViewModel1
            {
                ItemName = selectListItems,
                // ... other properties ...
            };
            return View(viewModel);
        }
        // GET: TOOLSSALESRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOOLSSALESRECORD = await _context.TOOLSSALESRECORD
                .FirstOrDefaultAsync(m => m.TOOLSRecID == id);
            if (tOOLSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(tOOLSSALESRECORD);
        }

        // GET: TOOLSSALESRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TOOLSSALESRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TOOLSRecID,TOOLSRecName,TOOLSRecSoldQuantity,TOOLSRecDescription,TOOLSRecStockInPrice,TOOLSRecStockOutPrice,TOOLSRecDateSold,TOOLSRecSupplierEmail")] TOOLSSALESRECORD tOOLSSALESRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOOLSSALESRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tOOLSSALESRECORD);
        }

        // GET: TOOLSSALESRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOOLSSALESRECORD = await _context.TOOLSSALESRECORD.FindAsync(id);
            if (tOOLSSALESRECORD == null)
            {
                return NotFound();
            }
            return View(tOOLSSALESRECORD);
        }

        // POST: TOOLSSALESRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TOOLSRecID,TOOLSRecName,TOOLSRecSoldQuantity,TOOLSRecDescription,TOOLSRecStockInPrice,TOOLSRecStockOutPrice,TOOLSRecDateSold,TOOLSRecSupplierEmail")] TOOLSSALESRECORD tOOLSSALESRECORD)
        {
            if (id != tOOLSSALESRECORD.TOOLSRecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOOLSSALESRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOOLSSALESRECORDExists(tOOLSSALESRECORD.TOOLSRecID))
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
            return View(tOOLSSALESRECORD);
        }

        // GET: TOOLSSALESRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOOLSSALESRECORD = await _context.TOOLSSALESRECORD
                .FirstOrDefaultAsync(m => m.TOOLSRecID == id);
            if (tOOLSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(tOOLSSALESRECORD);
        }

        // POST: TOOLSSALESRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOOLSSALESRECORD = await _context.TOOLSSALESRECORD.FindAsync(id);
            if (tOOLSSALESRECORD != null)
            {
                _context.TOOLSSALESRECORD.Remove(tOOLSSALESRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOOLSSALESRECORDExists(int id)
        {
            return _context.TOOLSSALESRECORD.Any(e => e.TOOLSRecID == id);
        }
    }
}
