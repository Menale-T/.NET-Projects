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
    public class PHARMACEUTICALSSALESRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PHARMACEUTICALSSALESRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PHARMACEUTICALSSALESRECORDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PHARMACEUTICALSSALESRECORD.ToListAsync());
        }


        public async Task<IActionResult> PHAFutureDemandPrediction()
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                var itemNames = await _context.PHARMACEUTICALSSALESRECORD
                     .Select(f => f.PHARecName)
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

        // GET: PHARMACEUTICALSSALESRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHARMACEUTICALSSALESRECORD = await _context.PHARMACEUTICALSSALESRECORD
                .FirstOrDefaultAsync(m => m.PHARecID == id);
            if (pHARMACEUTICALSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(pHARMACEUTICALSSALESRECORD);
        }

        // GET: PHARMACEUTICALSSALESRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PHARMACEUTICALSSALESRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PHARecID,PHARecName,PHARecSoldQuantity,PHARecDescription,PHARecStockInPrice,PHARecStockOutPrice,PHARecDateSold,PHARecSupplierEmail")] PHARMACEUTICALSSALESRECORD pHARMACEUTICALSSALESRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pHARMACEUTICALSSALESRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pHARMACEUTICALSSALESRECORD);
        }

        // GET: PHARMACEUTICALSSALESRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHARMACEUTICALSSALESRECORD = await _context.PHARMACEUTICALSSALESRECORD.FindAsync(id);
            if (pHARMACEUTICALSSALESRECORD == null)
            {
                return NotFound();
            }
            return View(pHARMACEUTICALSSALESRECORD);
        }

        // POST: PHARMACEUTICALSSALESRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PHARecID,PHARecName,PHARecSoldQuantity,PHARecDescription,PHARecStockInPrice,PHARecStockOutPrice,PHARecDateSold,PHARecSupplierEmail")] PHARMACEUTICALSSALESRECORD pHARMACEUTICALSSALESRECORD)
        {
            if (id != pHARMACEUTICALSSALESRECORD.PHARecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pHARMACEUTICALSSALESRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PHARMACEUTICALSSALESRECORDExists(pHARMACEUTICALSSALESRECORD.PHARecID))
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
            return View(pHARMACEUTICALSSALESRECORD);
        }

        // GET: PHARMACEUTICALSSALESRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHARMACEUTICALSSALESRECORD = await _context.PHARMACEUTICALSSALESRECORD
                .FirstOrDefaultAsync(m => m.PHARecID == id);
            if (pHARMACEUTICALSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(pHARMACEUTICALSSALESRECORD);
        }

        // POST: PHARMACEUTICALSSALESRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pHARMACEUTICALSSALESRECORD = await _context.PHARMACEUTICALSSALESRECORD.FindAsync(id);
            if (pHARMACEUTICALSSALESRECORD != null)
            {
                _context.PHARMACEUTICALSSALESRECORD.Remove(pHARMACEUTICALSSALESRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PHARMACEUTICALSSALESRECORDExists(int id)
        {
            return _context.PHARMACEUTICALSSALESRECORD.Any(e => e.PHARecID == id);
        }
    }
}
