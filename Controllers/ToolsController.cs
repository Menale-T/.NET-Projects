using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1.TMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0.ViewModel;

namespace SUP_INV1._0.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tools
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tools.ToListAsync());
        }




        public IActionResult SearchForm()
        {
            return View();
        }






        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View(await _context.Tools.Where(item => item.Name.Contains(SearchPhrase)).ToListAsync());
        }




        public async Task<IActionResult> TAnalysis(int? id, ViewModel1 model, int topN = 10)
        {

            var tools = await _context.Tools.FindAsync(id);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastTwoWeeks = DateTime.Today.AddDays(-14);
            var PastThreeWeeks = DateTime.Today.AddDays(-21);
            var PastMonth = DateTime.Today.AddDays(-28);


            var totalNumberOfRecords = await _context.Tools.CountAsync();
            var totalQuantityOfRecordedItems = await _context.Tools.SumAsync(tools => tools.Quantity);
            var totalStockInPrice = await _context.Tools.SumAsync(tools => (tools.Quantity * tools.Stock_In_Price_Per_Item));
            var totalStockOutPrice = await _context.Tools.SumAsync(tools => (tools.Quantity * tools.Stock_Out_Price_Per_Item));



            var totalQuantitySoldToday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold > today && tools.TOOLSRecDateSold < tomorrow).SumAsync(tools => tools.TOOLSRecSoldQuantity);
            var totalQuantitySoldYesterday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold <= today && tools.TOOLSRecDateSold >= yesterday).SumAsync(tools => tools.TOOLSRecSoldQuantity);
            var totalQuantitySoldInLastweek = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastWeek && tools.TOOLSRecDateSold <= today).SumAsync(tools => tools.TOOLSRecSoldQuantity);
            var totalQuantitySoldInLastTwoweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastTwoWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => tools.TOOLSRecSoldQuantity);
            var totalQuantitySoldInLastThreeweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastThreeWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => tools.TOOLSRecSoldQuantity);
            var totalQuantitySoldInLastMonth = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastMonth && tools.TOOLSRecDateSold <= today).SumAsync(tools => tools.TOOLSRecSoldQuantity);



            var totalStockinpriceToday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold > today && tools.TOOLSRecDateSold < tomorrow).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));
            var totalStockinpriceYesterday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold <= today && tools.TOOLSRecDateSold >= yesterday).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));
            var totalStockinpriceInLastweek = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastWeek && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));
            var totalStockinpriceInLastTwoweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastTwoWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));
            var totalStockinpriceInLastThreeweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastThreeWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));
            var totalStockinpriceInLastMonth = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastMonth && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockInPrice * tools.TOOLSRecSoldQuantity));




            var totalStockoutpriceToday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold > today && tools.TOOLSRecDateSold < tomorrow).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));
            var totalStockoutpriceYesterday = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold <= today && tools.TOOLSRecDateSold >= yesterday).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));
            var totalStockoutpriceInLastweek = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastWeek && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));
            var totalStockoutpriceInLastTwoweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= pastTwoWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));
            var totalStockoutpriceInLastThreeweeks = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastThreeWeeks && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));
            var totalStockoutpriceInLastMonth = await _context.TOOLSSALESRECORD.Where(tools => tools.TOOLSRecDateSold >= PastMonth && tools.TOOLSRecDateSold <= today).SumAsync(tools => (tools.TOOLSRecStockOutPrice * tools.TOOLSRecSoldQuantity));




            var totalIncomeToday = totalStockoutpriceToday - totalStockinpriceToday;
            var totalIncomeYesterday = totalStockoutpriceYesterday - totalStockinpriceYesterday;
            var totalIncomeInLastweek = totalStockoutpriceInLastweek - totalStockinpriceInLastweek;
            var totalIncomeInLastTwoweeks = totalStockoutpriceInLastTwoweeks - totalStockinpriceInLastTwoweeks;
            var totalIncomeInLastThreeweeks = totalStockoutpriceInLastThreeweeks - totalStockinpriceInLastThreeweeks;
            var totalIncomeInLastMonth = totalStockoutpriceInLastMonth - totalStockinpriceInLastMonth;


            //solditems for today
            var todaysSoldItems = await (from record in _context.TOOLSSALESRECORD
                                         where record.TOOLSRecDateSold > today && record.TOOLSRecDateSold < tomorrow
                                         group record by record.TOOLSRecName into grouped
                                         select new
                                         {

                                             ProductName = grouped.Key,
                                             TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                             TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                             TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                             TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                         })
                                     .OrderByDescending(x => x.TotalQuantitySold)

                                     .ToListAsync();


            //mostsolditems for all time
            var mostSoldItems = await (from record in _context.TOOLSSALESRECORD
                                       group record by record.TOOLSRecName into grouped
                                       select new
                                       {

                                           ProductName = grouped.Key,
                                           TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                           TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                           TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                           TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                       })
                                     .OrderByDescending(x => x.TotalQuantitySold)
                                     .Take(topN)
                                     .ToListAsync();



            //mostsolditems for previous day

            var mostSoldItemsInTheLastDay = await (from record in _context.TOOLSSALESRECORD
                                                   where record.TOOLSRecDateSold <= today && record.TOOLSRecDateSold >= yesterday
                                                   group record by record.TOOLSRecName into grouped
                                                   select new
                                                   {
                                                       ProductName = grouped.Key,
                                                       TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                                       TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                                       TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                                       TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                                   })
                                          .OrderByDescending(x => x.TotalQuantitySold)
                                          .ToListAsync();


            //mostsolditems for previous week
            var mostSoldItemsInTheLastWeek = await (from record in _context.TOOLSSALESRECORD
                                                    where record.TOOLSRecDateSold >= pastWeek && record.TOOLSRecDateSold <= today
                                                    group record by record.TOOLSRecName into grouped
                                                    select new
                                                    {
                                                        ProductName = grouped.Key,
                                                        TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                                        TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                                        TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                                        TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                                    })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous Two weeks
            var mostSoldItemsInTheLastTwoWeeks = await (from record in _context.TOOLSSALESRECORD
                                                        where record.TOOLSRecDateSold >= pastTwoWeeks && record.TOOLSRecDateSold <= today
                                                        group record by record.TOOLSRecName into grouped
                                                        select new
                                                        {
                                                            ProductName = grouped.Key,
                                                            TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                                            TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                                            TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                                            TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                                        })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastThreeWeeks = await (from record in _context.TOOLSSALESRECORD
                                                          where record.TOOLSRecDateSold >= PastThreeWeeks && record.TOOLSRecDateSold <= today
                                                          group record by record.TOOLSRecName into grouped
                                                          select new
                                                          {
                                                              ProductName = grouped.Key,
                                                              TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                                              TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                                              TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                                              TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                                          })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();

            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastMonth = await (from record in _context.TOOLSSALESRECORD
                                                     where record.TOOLSRecDateSold >= PastMonth && record.TOOLSRecDateSold <= today
                                                     group record by record.TOOLSRecName into grouped
                                                     select new
                                                     {
                                                         ProductName = grouped.Key,
                                                         TotalQuantitySold = grouped.Sum(r => r.TOOLSRecSoldQuantity),
                                                         TotalStInPr = grouped.Sum(r => r.TOOLSRecStockInPrice),
                                                         TotalStOuPr = grouped.Sum(r => r.TOOLSRecStockOutPrice),
                                                         TotalProfit = grouped.Sum(r => (r.TOOLSRecSoldQuantity * r.TOOLSRecStockOutPrice) - (r.TOOLSRecSoldQuantity * r.TOOLSRecStockInPrice))
                                                     })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //Sold out items
            var soldOutItems = await (from record in _context.Tools
                                      where record.Quantity == 0
                                      group record by record.Name into grouped
                                      select new
                                      {

                                          ProductName = grouped.Key,
                                          TotalQuantity = grouped.Sum(r => r.Quantity),
                                          TotalStInPr = grouped.Sum(r => r.Stock_In_Price_Per_Item),
                                          TotalStOuPr = grouped.Sum(r => r.Stock_Out_Price_Per_Item),
                                          TotalProfit = grouped.Sum(r => (r.Quantity * r.Stock_Out_Price_Per_Item) - (r.Quantity * r.Stock_In_Price_Per_Item))
                                      })
                                     .OrderByDescending(x => x.TotalQuantity)

                                     .ToListAsync();

            //You might want to create a view model for cleaner separation.
            var viewModel = new ViewModel1 //Create a view model
            {


                TotNumItemsTools = totalNumberOfRecords,
                TotQuantityOfItemsTools = totalQuantityOfRecordedItems,
                TotalStInPriceTools = totalStockInPrice,
                TotalStOPriceTools = totalStockOutPrice,
                NetIncomeTools = totalStockOutPrice - totalStockInPrice,



                ToTotalAmountSoldToday = totalQuantitySoldToday,
                ToTotalAmountSoldYesterday = totalQuantitySoldYesterday,
                ToTotalAmountSoldPastWeek = totalQuantitySoldInLastweek,
                ToTotalAmountSoldPastTwoWeeks = totalQuantitySoldInLastTwoweeks,
                ToTotalAmountSoldPastThreeWeeks = totalQuantitySoldInLastThreeweeks,
                ToTotalAmountSoldPastMonth = totalQuantitySoldInLastMonth,



                ToTotalStockInPriceOfItemsSoldToday = totalStockinpriceToday,
                ToTotalStockInPriceOfItemsSoldYesterday = totalStockinpriceYesterday,
                ToTotalStockInPriceOfItemsSoldLastWeek = totalStockinpriceInLastweek,
                ToTotalStockInPriceOfItemsSoldLastTwoWeeks = totalStockinpriceInLastTwoweeks,
                ToTotalStockInPriceOfItemsSoldLastThreeWeeks = totalStockinpriceInLastThreeweeks,
                ToTotalStockInPriceOfItemsSoldLastMonth = totalStockinpriceInLastMonth,




                ToTotalStockOutPriceOfItemsSoldToday = totalStockoutpriceToday,
                ToTotalStockOutPriceOfItemsSoldYesterday = totalStockoutpriceYesterday,
                ToTotalStockOutPriceOfItemsSoldLastWeek = totalStockoutpriceInLastweek,
                ToTotalStockOutPriceOfItemsSoldLastTwoWeeks = totalStockoutpriceInLastTwoweeks,
                ToTotalStockOutPriceOfItemsSoldLastThreeWeeks = totalStockoutpriceInLastThreeweeks,
                ToTotalStockOutPriceOfItemsSoldLastMonth = totalStockoutpriceInLastMonth,





                ToTotalIncomeOfItemsSoldToday = totalIncomeToday,
                ToTotalIncomeOfItemsSoldYesterday = totalIncomeYesterday,
                ToTotalIncomeOfItemsSoldLastWeek = totalIncomeInLastweek,
                ToTotalIncomeOfItemsSoldLastTwoWeeks = totalIncomeInLastTwoweeks,
                ToTotalIncomeOfItemsSoldLastThreeWeeks = totalIncomeInLastThreeweeks,
                ToTotalIncomeOfItemsSoldLastMonth = totalIncomeInLastMonth,






                TvarSoldOutItems = soldOutItems.Select(item => new TSoldOutItems
                {
                    TItemNameSoldout = item.ProductName,
                    TItemQuantitySoldout = item.TotalQuantity,
                    TItemStockinpriceSoldout = item.TotalStInPr,
                    TItemStockoutpriceSoldout = item.TotalStOuPr,
                    TItemNetIncomeSoldout = item.TotalProfit,

                }).ToList(),



                TSoldItemsToday = todaysSoldItems.Select(item => new TSoldItemsToday
                {
                    TProNameToday = item.ProductName,
                    TTotQuaSoldToday = item.TotalQuantitySold,
                    TStockinpriceToday = item.TotalStInPr,
                    TStockoutpriceToday = item.TotalStOuPr,
                    TNetIncomeFpToday = item.TotalProfit,



                }).ToList(),


                TMostSoldItems = mostSoldItems.Select(item => new TMostSoldItem
                {

                    TProName = item.ProductName,
                    TTotQuaSold = item.TotalQuantitySold,
                    TTotStockinprice = item.TotalStInPr,
                    TTotStockoutprice = item.TotalStOuPr,
                    TNetIncomeFp = item.TotalProfit,



                }).ToList(),


                TMostSoldItemsPreDay = mostSoldItemsInTheLastDay.Select(item => new TMostSoldItemsPreDay
                {




                    TProNamePreDay = item.ProductName,
                    TTotQuaSoldPreDay = item.TotalQuantitySold,
                    TStockinpricePreDay = item.TotalStInPr,
                    TStockoutpricePreDay = item.TotalStOuPr,
                    TNetIncomeFpPreDay = item.TotalProfit


                }).ToList(),


                TMostSoldItemsPreWeek = mostSoldItemsInTheLastWeek.Select(item => new TMostSoldItemsPreWeek
                {


                    TProNamePreWeek = item.ProductName,
                    TTotQuaSoldPreWeek = item.TotalQuantitySold,
                    TStockinpricePreWeek = item.TotalStInPr,
                    TStockoutpricePreWeek = item.TotalStOuPr,
                    TNetIncomeFpPreWeek = item.TotalProfit
                }).ToList(),

                TMostSoldItemsPreTwoWeeks = mostSoldItemsInTheLastTwoWeeks.Select(item => new TMostSoldItemsPreTwoWeeks
                {
                    TProNamePreTwoWeeks = item.ProductName,
                    TTotQuaSoldPreTwoWeeks = item.TotalQuantitySold,
                    TStockinpricePreTwoWeeks = item.TotalStInPr,
                    TStockoutpricePreTwoWeeks = item.TotalStOuPr,
                    TNetIncomeFpPreTwoWeeks = item.TotalProfit
                }).ToList(),


                TMostSoldItemsPreThreeWeeks = mostSoldItemsInTheLastThreeWeeks.Select(item => new TMostSoldItemsPreThreeWeeks
                {
                    TProNamePreThreeWeeks = item.ProductName,
                    TTotQuaSoldPreThreeWeeks = item.TotalQuantitySold,
                    TStockinpricePreThreeWeeks = item.TotalStInPr,
                    TStockoutpricePreThreeWeeks = item.TotalStOuPr,
                    TNetIncomeFpPreThreeWeeks = item.TotalProfit
                }).ToList(),


                TMostSoldItemsPreMonth = mostSoldItemsInTheLastMonth.Select(item => new TMostSoldItemsPreMonth
                {
                    TProNamePreMonth = item.ProductName,
                    TTotQuaSoldPreMonth = item.TotalQuantitySold,
                    TStockinpricePreMonth = item.TotalStInPr,
                    TStockoutpricePreMonth = item.TotalStOuPr,
                    TNetIncomeFpPreMonth = item.TotalProfit
                }).ToList()
            };
            return View(viewModel);
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools
                .FirstOrDefaultAsync(m => m.TID == id);
            if (tools == null)
            {
                return NotFound();
            }

            return View(tools);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quantity,Description,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Tools tools)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tools);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tools);
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools.FindAsync(id);
            if (tools == null)
            {
                return NotFound();
            }
            return View(tools);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quantity,Description,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Tools tools)
        {
            if (id != tools.TID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tools);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolsExists(tools.TID))
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
            return View(tools);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools
                .FirstOrDefaultAsync(m => m.TID == id);
            if (tools == null)
            {
                return NotFound();
            }

            return View(tools);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tools = await _context.Tools.FindAsync(id);
            if (tools != null)
            {
                _context.Tools.Remove(tools);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> DeleteRequiredQuantity(int? id, int TRequiredQuantity)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools.FirstOrDefaultAsync(m => m.TID == id);
            var item = await _context.Tools.FindAsync(id); // Replace MyItems with your entity set name




            if (tools == null)
            {
                return NotFound();
            }

            return View(tools);
        }


        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("DeleteRequiredQuantity")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredDeleteConfirmed(int id, int TRequiredQuantity)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input." });
            }

            var item = await _context.Tools.FindAsync(id);

            if (item == null)
            {
                return Json(new { success = false, message = "Item not found." });
            }



            if (TRequiredQuantity <= 0)
            {
                return Json(new { success = false, message = "Negative or Null is not Valid." });
            }


            if (item.Quantity < TRequiredQuantity)
            {
                return Json(new { success = false, message = "Insufficient amount." });
            }




            try
            {





                // 1. Create the audit record *before* deleting the original item
                var toolsSalesRecord = new TOOLSSALESRECORD
                {

                    TOOLSRecName = item.Name,
                    TOOLSRecSoldQuantity = TRequiredQuantity,
                    TOOLSRecDescription = item.Description,
                    TOOLSRecStockInPrice = item.Stock_In_Price_Per_Item,
                    TOOLSRecStockOutPrice = item.Stock_Out_Price_Per_Item,
                    TOOLSRecDateSold = DateTime.Now,
                    TOOLSRecSupplierEmail = item.Supplier_Email

                };
                await _context.TOOLSSALESRECORD.AddAsync(toolsSalesRecord);

                item.Quantity -= TRequiredQuantity;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SearchForm));

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Error reducing amount: " + ex.Message });
            }


        }


        private bool ToolsExists(int id)
        {
            return _context.Tools.Any(e => e.TID == id);
        }
    }
}
