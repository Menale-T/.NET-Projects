using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1.PAMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0.ViewModel;

namespace SUP_INV1._0.Controllers
{
    public class PackedFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackedFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> CheckExpiredItems()
        {
            var expiredItems = await _context.PackedFoods.Where(i => i.Expiry_Date < DateTime.Now).ToListAsync();
            return Json(new { count = expiredItems.Count });
        }

        // GET: PackedFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackedFoods.ToListAsync());
        }




        public IActionResult SearchForm()
        {
            return View();
        }


        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View(await _context.PackedFoods.Where(item => item.Name.Contains(SearchPhrase)).ToListAsync());
        }





        public async Task<IActionResult> PFAnalysis(int? id, ViewModel1 model, int topN = 10)
        {

            var packedFoods = await _context.PackedFoods.FindAsync(id);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastTwoWeeks = DateTime.Today.AddDays(-14);
            var PastThreeWeeks = DateTime.Today.AddDays(-21);
            var PastMonth = DateTime.Today.AddDays(-28);


            var totalNumberOfRecords = await _context.PackedFoods.CountAsync();
            var totalQuantityOfRecordedItems = await _context.PackedFoods.SumAsync(fp => fp.Quantity);
            var totalStockInPrice = await _context.PackedFoods.SumAsync(packedFoods => (packedFoods.Quantity * packedFoods.Stock_In_Price_Per_Item));
            var totalStockOutPrice = await _context.PackedFoods.SumAsync(packedFoods => (packedFoods.Quantity * packedFoods.Stock_Out_Price_Per_Item));



            var totalQuantitySoldToday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold > today && packedFoods.PARecDateSold < tomorrow).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);
            var totalQuantitySoldYesterday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold <= today && packedFoods.PARecDateSold >= yesterday).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);
            var totalQuantitySoldInLastweek = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastWeek && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);
            var totalQuantitySoldInLastTwoweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastTwoWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);
            var totalQuantitySoldInLastThreeweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastThreeWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);
            var totalQuantitySoldInLastMonth = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastMonth && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => packedFoods.PARecSoldQuantity);



            var totalStockinpriceToday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold > today && packedFoods.PARecDateSold < tomorrow).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));
            var totalStockinpriceYesterday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold <= today && packedFoods.PARecDateSold >= yesterday).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));
            var totalStockinpriceInLastweek = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastWeek && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));
            var totalStockinpriceInLastTwoweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastTwoWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));
            var totalStockinpriceInLastThreeweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastThreeWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));
            var totalStockinpriceInLastMonth = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastMonth && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockInPrice * packedFoods.PARecSoldQuantity));




            var totalStockoutpriceToday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold > today && packedFoods.PARecDateSold < tomorrow).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));
            var totalStockoutpriceYesterday = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold <= today && packedFoods.PARecDateSold >= yesterday).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));
            var totalStockoutpriceInLastweek = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastWeek && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));
            var totalStockoutpriceInLastTwoweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= pastTwoWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));
            var totalStockoutpriceInLastThreeweeks = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastThreeWeeks && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));
            var totalStockoutpriceInLastMonth = await _context.PACKEDFOODSSALESRECORD.Where(packedFoods => packedFoods.PARecDateSold >= PastMonth && packedFoods.PARecDateSold <= today).SumAsync(packedFoods => (packedFoods.PARecStockOutPrice * packedFoods.PARecSoldQuantity));




            var totalIncomeToday = totalStockoutpriceToday - totalStockinpriceToday;
            var totalIncomeYesterday = totalStockoutpriceYesterday - totalStockinpriceYesterday;
            var totalIncomeInLastweek = totalStockoutpriceInLastweek - totalStockinpriceInLastweek;
            var totalIncomeInLastTwoweeks = totalStockoutpriceInLastTwoweeks - totalStockinpriceInLastTwoweeks;
            var totalIncomeInLastThreeweeks = totalStockoutpriceInLastThreeweeks - totalStockinpriceInLastThreeweeks;
            var totalIncomeInLastMonth = totalStockoutpriceInLastMonth - totalStockinpriceInLastMonth;


            //solditems for today
            var todaysSoldItems = await (from record in _context.PACKEDFOODSSALESRECORD
                                         where record.PARecDateSold > today && record.PARecDateSold < tomorrow
                                         group record by record.PARecName into grouped
                                         select new
                                         {

                                             ProductName = grouped.Key,
                                             TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                             TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                             TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                             TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                         })
                                     .OrderByDescending(x => x.TotalQuantitySold)

                                     .ToListAsync();


            //mostsolditems for all time
            var mostSoldItems = await (from record in _context.PACKEDFOODSSALESRECORD
                                       group record by record.PARecName into grouped
                                       select new
                                       {

                                           ProductName = grouped.Key,
                                           TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                           TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                           TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                           TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                       })
                                     .OrderByDescending(x => x.TotalQuantitySold)
                                     .Take(topN)
                                     .ToListAsync();



            //mostsolditems for previous day

            var mostSoldItemsInTheLastDay = await (from record in _context.PACKEDFOODSSALESRECORD
                                                   where record.PARecDateSold <= today && record.PARecDateSold >= yesterday
                                                   group record by record.PARecName into grouped
                                                   select new
                                                   {
                                                       ProductName = grouped.Key,
                                                       TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                                       TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                                       TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                                       TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                                   })
                                          .OrderByDescending(x => x.TotalQuantitySold)
                                          .ToListAsync();


            //mostsolditems for previous week
            var mostSoldItemsInTheLastWeek = await (from record in _context.PACKEDFOODSSALESRECORD
                                                    where record.PARecDateSold >= pastWeek && record.PARecDateSold <= today
                                                    group record by record.PARecName into grouped
                                                    select new
                                                    {
                                                        ProductName = grouped.Key,
                                                        TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                                        TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                                        TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                                        TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                                    })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous Two weeks
            var mostSoldItemsInTheLastTwoWeeks = await (from record in _context.PACKEDFOODSSALESRECORD
                                                        where record.PARecDateSold >= pastTwoWeeks && record.PARecDateSold <= today
                                                        group record by record.PARecName into grouped
                                                        select new
                                                        {
                                                            ProductName = grouped.Key,
                                                            TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                                            TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                                            TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                                            TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                                        })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastThreeWeeks = await (from record in _context.PACKEDFOODSSALESRECORD
                                                          where record.PARecDateSold >= PastThreeWeeks && record.PARecDateSold <= today
                                                          group record by record.PARecName into grouped
                                                          select new
                                                          {
                                                              ProductName = grouped.Key,
                                                              TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                                              TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                                              TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                                              TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                                          })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();

            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastMonth = await (from record in _context.PACKEDFOODSSALESRECORD
                                                     where record.PARecDateSold >= PastMonth && record.PARecDateSold <= today
                                                     group record by record.PARecName into grouped
                                                     select new
                                                     {
                                                         ProductName = grouped.Key,
                                                         TotalQuantitySold = grouped.Sum(r => r.PARecSoldQuantity),
                                                         TotalStInPr = grouped.Sum(r => r.PARecStockInPrice),
                                                         TotalStOuPr = grouped.Sum(r => r.PARecStockOutPrice),
                                                         TotalProfit = grouped.Sum(r => (r.PARecSoldQuantity * r.PARecStockOutPrice) - (r.PARecSoldQuantity * r.PARecStockInPrice))
                                                     })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //items passed maximum shelf life
            var itemsExpired = await (from record in _context.PackedFoods
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
            var soldOutItems = await (from record in _context.PackedFoods
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


                TotNumItemsPAF = totalNumberOfRecords,
                TotQuantityOfItemsPAF = totalQuantityOfRecordedItems,
                TotalStInPricePAF = totalStockInPrice,
                TotalStOPricePAF = totalStockOutPrice,
                NetIncomePAF = totalStockOutPrice - totalStockInPrice,



                PATotalAmountSoldToday = totalQuantitySoldToday,
                PATotalAmountSoldYesterday = totalQuantitySoldYesterday,
                PATotalAmountSoldPastWeek = totalQuantitySoldInLastweek,
                PATotalAmountSoldPastTwoWeeks = totalQuantitySoldInLastTwoweeks,
                PATotalAmountSoldPastThreeWeeks = totalQuantitySoldInLastThreeweeks,
                PATotalAmountSoldPastMonth = totalQuantitySoldInLastMonth,



                PATotalStockInPriceOfItemsSoldToday = totalStockinpriceToday,
                PATotalStockInPriceOfItemsSoldYesterday = totalStockinpriceYesterday,
                PATotalStockInPriceOfItemsSoldLastWeek = totalStockinpriceInLastweek,
                PATotalStockInPriceOfItemsSoldLastTwoWeeks = totalStockinpriceInLastTwoweeks,
                PATotalStockInPriceOfItemsSoldLastThreeWeeks = totalStockinpriceInLastThreeweeks,
                PATotalStockInPriceOfItemsSoldLastMonth = totalStockinpriceInLastMonth,




                PATotalStockOutPriceOfItemsSoldToday = totalStockoutpriceToday,
                PATotalStockOutPriceOfItemsSoldYesterday = totalStockoutpriceYesterday,
                PATotalStockOutPriceOfItemsSoldLastWeek = totalStockoutpriceInLastweek,
                PATotalStockOutPriceOfItemsSoldLastTwoWeeks = totalStockoutpriceInLastTwoweeks,
                PATotalStockOutPriceOfItemsSoldLastThreeWeeks = totalStockoutpriceInLastThreeweeks,
                PATotalStockOutPriceOfItemsSoldLastMonth = totalStockoutpriceInLastMonth,





                PATotalIncomeOfItemsSoldToday = totalIncomeToday,
                PATotalIncomeOfItemsSoldYesterday = totalIncomeYesterday,
                PATotalIncomeOfItemsSoldLastWeek = totalIncomeInLastweek,
                PATotalIncomeOfItemsSoldLastTwoWeeks = totalIncomeInLastTwoweeks,
                PATotalIncomeOfItemsSoldLastThreeWeeks = totalIncomeInLastThreeweeks,
                PATotalIncomeOfItemsSoldLastMonth = totalIncomeInLastMonth,





                PAvarSoldOutItems = soldOutItems.Select(item => new PASoldOutItems
                {
                    PAItemNameSoldout = item.ProductName,
                    PAItemQuantitySoldout = item.TotalQuantity,
                    PAItemStockinpriceSoldout = item.TotalStInPr,
                    PAItemStockoutpriceSoldout = item.TotalStOuPr,
                    PAItemNetIncomeSoldout = item.TotalProfit,

                }).ToList(),


                PAItemExpired = itemsExpired.Select(item => new PAExpiredItems
                {

                    PAItemNameExp = item.ProductName,
                    PAItemQuantityExp = item.TotalAmount,
                    PAItemStockinpriceExp = item.TotalStInPr,
                    PAItemStockoutpriceExp = item.TotalStOuPr,
                    PAItemNetIncomeExp = item.TotalProfit,



                }).ToList(),





                PASoldItemsToday = todaysSoldItems.Select(item => new PASoldItemsToday
                {
                    PAProNameToday = item.ProductName,
                    PATotQuaSoldToday = item.TotalQuantitySold,
                    PAStockinpriceToday = item.TotalStInPr,
                    PAStockoutpriceToday = item.TotalStOuPr,
                    PANetIncomeFpToday = item.TotalProfit,



                }).ToList(),


                PAMostSoldItems = mostSoldItems.Select(item => new PAMostSoldItem
                {

                    PAProName = item.ProductName,
                    PATotQuaSold = item.TotalQuantitySold,
                    PATotStockinprice = item.TotalStInPr,
                    PATotStockoutprice = item.TotalStOuPr,
                    PANetIncomeFp = item.TotalProfit,



                }).ToList(),




                PAMostSoldItemsPreDay = mostSoldItemsInTheLastDay.Select(item => new PAMostSoldItemsPreDay
                {




                    PAProNamePreDay = item.ProductName,
                    PATotQuaSoldPreDay = item.TotalQuantitySold,
                    PAStockinpricePreDay = item.TotalStInPr,
                    PAStockoutpricePreDay = item.TotalStOuPr,
                    PANetIncomeFpPreDay = item.TotalProfit


                }).ToList(),


                PAMostSoldItemsPreWeek = mostSoldItemsInTheLastWeek.Select(item => new PAMostSoldItemsPreWeek
                {


                    PAProNamePreWeek = item.ProductName,
                    PATotQuaSoldPreWeek = item.TotalQuantitySold,
                    PAStockinpricePreWeek = item.TotalStInPr,
                    PAStockoutpricePreWeek = item.TotalStOuPr,
                    PANetIncomeFpPreWeek = item.TotalProfit
                }).ToList(),

                PAMostSoldItemsPreTwoWeeks = mostSoldItemsInTheLastTwoWeeks.Select(item => new PAMostSoldItemsPreTwoWeeks
                {
                    PAProNamePreTwoWeeks = item.ProductName,
                    PATotQuaSoldPreTwoWeeks = item.TotalQuantitySold,
                    PAStockinpricePreTwoWeeks = item.TotalStInPr,
                    PAStockoutpricePreTwoWeeks = item.TotalStOuPr,
                    PANetIncomeFpPreTwoWeeks = item.TotalProfit
                }).ToList(),


                PAMostSoldItemsPreThreeWeeks = mostSoldItemsInTheLastThreeWeeks.Select(item => new PAMostSoldItemsPreThreeWeeks
                {
                    PAProNamePreThreeWeeks = item.ProductName,
                    PATotQuaSoldPreThreeWeeks = item.TotalQuantitySold,
                    PAStockinpricePreThreeWeeks = item.TotalStInPr,
                    PAStockoutpricePreThreeWeeks = item.TotalStOuPr,
                    PANetIncomeFpPreThreeWeeks = item.TotalProfit
                }).ToList(),


                PAMostSoldItemsPreMonth = mostSoldItemsInTheLastMonth.Select(item => new PAMostSoldItemsPreMonth
                {
                    PAProNamePreMonth = item.ProductName,
                    PATotQuaSoldPreMonth = item.TotalQuantitySold,
                    PAStockinpricePreMonth = item.TotalStInPr,
                    PAStockoutpricePreMonth = item.TotalStOuPr,
                    PANetIncomeFpPreMonth = item.TotalProfit
                }).ToList()
            };
            return View(viewModel);
        }

        // GET: PackedFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedFoods = await _context.PackedFoods
                .FirstOrDefaultAsync(m => m.PID == id);
            if (packedFoods == null)
            {
                return NotFound();
            }

            return View(packedFoods);
        }

        // GET: PackedFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackedFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] PackedFoods packedFoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packedFoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packedFoods);
        }

        // GET: PackedFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedFoods = await _context.PackedFoods.FindAsync(id);
            if (packedFoods == null)
            {
                return NotFound();
            }
            return View(packedFoods);
        }

        // POST: PackedFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] PackedFoods packedFoods)
        {
            if (id != packedFoods.PID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packedFoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackedFoodsExists(packedFoods.PID))
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
            return View(packedFoods);
        }

        // GET: PackedFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedFoods = await _context.PackedFoods
                .FirstOrDefaultAsync(m => m.PID == id);
            if (packedFoods == null)
            {
                return NotFound();
            }

            return View(packedFoods);
        }

        // POST: PackedFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packedFoods = await _context.PackedFoods.FindAsync(id);
            if (packedFoods != null)
            {
                _context.PackedFoods.Remove(packedFoods);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> DeleteRequiredQuantity(int? id, int PARequiredQuantity)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProducts = await _context.PackedFoods.FirstOrDefaultAsync(m => m.PID == id);
            var item = await _context.PackedFoods.FindAsync(id); // Replace MyItems with your entity set name




            if (farmProducts == null)
            {
                return NotFound();
            }

            return View(farmProducts);
        }


        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("DeleteRequiredQuantity")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredDeleteConfirmed(int id, int PARequiredQuantity)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input." });
            }

            var item = await _context.PackedFoods.FindAsync(id);

            if (item == null)
            {
                return Json(new { success = false, message = "Item not found." });
            }



            if (PARequiredQuantity <= 0)
            {
                return Json(new { success = false, message = "Negative or Null is not Valid." });
            }


            if (item.Quantity < PARequiredQuantity)
            {
                return Json(new { success = false, message = "Insufficient amount." });
            }




            try
            {





                // 1. Create the audit record *before* deleting the original item
                var packedFoodsSalesRecord = new PACKEDFOODSSALESRECORD
                {

                    PARecName = item.Name,
                    PARecSoldQuantity = PARequiredQuantity,
                    PARecDescription = item.Description,
                    PARecStockInPrice = item.Stock_In_Price_Per_Item,
                    PARecStockOutPrice = item.Stock_Out_Price_Per_Item,
                    PARecDateSold = DateTime.Now,
                    PARecSupplierEmail = item.Supplier_Email

                };
                await _context.PACKEDFOODSSALESRECORD.AddAsync(packedFoodsSalesRecord);

                item.Quantity -= PARequiredQuantity;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SearchForm));

            }
            catch (Exception ex)
            {




                return Json(new { success = false, message = "Error reducing amount: " + ex.Message });
            }
        }




        private bool PackedFoodsExists(int id)
        {
            return _context.PackedFoods.Any(e => e.PID == id);
        }
    }
}
