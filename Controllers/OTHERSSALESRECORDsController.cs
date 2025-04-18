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
    public class OTHERSSALESRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OTHERSSALESRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: OTHERSSALESRECORDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OTHERSSALESRECORD.ToListAsync());
        }


        public async Task<IActionResult> OTFutureDemandPrediction()
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                var itemNames = await _context.OTHERSSALESRECORD
                     .Select(f => f.OTHRecName)
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

        // GET: OTHERSSALESRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oTHERSSALESRECORD = await _context.OTHERSSALESRECORD
                .FirstOrDefaultAsync(m => m.OTHRecID == id);
            if (oTHERSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(oTHERSSALESRECORD);
        }

        // GET: OTHERSSALESRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OTHERSSALESRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OTHRecID,OTHRecName,OTHRecSoldQuantity,OTHRecDescription,OTHRecStockInPrice,OTHRecStockOutPrice,OTHRecDateSold,OTHRecSupplierEmail")] OTHERSSALESRECORD oTHERSSALESRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oTHERSSALESRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oTHERSSALESRECORD);
        }

        // GET: OTHERSSALESRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oTHERSSALESRECORD = await _context.OTHERSSALESRECORD.FindAsync(id);
            if (oTHERSSALESRECORD == null)
            {
                return NotFound();
            }
            return View(oTHERSSALESRECORD);
        }

        // POST: OTHERSSALESRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OTHRecID,OTHRecName,OTHRecSoldQuantity,OTHRecDescription,OTHRecStockInPrice,OTHRecStockOutPrice,OTHRecDateSold,OTHRecSupplierEmail")] OTHERSSALESRECORD oTHERSSALESRECORD)
        {
            if (id != oTHERSSALESRECORD.OTHRecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oTHERSSALESRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OTHERSSALESRECORDExists(oTHERSSALESRECORD.OTHRecID))
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
            return View(oTHERSSALESRECORD);
        }

        // GET: OTHERSSALESRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oTHERSSALESRECORD = await _context.OTHERSSALESRECORD
                .FirstOrDefaultAsync(m => m.OTHRecID == id);
            if (oTHERSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(oTHERSSALESRECORD);
        }

        // POST: OTHERSSALESRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oTHERSSALESRECORD = await _context.OTHERSSALESRECORD.FindAsync(id);
            if (oTHERSSALESRECORD != null)
            {
                _context.OTHERSSALESRECORD.Remove(oTHERSSALESRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OTHERSSALESRECORDExists(int id)
        {
            return _context.OTHERSSALESRECORD.Any(e => e.OTHRecID == id);
        }
    }
}

