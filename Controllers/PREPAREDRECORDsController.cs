using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using SUP_INV1._0.ViewModel;
using SUP_INV1_0;
using static SUP_INV1._0.ViewModel.ViewModel1;

namespace SUP_INV1._0.Controllers
{
    public class PREPAREDRECORDsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string _connectionString = DemandPred.RetrainConnectionString;
        private string _commandString = DemandPred.RetrainCommandString;

        public PREPAREDRECORDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PREPAREDRECORDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PREPAREDRECORD.ToListAsync());
        }


        public async Task<IActionResult> GetInput()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                var itemNames = await _context.PREPAREDRECORD
                     .Select(f => f.RecName)
                     .Distinct()
                     .OrderBy(itemName => itemName)
                     .ToListAsync();

                selectListItems = itemNames.Select(item => new SelectListItem { Value = item, Text = item }).ToList();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500); //Or a more user friendly error page
            }
            var viewModel = new ViewModel1
            {
                ItemName = selectListItems,
                // ... other properties ...
            };
            return View(viewModel);
        }

        // Action to handle filtering and training

        public async Task<IActionResult> Forcast(ViewModel1 model)
        {
            var mlContext = new MLContext();

            // Load the data from the database
            var data = DemandPred.LoadIDataViewFromDatabase(mlContext, _connectionString, _commandString);

            // Filter data using the selected value
            //IDataView filteredData = mlContext.Data.FilterRowsByColumn(data, "ItemID", lowerBound:1, upperBound:4);


            // Train the model using the filtered data
            var Model = DemandPred.RetrainModel(mlContext, data);

            // Save the trained model (optional)
            string outputModelPath = @"C:\Users\user\source\repos\SUP-INV1.0\SUP-INV1.0\DemandPred.mlnet";
            DemandPred.SaveModel(mlContext, Model, data, outputModelPath);
            
            //List<FPForcastResult> FPForcastResults
            // Make predictions
            var predictions = DemandPred.Predict();
            
            for (int i = 0; i < predictions.RecSoldAmountQuantity.Length; i++)
            {
                // Add each prediction to the list
                model.FPForcastResults.Add(new FPForcastResult
                {
                    PredictedAmount = predictions.RecSoldAmountQuantity[i],
                    LowerBounds = predictions.RecSoldAmountQuantity_LB[i],
                    UpperBounds = predictions.RecSoldAmountQuantity_UB[i],
                });
            }

            // Return predictions to the view
            return View(model);
            
        }

        // GET: PREPAREDRECORDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pREPAREDRECORD = await _context.PREPAREDRECORD
                .FirstOrDefaultAsync(m => m.RecID == id);
            if (pREPAREDRECORD == null)
            {
                return NotFound();
            }

            return View(pREPAREDRECORD);
        }

        // GET: PREPAREDRECORDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PREPAREDRECORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecID,ItemID,RecName,Category,RecSoldAmountQuantity,RecDescription,RecSt_InPrice,RecSt_OutPrice,RecDateSold,RecSupplierEmail")] PREPAREDRECORD pREPAREDRECORD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pREPAREDRECORD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pREPAREDRECORD);
        }

        // GET: PREPAREDRECORDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pREPAREDRECORD = await _context.PREPAREDRECORD.FindAsync(id);
            if (pREPAREDRECORD == null)
            {
                return NotFound();
            }
            return View(pREPAREDRECORD);
        }

        // POST: PREPAREDRECORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecID,ItemID,RecName,Category,RecSoldAmountQuantity,RecDescription,RecSt_InPrice,RecSt_OutPrice,RecDateSold,RecSupplierEmail")] PREPAREDRECORD pREPAREDRECORD)
        {
            if (id != pREPAREDRECORD.RecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pREPAREDRECORD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PREPAREDRECORDExists(pREPAREDRECORD.RecID))
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
            return View(pREPAREDRECORD);
        }

        // GET: PREPAREDRECORDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pREPAREDRECORD = await _context.PREPAREDRECORD
                .FirstOrDefaultAsync(m => m.RecID == id);
            if (pREPAREDRECORD == null)
            {
                return NotFound();
            }

            return View(pREPAREDRECORD);
        }

        // POST: PREPAREDRECORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pREPAREDRECORD = await _context.PREPAREDRECORD.FindAsync(id);
            if (pREPAREDRECORD != null)
            {
                _context.PREPAREDRECORD.Remove(pREPAREDRECORD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PREPAREDRECORDExists(int id)
        {
            return _context.PREPAREDRECORD.Any(e => e.RecID == id);
        }
    }
}
