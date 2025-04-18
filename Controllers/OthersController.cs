using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1.OTMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0.ViewModel;

namespace SUP_INV1._0.Controllers
{
    public class OthersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OthersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<JsonResult> CheckExpiredItems()
        {
            var expiredItems = await _context.Others.Where(i => i.Expiry_Date < DateTime.Now).ToListAsync();
            return Json(new { count = expiredItems.Count });
        }

        // GET: Others
        public async Task<IActionResult> Index()
        {
            return View(await _context.Others.ToListAsync());
        }



        public IActionResult SearchForm()
        {
            return View();
        }


        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View(await _context.Others.Where(item => item.Name.Contains(SearchPhrase)).ToListAsync());
        }


        public async Task<IActionResult> OtAnalysis(int? id, ViewModel1 model, int topN = 10)
        {
            var others = await _context.Others.FindAsync(id);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastTwoWeeks = DateTime.Today.AddDays(-14);
            var PastThreeWeeks = DateTime.Today.AddDays(-21);
            var PastMonth = DateTime.Today.AddDays(-28);


            var totalNumberOfRecords = await _context.Others.CountAsync();
            var totalQuantityOfRecordedItems = await _context.Others.SumAsync(others => others.Quantity);
            var totalStockInPrice = await _context.Others.SumAsync(others => (others.Quantity * others.Stock_In_Price_Per_Item));
            var totalStockOutPrice = await _context.Others.SumAsync(others => (others.Quantity * others.Stock_Out_Price_Per_Item));



            var totalQuantitySoldToday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold > today && others.OTHRecDateSold < tomorrow).SumAsync(others => others.OTHRecSoldQuantity);
            var totalQuantitySoldYesterday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold <= today && others.OTHRecDateSold >= yesterday).SumAsync(others => others.OTHRecSoldQuantity);
            var totalQuantitySoldInLastweek = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastWeek && others.OTHRecDateSold <= today).SumAsync(others => others.OTHRecSoldQuantity);
            var totalQuantitySoldInLastTwoweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastTwoWeeks && others.OTHRecDateSold <= today).SumAsync(others => others.OTHRecSoldQuantity);
            var totalQuantitySoldInLastThreeweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastThreeWeeks && others.OTHRecDateSold <= today).SumAsync(others => others.OTHRecSoldQuantity);
            var totalQuantitySoldInLastMonth = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastMonth && others.OTHRecDateSold <= today).SumAsync(others => others.OTHRecSoldQuantity);



            var totalStockinpriceToday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold > today && others.OTHRecDateSold < tomorrow).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));
            var totalStockinpriceYesterday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold <= today && others.OTHRecDateSold >= yesterday).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));
            var totalStockinpriceInLastweek = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastWeek && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));
            var totalStockinpriceInLastTwoweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastTwoWeeks && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));
            var totalStockinpriceInLastThreeweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastThreeWeeks && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));
            var totalStockinpriceInLastMonth = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastMonth && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockInPrice * others.OTHRecSoldQuantity));




            var totalStockoutpriceToday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold > today && others.OTHRecDateSold < tomorrow).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));
            var totalStockoutpriceYesterday = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold <= today && others.OTHRecDateSold >= yesterday).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));
            var totalStockoutpriceInLastweek = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastWeek && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));
            var totalStockoutpriceInLastTwoweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= pastTwoWeeks && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));
            var totalStockoutpriceInLastThreeweeks = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastThreeWeeks && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));
            var totalStockoutpriceInLastMonth = await _context.OTHERSSALESRECORD.Where(others => others.OTHRecDateSold >= PastMonth && others.OTHRecDateSold <= today).SumAsync(others => (others.OTHRecStockOutPrice * others.OTHRecSoldQuantity));




            var totalIncomeToday = totalStockoutpriceToday - totalStockinpriceToday;
            var totalIncomeYesterday = totalStockoutpriceYesterday - totalStockinpriceYesterday;
            var totalIncomeInLastweek = totalStockoutpriceInLastweek - totalStockinpriceInLastweek;
            var totalIncomeInLastTwoweeks = totalStockoutpriceInLastTwoweeks - totalStockinpriceInLastTwoweeks;
            var totalIncomeInLastThreeweeks = totalStockoutpriceInLastThreeweeks - totalStockinpriceInLastThreeweeks;
            var totalIncomeInLastMonth = totalStockoutpriceInLastMonth - totalStockinpriceInLastMonth;

            //solditems for today
            var todaysSoldItems = await (from record in _context.OTHERSSALESRECORD
                                         where record.OTHRecDateSold > today && record.OTHRecDateSold < tomorrow
                                         group record by record.OTHRecName into grouped
                                         select new
                                         {

                                             ProductName = grouped.Key,
                                             TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                             TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                             TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                             TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                         })
                                     .OrderByDescending(x => x.TotalQuantitySold)

                                     .ToListAsync();


            //mostsolditems for all time
            var mostSoldItems = await (from record in _context.OTHERSSALESRECORD
                                       group record by record.OTHRecName into grouped
                                       select new
                                       {

                                           ProductName = grouped.Key,
                                           TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                           TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                           TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                           TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                       })
                                     .OrderByDescending(x => x.TotalQuantitySold)
                                     .Take(topN)
                                     .ToListAsync();



            //mostsolditems for previous day

            var mostSoldItemsInTheLastDay = await (from record in _context.OTHERSSALESRECORD
                                                   where record.OTHRecDateSold <= today && record.OTHRecDateSold >= yesterday
                                                   group record by record.OTHRecName into grouped
                                                   select new
                                                   {
                                                       ProductName = grouped.Key,
                                                       TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                                       TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                                       TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                                       TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                                   })
                                          .OrderByDescending(x => x.TotalQuantitySold)
                                          .ToListAsync();


            //mostsolditems for previous week
            var mostSoldItemsInTheLastWeek = await (from record in _context.OTHERSSALESRECORD
                                                    where record.OTHRecDateSold >= pastWeek && record.OTHRecDateSold <= today
                                                    group record by record.OTHRecName into grouped
                                                    select new
                                                    {
                                                        ProductName = grouped.Key,
                                                        TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                                        TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                                        TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                                        TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                                    })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous Two weeks
            var mostSoldItemsInTheLastTwoWeeks = await (from record in _context.OTHERSSALESRECORD
                                                        where record.OTHRecDateSold >= pastTwoWeeks && record.OTHRecDateSold <= today
                                                        group record by record.OTHRecName into grouped
                                                        select new
                                                        {
                                                            ProductName = grouped.Key,
                                                            TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                                            TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                                            TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                                            TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                                        })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastThreeWeeks = await (from record in _context.OTHERSSALESRECORD
                                                          where record.OTHRecDateSold >= PastThreeWeeks && record.OTHRecDateSold <= today
                                                          group record by record.OTHRecName into grouped
                                                          select new
                                                          {
                                                              ProductName = grouped.Key,
                                                              TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                                              TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                                              TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                                              TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                                          })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();

            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastMonth = await (from record in _context.OTHERSSALESRECORD
                                                     where record.OTHRecDateSold >= PastMonth && record.OTHRecDateSold <= today
                                                     group record by record.OTHRecName into grouped
                                                     select new
                                                     {
                                                         ProductName = grouped.Key,
                                                         TotalQuantitySold = grouped.Sum(r => r.OTHRecSoldQuantity),
                                                         TotalStInPr = grouped.Sum(r => r.OTHRecStockInPrice),
                                                         TotalStOuPr = grouped.Sum(r => r.OTHRecStockOutPrice),
                                                         TotalProfit = grouped.Sum(r => (r.OTHRecSoldQuantity * r.OTHRecStockOutPrice) - (r.OTHRecSoldQuantity * r.OTHRecStockInPrice))
                                                     })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //items passed maximum shelf life
            var itemsExpired = await (from record in _context.Others
                                      where record.Expiry_Date < tomorrow
                                      group record by record.Name into grouped
                                      select new
                                      {

                                          ProductName = grouped.Key,
                                          TotalAmount = grouped.Sum(r => r.Quantity),
                                          TotalStInPr = grouped.Sum(r => r.Stock_In_Price_Per_Item),
                                          TotalStOuPr = grouped.Sum(r => r.Stock_Out_Price_Per_Item),
                                          TotalProfit = grouped.Sum(r => (r.Quantity * r.Stock_Out_Price_Per_Item) - (r.Quantity * r.Stock_In_Price_Per_Item))
                                      })
                                     .OrderByDescending(x => x.TotalAmount)

                                     .ToListAsync();

            //Sold out items
            var soldOutItems = await (from record in _context.Others
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


                TotNumItemsOth = totalNumberOfRecords,
                TotQuantityOfItemsOth = totalQuantityOfRecordedItems,
                TotalStInPriceOth = totalStockInPrice,
                TotalStOPriceOth = totalStockOutPrice,
                NetIncomeOth = totalStockOutPrice - totalStockInPrice,



                OTTotalAmountSoldToday = totalQuantitySoldToday,
                OTTotalAmountSoldYesterday = totalQuantitySoldYesterday,
                OTTotalAmountSoldPastWeek = totalQuantitySoldInLastweek,
                OTTotalAmountSoldPastTwoWeeks = totalQuantitySoldInLastTwoweeks,
                OTTotalAmountSoldPastThreeWeeks = totalQuantitySoldInLastThreeweeks,
                OTTotalAmountSoldPastMonth = totalQuantitySoldInLastMonth,



                OTTotalStockInPriceOfItemsSoldToday = totalStockinpriceToday,
                OTTotalStockInPriceOfItemsSoldYesterday = totalStockinpriceYesterday,
                OTTotalStockInPriceOfItemsSoldLastWeek = totalStockinpriceInLastweek,
                OTTotalStockInPriceOfItemsSoldLastTwoWeeks = totalStockinpriceInLastTwoweeks,
                OTTotalStockInPriceOfItemsSoldLastThreeWeeks = totalStockinpriceInLastThreeweeks,
                OTTotalStockInPriceOfItemsSoldLastMonth = totalStockinpriceInLastMonth,




                OTTotalStockOutPriceOfItemsSoldToday = totalStockoutpriceToday,
                OTTotalStockOutPriceOfItemsSoldYesterday = totalStockoutpriceYesterday,
                OTTotalStockOutPriceOfItemsSoldLastWeek = totalStockoutpriceInLastweek,
                OTTotalStockOutPriceOfItemsSoldLastTwoWeeks = totalStockoutpriceInLastTwoweeks,
                OTTotalStockOutPriceOfItemsSoldLastThreeWeeks = totalStockoutpriceInLastThreeweeks,
                OTTotalStockOutPriceOfItemsSoldLastMonth = totalStockoutpriceInLastMonth,





                OTTotalIncomeOfItemsSoldToday = totalIncomeToday,
                OTTotalIncomeOfItemsSoldYesterday = totalIncomeYesterday,
                OTTotalIncomeOfItemsSoldLastWeek = totalIncomeInLastweek,
                OTTotalIncomeOfItemsSoldLastTwoWeeks = totalIncomeInLastTwoweeks,
                OTTotalIncomeOfItemsSoldLastThreeWeeks = totalIncomeInLastThreeweeks,
                OTTotalIncomeOfItemsSoldLastMonth = totalIncomeInLastMonth,





                OTvarSoldOutItems = soldOutItems.Select(item => new OTSoldOutItems
                {
                    OTItemNameSoldout = item.ProductName,
                    OTItemQuantitySoldout = item.TotalQuantity,
                    OTItemStockinpriceSoldout = item.TotalStInPr,
                    OTItemStockoutpriceSoldout = item.TotalStOuPr,
                    OTItemNetIncomeSoldout = item.TotalProfit,

                }).ToList(),


                OTItemExpired = itemsExpired.Select(item => new OTExpiredItems
                {

                    OTItemNameExp = item.ProductName,
                    OTItemQuantityExp = item.TotalAmount,
                    OTItemStockinpriceExp = item.TotalStInPr,
                    OTItemStockoutpriceExp = item.TotalStOuPr,
                    OTItemNetIncomeExp = item.TotalProfit,



                }).ToList(),





                OTSoldItemsToday = todaysSoldItems.Select(item => new OTSoldItemsToday
                {
                    OTProNameToday = item.ProductName,
                    OTTotQuaSoldToday = item.TotalQuantitySold,
                    OTStockinpriceToday = item.TotalStInPr,
                    OTStockoutpriceToday = item.TotalStOuPr,
                    OTNetIncomeFpToday = item.TotalProfit,



                }).ToList(),


                OTMostSoldItems = mostSoldItems.Select(item => new OTMostSoldItem
                {

                    OTProName = item.ProductName,
                    OTTotQuaSold = item.TotalQuantitySold,
                    OTTotStockinprice = item.TotalStInPr,
                    OTTotStockoutprice = item.TotalStOuPr,
                    OTNetIncomeFp = item.TotalProfit,



                }).ToList(),




                OTMostSoldItemsPreDay = mostSoldItemsInTheLastDay.Select(item => new OTMostSoldItemsPreDay
                {




                    OTProNamePreDay = item.ProductName,
                    OTTotQuaSoldPreDay = item.TotalQuantitySold,
                    OTStockinpricePreDay = item.TotalStInPr,
                    OTStockoutpricePreDay = item.TotalStOuPr,
                    OTNetIncomeFpPreDay = item.TotalProfit


                }).ToList(),


                OTMostSoldItemsPreWeek = mostSoldItemsInTheLastWeek.Select(item => new OTMostSoldItemsPreWeek
                {


                    OTProNamePreWeek = item.ProductName,
                    OTTotQuaSoldPreWeek = item.TotalQuantitySold,
                    OTStockinpricePreWeek = item.TotalStInPr,
                    OTStockoutpricePreWeek = item.TotalStOuPr,
                    OTNetIncomeFpPreWeek = item.TotalProfit
                }).ToList(),

                OTMostSoldItemsPreTwoWeeks = mostSoldItemsInTheLastTwoWeeks.Select(item => new OTMostSoldItemsPreTwoWeeks
                {
                    OTProNamePreTwoWeeks = item.ProductName,
                    OTTotQuaSoldPreTwoWeeks = item.TotalQuantitySold,
                    OTStockinpricePreTwoWeeks = item.TotalStInPr,
                    OTStockoutpricePreTwoWeeks = item.TotalStOuPr,
                    OTNetIncomeFpPreTwoWeeks = item.TotalProfit
                }).ToList(),


                OTMostSoldItemsPreThreeWeeks = mostSoldItemsInTheLastThreeWeeks.Select(item => new OTMostSoldItemsPreThreeWeeks
                {
                    OTProNamePreThreeWeeks = item.ProductName,
                    OTTotQuaSoldPreThreeWeeks = item.TotalQuantitySold,
                    OTStockinpricePreThreeWeeks = item.TotalStInPr,
                    OTStockoutpricePreThreeWeeks = item.TotalStOuPr,
                    OTNetIncomeFpPreThreeWeeks = item.TotalProfit
                }).ToList(),


                OTMostSoldItemsPreMonth = mostSoldItemsInTheLastMonth.Select(item => new OTMostSoldItemsPreMonth
                {
                    OTProNamePreMonth = item.ProductName,
                    OTTotQuaSoldPreMonth = item.TotalQuantitySold,
                    OTStockinpricePreMonth = item.TotalStInPr,
                    OTStockoutpricePreMonth = item.TotalStOuPr,
                    OTNetIncomeFpPreMonth = item.TotalProfit
                }).ToList()
            };
            return View(viewModel);
        }

        // GET: Others/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others
                .FirstOrDefaultAsync(m => m.OID == id);
            if (others == null)
            {
                return NotFound();
            }

            return View(others);
        }

        // GET: Others/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Others/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Others others)
        {
            if (ModelState.IsValid)
            {
                _context.Add(others);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(others);
        }

        // GET: Others/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others.FindAsync(id);
            if (others == null)
            {
                return NotFound();
            }
            return View(others);
        }

        // POST: Others/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Others others)
        {
            if (id != others.OID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(others);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OthersExists(others.OID))
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
            return View(others);
        }

        // GET: Others/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others
                .FirstOrDefaultAsync(m => m.OID == id);
            if (others == null)
            {
                return NotFound();
            }

            return View(others);
        }

        // POST: Others/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var others = await _context.Others.FindAsync(id);
            if (others != null)
            {
                _context.Others.Remove(others);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> DeleteRequiredQuantity(int? id, int OtRequiredQuantity)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others.FirstOrDefaultAsync(m => m.OID == id);
            var item = await _context.Others.FindAsync(id); // Replace MyItems with your entity set name




            if (others == null)
            {
                return NotFound();
            }

            return View(others);
        }


        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("DeleteRequiredQuantity")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredDeleteConfirmed(int id, int OtRequiredQuantity)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input." });
            }

            var item = await _context.Others.FindAsync(id);

            if (item == null)
            {
                return Json(new { success = false, message = "Item not found." });
            }



            if (OtRequiredQuantity <= 0)
            {
                return Json(new { success = false, message = "Negative or Null is not Valid." });
            }


            if (item.Quantity < OtRequiredQuantity)
            {
                return Json(new { success = false, message = "Insufficient amount." });
            }




            try
            {





                // 1. Create the audit record *before* deleting the original item
                var othersSalesRecord = new OTHERSSALESRECORD
                {

                    OTHRecName = item.Name,
                    OTHRecSoldQuantity = OtRequiredQuantity,
                    OTHRecDescription = item.Description,
                    OTHRecStockInPrice = item.Stock_In_Price_Per_Item,
                    OTHRecStockOutPrice = item.Stock_Out_Price_Per_Item,
                    OTHRecDateSold = DateTime.Now,
                    OTHRecSupplierEmail = item.Supplier_Email

                };
                await _context.OTHERSSALESRECORD.AddAsync(othersSalesRecord);

                item.Quantity -= OtRequiredQuantity;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SearchForm));

            }
            catch (Exception ex)
            {




                return Json(new { success = false, message = "Error reducing amount: " + ex.Message });
            }


        }








        private bool OthersExists(int id)
        {
            return _context.Others.Any(e => e.OID == id);
        }
    }
}
