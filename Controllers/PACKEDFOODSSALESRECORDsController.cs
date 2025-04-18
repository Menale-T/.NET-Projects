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

namespace SUP_INV1._0.Controllers
{
    public class PACKEDFOODSSALESRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PACKEDFOODSSALESRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PACKEDFOODSSALESRECORDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PACKEDFOODSSALESRECORD.ToListAsync());
        }


        public async Task<IActionResult> PAFutureDemandPrediction()
        {


            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                var itemNames = await _context.PACKEDFOODSSALESRECORD
                     .Select(f => f.PARecName)
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

        // GET: PACKEDFOODSSALESRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACKEDFOODSSALESRECORD = await _context.PACKEDFOODSSALESRECORD
                .FirstOrDefaultAsync(m => m.PARecID == id);
            if (pACKEDFOODSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(pACKEDFOODSSALESRECORD);
        }

        // GET: PACKEDFOODSSALESRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PACKEDFOODSSALESRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PARecID,PARecName,PARecSoldQuantity,PARecDescription,PARecStockInPrice,PARecStockOutPrice,PARecDateSold,PARecSupplierEmail")] PACKEDFOODSSALESRECORD pACKEDFOODSSALESRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pACKEDFOODSSALESRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pACKEDFOODSSALESRECORD);
        }

        // GET: PACKEDFOODSSALESRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACKEDFOODSSALESRECORD = await _context.PACKEDFOODSSALESRECORD.FindAsync(id);
            if (pACKEDFOODSSALESRECORD == null)
            {
                return NotFound();
            }
            return View(pACKEDFOODSSALESRECORD);
        }

        // POST: PACKEDFOODSSALESRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PARecID,PARecName,PARecSoldQuantity,PARecDescription,PARecStockInPrice,PARecStockOutPrice,PARecDateSold,PARecSupplierEmail")] PACKEDFOODSSALESRECORD pACKEDFOODSSALESRECORD)
        {
            if (id != pACKEDFOODSSALESRECORD.PARecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pACKEDFOODSSALESRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PACKEDFOODSSALESRECORDExists(pACKEDFOODSSALESRECORD.PARecID))
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
            return View(pACKEDFOODSSALESRECORD);
        }

        // GET: PACKEDFOODSSALESRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACKEDFOODSSALESRECORD = await _context.PACKEDFOODSSALESRECORD
                .FirstOrDefaultAsync(m => m.PARecID == id);
            if (pACKEDFOODSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(pACKEDFOODSSALESRECORD);
        }

        // POST: PACKEDFOODSSALESRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pACKEDFOODSSALESRECORD = await _context.PACKEDFOODSSALESRECORD.FindAsync(id);
            if (pACKEDFOODSSALESRECORD != null)
            {
                _context.PACKEDFOODSSALESRECORD.Remove(pACKEDFOODSSALESRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PACKEDFOODSSALESRECORDExists(int id)
        {
            return _context.PACKEDFOODSSALESRECORD.Any(e => e.PARecID == id);
        }
    }
}
