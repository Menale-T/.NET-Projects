using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using SUP_INV1._0.ViewModel;
using System.Web;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0;


namespace SUP_INV1._0.Controllers
{
    public class FARMPRODUCTSSALESRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FARMPRODUCTSSALESRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FARMPRODUCTSSALESRECORDs
        public async Task<IActionResult> Index()
        {

            return View(await _context.FARMPRODUCTSSALESRECORD.ToListAsync());
        }

        
        


        // GET: FARMPRODUCTSSALESRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fARMPRODUCTSSALESRECORD = await _context.FARMPRODUCTSSALESRECORD
                .FirstOrDefaultAsync(m => m.FPRecID == id);
            if (fARMPRODUCTSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(fARMPRODUCTSSALESRECORD);
        }

        // GET: FARMPRODUCTSSALESRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FARMPRODUCTSSALESRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FPRecID,FPRecName,FPRecSoldAmount,FPRecDescription,FPRecStockInPrice,FPRecStockOutPrice,FPRecDateSold,FPRecSupplierEmail")] FARMPRODUCTSSALESRECORD fARMPRODUCTSSALESRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fARMPRODUCTSSALESRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fARMPRODUCTSSALESRECORD);
        }

        // GET: FARMPRODUCTSSALESRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fARMPRODUCTSSALESRECORD = await _context.FARMPRODUCTSSALESRECORD.FindAsync(id);
            if (fARMPRODUCTSSALESRECORD == null)
            {
                return NotFound();
            }
            return View(fARMPRODUCTSSALESRECORD);
        }

        // POST: FARMPRODUCTSSALESRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FPRecID,FPRecName,FPRecSoldAmount,FPRecDescription,FPRecStockInPrice,FPRecStockOutPrice,FPRecDateSold,FPRecSupplierEmail")] FARMPRODUCTSSALESRECORD fARMPRODUCTSSALESRECORD)
        {
            if (id != fARMPRODUCTSSALESRECORD.FPRecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fARMPRODUCTSSALESRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FARMPRODUCTSSALESRECORDExists(fARMPRODUCTSSALESRECORD.FPRecID))
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
            return View(fARMPRODUCTSSALESRECORD);
        }

        // GET: FARMPRODUCTSSALESRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fARMPRODUCTSSALESRECORD = await _context.FARMPRODUCTSSALESRECORD
                .FirstOrDefaultAsync(m => m.FPRecID == id);
            if (fARMPRODUCTSSALESRECORD == null)
            {
                return NotFound();
            }

            return View(fARMPRODUCTSSALESRECORD);
        }

        // POST: FARMPRODUCTSSALESRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fARMPRODUCTSSALESRECORD = await _context.FARMPRODUCTSSALESRECORD.FindAsync(id);
            if (fARMPRODUCTSSALESRECORD != null)
            {
                _context.FARMPRODUCTSSALESRECORD.Remove(fARMPRODUCTSSALESRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FARMPRODUCTSSALESRECORDExists(int id)
        {
            return _context.FARMPRODUCTSSALESRECORD.Any(e => e.FPRecID == id);
        }
    }
}
