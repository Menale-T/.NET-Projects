using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1.PHAMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0.ViewModel;

namespace SUP_INV1._0.Controllers
{
    public class PharmaceuticalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PharmaceuticalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> CheckExpiredItems()
        {
            var expiredItems = await _context.Pharmaceuticals.Where(i => i.Expiry_Date < DateTime.Now).ToListAsync();
            return Json(new { count = expiredItems.Count });
        }

        // GET: Pharmaceuticals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pharmaceuticals.ToListAsync());
        }



        public IActionResult SearchForm()
        {
            return View();
        }

        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View(await _context.Pharmaceuticals.Where(item => item.Name.Contains(SearchPhrase)).ToListAsync());
        }



        public async Task<IActionResult> PhaAnalysis(int? id, ViewModel1 model, int topN = 10)
        {

            var pharmaceuticals = await _context.Pharmaceuticals.FindAsync(id);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastTwoWeeks = DateTime.Today.AddDays(-14);
            var PastThreeWeeks = DateTime.Today.AddDays(-21);
            var PastMonth = DateTime.Today.AddDays(-28);


            var totalNumberOfRecords = await _context.Pharmaceuticals.CountAsync();
            var totalQuantityOfRecordedItems = await _context.Pharmaceuticals.SumAsync(fp => fp.Quantity);
            var totalStockInPrice = await _context.Pharmaceuticals.SumAsync(pharmaceuticals => (pharmaceuticals.Quantity * pharmaceuticals.Stock_In_Price_Per_Item));
            var totalStockOutPrice = await _context.Pharmaceuticals.SumAsync(pharmaceuticals => (pharmaceuticals.Quantity * pharmaceuticals.Stock_Out_Price_Per_Item));



            var totalQuantitySoldToday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold > today && pharmaceuticals.PHARecDateSold < tomorrow).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);
            var totalQuantitySoldYesterday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold <= today && pharmaceuticals.PHARecDateSold >= yesterday).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);
            var totalQuantitySoldInLastweek = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastWeek && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);
            var totalQuantitySoldInLastTwoweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastTwoWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);
            var totalQuantitySoldInLastThreeweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastThreeWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);
            var totalQuantitySoldInLastMonth = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastMonth && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => pharmaceuticals.PHARecSoldQuantity);



            var totalStockinpriceToday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold > today && pharmaceuticals.PHARecDateSold < tomorrow).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockinpriceYesterday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold <= today && pharmaceuticals.PHARecDateSold >= yesterday).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockinpriceInLastweek = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastWeek && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockinpriceInLastTwoweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastTwoWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockinpriceInLastThreeweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastThreeWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockinpriceInLastMonth = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastMonth && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockInPrice * pharmaceuticals.PHARecSoldQuantity));




            var totalStockoutpriceToday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold > today && pharmaceuticals.PHARecDateSold < tomorrow).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockoutpriceYesterday = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold <= today && pharmaceuticals.PHARecDateSold >= yesterday).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockoutpriceInLastweek = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastWeek && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockoutpriceInLastTwoweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= pastTwoWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockoutpriceInLastThreeweeks = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastThreeWeeks && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));
            var totalStockoutpriceInLastMonth = await _context.PHARMACEUTICALSSALESRECORD.Where(pharmaceuticals => pharmaceuticals.PHARecDateSold >= PastMonth && pharmaceuticals.PHARecDateSold <= today).SumAsync(pharmaceuticals => (pharmaceuticals.PHARecStockOutPrice * pharmaceuticals.PHARecSoldQuantity));




            var totalIncomeToday = totalStockoutpriceToday - totalStockinpriceToday;
            var totalIncomeYesterday = totalStockoutpriceYesterday - totalStockinpriceYesterday;
            var totalIncomeInLastweek = totalStockoutpriceInLastweek - totalStockinpriceInLastweek;
            var totalIncomeInLastTwoweeks = totalStockoutpriceInLastTwoweeks - totalStockinpriceInLastTwoweeks;
            var totalIncomeInLastThreeweeks = totalStockoutpriceInLastThreeweeks - totalStockinpriceInLastThreeweeks;
            var totalIncomeInLastMonth = totalStockoutpriceInLastMonth - totalStockinpriceInLastMonth;

            //solditems for today
            var todaysSoldItems = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                         where record.PHARecDateSold > today && record.PHARecDateSold < tomorrow
                                         group record by record.PHARecName into grouped
                                         select new
                                         {

                                             ProductName = grouped.Key,
                                             TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                             TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                             TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                             TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                         })
                                     .OrderByDescending(x => x.TotalQuantitySold)

                                     .ToListAsync();


            //mostsolditems for all time
            var mostSoldItems = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                       group record by record.PHARecName into grouped
                                       select new
                                       {

                                           ProductName = grouped.Key,
                                           TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                           TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                           TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                           TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                       })
                                     .OrderByDescending(x => x.TotalQuantitySold)
                                     .Take(topN)
                                     .ToListAsync();



            //mostsolditems for previous day

            var mostSoldItemsInTheLastDay = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                                   where record.PHARecDateSold <= today && record.PHARecDateSold >= yesterday
                                                   group record by record.PHARecName into grouped
                                                   select new
                                                   {
                                                       ProductName = grouped.Key,
                                                       TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                                       TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                                       TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                                       TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                                   })
                                          .OrderByDescending(x => x.TotalQuantitySold)
                                          .ToListAsync();


            //mostsolditems for previous week
            var mostSoldItemsInTheLastWeek = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                                    where record.PHARecDateSold >= pastWeek && record.PHARecDateSold <= today
                                                    group record by record.PHARecName into grouped
                                                    select new
                                                    {
                                                        ProductName = grouped.Key,
                                                        TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                                        TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                                        TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                                        TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                                    })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous Two weeks
            var mostSoldItemsInTheLastTwoWeeks = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                                        where record.PHARecDateSold >= pastTwoWeeks && record.PHARecDateSold <= today
                                                        group record by record.PHARecName into grouped
                                                        select new
                                                        {
                                                            ProductName = grouped.Key,
                                                            TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                                            TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                                            TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                                            TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                                        })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastThreeWeeks = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                                          where record.PHARecDateSold >= PastThreeWeeks && record.PHARecDateSold <= today
                                                          group record by record.PHARecName into grouped
                                                          select new
                                                          {
                                                              ProductName = grouped.Key,
                                                              TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                                              TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                                              TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                                              TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                                          })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();

            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastMonth = await (from record in _context.PHARMACEUTICALSSALESRECORD
                                                     where record.PHARecDateSold >= PastMonth && record.PHARecDateSold <= today
                                                     group record by record.PHARecName into grouped
                                                     select new
                                                     {
                                                         ProductName = grouped.Key,
                                                         TotalQuantitySold = grouped.Sum(r => r.PHARecSoldQuantity),
                                                         TotalStInPr = grouped.Sum(r => r.PHARecStockInPrice),
                                                         TotalStOuPr = grouped.Sum(r => r.PHARecStockOutPrice),
                                                         TotalProfit = grouped.Sum(r => (r.PHARecSoldQuantity * r.PHARecStockOutPrice) - (r.PHARecSoldQuantity * r.PHARecStockInPrice))
                                                     })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //items passed maximum shelf life
            var itemsExpired = await (from record in _context.Pharmaceuticals
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
            var soldOutItems = await (from record in _context.Pharmaceuticals
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


                TotNumItemsPHA = totalNumberOfRecords,
                TotQuantityOfItemsPHA = totalQuantityOfRecordedItems,
                TotalStInPricePHA = totalStockInPrice,
                TotalStOPricePHA = totalStockOutPrice,
                NetIncomePHA = totalStockOutPrice - totalStockInPrice,



                PHATotalAmountSoldToday = totalQuantitySoldToday,
                PHATotalAmountSoldYesterday = totalQuantitySoldYesterday,
                PHATotalAmountSoldPastWeek = totalQuantitySoldInLastweek,
                PHATotalAmountSoldPastTwoWeeks = totalQuantitySoldInLastTwoweeks,
                PHATotalAmountSoldPastThreeWeeks = totalQuantitySoldInLastThreeweeks,
                PHATotalAmountSoldPastMonth = totalQuantitySoldInLastMonth,



                PHATotalStockInPriceOfItemsSoldToday = totalStockinpriceToday,
                PHATotalStockInPriceOfItemsSoldYesterday = totalStockinpriceYesterday,
                PHATotalStockInPriceOfItemsSoldLastWeek = totalStockinpriceInLastweek,
                PHATotalStockInPriceOfItemsSoldLastTwoWeeks = totalStockinpriceInLastTwoweeks,
                PHATotalStockInPriceOfItemsSoldLastThreeWeeks = totalStockinpriceInLastThreeweeks,
                PHATotalStockInPriceOfItemsSoldLastMonth = totalStockinpriceInLastMonth,




                PHATotalStockOutPriceOfItemsSoldToday = totalStockoutpriceToday,
                PHATotalStockOutPriceOfItemsSoldYesterday = totalStockoutpriceYesterday,
                PHATotalStockOutPriceOfItemsSoldLastWeek = totalStockoutpriceInLastweek,
                PHATotalStockOutPriceOfItemsSoldLastTwoWeeks = totalStockoutpriceInLastTwoweeks,
                PHATotalStockOutPriceOfItemsSoldLastThreeWeeks = totalStockoutpriceInLastThreeweeks,
                PHATotalStockOutPriceOfItemsSoldLastMonth = totalStockoutpriceInLastMonth,





                PHATotalIncomeOfItemsSoldToday = totalIncomeToday,
                PHATotalIncomeOfItemsSoldYesterday = totalIncomeYesterday,
                PHATotalIncomeOfItemsSoldLastWeek = totalIncomeInLastweek,
                PHATotalIncomeOfItemsSoldLastTwoWeeks = totalIncomeInLastTwoweeks,
                PHATotalIncomeOfItemsSoldLastThreeWeeks = totalIncomeInLastThreeweeks,
                PHATotalIncomeOfItemsSoldLastMonth = totalIncomeInLastMonth,





                PHAvarSoldOutItems = soldOutItems.Select(item => new PHASoldOutItems
                {
                    PHAItemNameSoldout = item.ProductName,
                    PHAItemQuantitySoldout = item.TotalQuantity,
                    PHAItemStockinpriceSoldout = item.TotalStInPr,
                    PHAItemStockoutpriceSoldout = item.TotalStOuPr,
                    PHAItemNetIncomeSoldout = item.TotalProfit,

                }).ToList(),


                PHAItemExpired = itemsExpired.Select(item => new PHAExpiredItems
                {

                    PHAItemNameExp = item.ProductName,
                    PHAItemQuantityExp = item.TotalAmount,
                    PHAItemStockinpriceExp = item.TotalStInPr,
                    PHAItemStockoutpriceExp = item.TotalStOuPr,
                    PHAItemNetIncomeExp = item.TotalProfit,



                }).ToList(),





                PHASoldItemsToday = todaysSoldItems.Select(item => new PHASoldItemsToday
                {
                    PHAProNameToday = item.ProductName,
                    PHATotQuaSoldToday = item.TotalQuantitySold,
                    PHAStockinpriceToday = item.TotalStInPr,
                    PHAStockoutpriceToday = item.TotalStOuPr,
                    PHANetIncomeFpToday = item.TotalProfit,



                }).ToList(),


                PHAMostSoldItems = mostSoldItems.Select(item => new PHAMostSoldItem
                {

                    PHAProName = item.ProductName,
                    PHATotQuaSold = item.TotalQuantitySold,
                    PHATotStockinprice = item.TotalStInPr,
                    PHATotStockoutprice = item.TotalStOuPr,
                    PHANetIncomeFp = item.TotalProfit,



                }).ToList(),




                PHAMostSoldItemsPreDay = mostSoldItemsInTheLastDay.Select(item => new PHAMostSoldItemsPreDay
                {




                    PHAProNamePreDay = item.ProductName,
                    PHATotQuaSoldPreDay = item.TotalQuantitySold,
                    PHAStockinpricePreDay = item.TotalStInPr,
                    PHAStockoutpricePreDay = item.TotalStOuPr,
                    PHANetIncomeFpPreDay = item.TotalProfit


                }).ToList(),


                PHAMostSoldItemsPreWeek = mostSoldItemsInTheLastWeek.Select(item => new PHAMostSoldItemsPreWeek
                {


                    PHAProNamePreWeek = item.ProductName,
                    PHATotQuaSoldPreWeek = item.TotalQuantitySold,
                    PHAStockinpricePreWeek = item.TotalStInPr,
                    PHAStockoutpricePreWeek = item.TotalStOuPr,
                    PHANetIncomeFpPreWeek = item.TotalProfit
                }).ToList(),

                PHAMostSoldItemsPreTwoWeeks = mostSoldItemsInTheLastTwoWeeks.Select(item => new PHAMostSoldItemsPreTwoWeeks
                {
                    PHAProNamePreTwoWeeks = item.ProductName,
                    PHATotQuaSoldPreTwoWeeks = item.TotalQuantitySold,
                    PHAStockinpricePreTwoWeeks = item.TotalStInPr,
                    PHAStockoutpricePreTwoWeeks = item.TotalStOuPr,
                    PHANetIncomeFpPreTwoWeeks = item.TotalProfit
                }).ToList(),


                PHAMostSoldItemsPreThreeWeeks = mostSoldItemsInTheLastThreeWeeks.Select(item => new PHAMostSoldItemsPreThreeWeeks
                {
                    PHAProNamePreThreeWeeks = item.ProductName,
                    PHATotQuaSoldPreThreeWeeks = item.TotalQuantitySold,
                    PHAStockinpricePreThreeWeeks = item.TotalStInPr,
                    PHAStockoutpricePreThreeWeeks = item.TotalStOuPr,
                    PHANetIncomeFpPreThreeWeeks = item.TotalProfit
                }).ToList(),


                PHAMostSoldItemsPreMonth = mostSoldItemsInTheLastMonth.Select(item => new PHAMostSoldItemsPreMonth
                {
                    PHAProNamePreMonth = item.ProductName,
                    PHATotQuaSoldPreMonth = item.TotalQuantitySold,
                    PHAStockinpricePreMonth = item.TotalStInPr,
                    PHAStockoutpricePreMonth = item.TotalStOuPr,
                    PHANetIncomeFpPreMonth = item.TotalProfit
                }).ToList()
            };
            return View(viewModel);
        }

        // GET: Pharmaceuticals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaceuticals = await _context.Pharmaceuticals
                .FirstOrDefaultAsync(m => m.PHID == id);
            if (pharmaceuticals == null)
            {
                return NotFound();
            }

            return View(pharmaceuticals);
        }

        // GET: Pharmaceuticals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmaceuticals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Pharmaceuticals pharmaceuticals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmaceuticals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmaceuticals);
        }

        // GET: Pharmaceuticals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaceuticals = await _context.Pharmaceuticals.FindAsync(id);
            if (pharmaceuticals == null)
            {
                return NotFound();
            }
            return View(pharmaceuticals);
        }

        // POST: Pharmaceuticals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quantity,Description,Expiry_Date,Stock_In_Price_Per_Item,Stock_Out_Price_Per_Item,Date_Created,Supplier_Email")] Pharmaceuticals pharmaceuticals)
        {
            if (id != pharmaceuticals.PHID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaceuticals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaceuticalsExists(pharmaceuticals.PHID))
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
            return View(pharmaceuticals);
        }

        // GET: Pharmaceuticals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaceuticals = await _context.Pharmaceuticals
                .FirstOrDefaultAsync(m => m.PHID == id);
            if (pharmaceuticals == null)
            {
                return NotFound();
            }

            return View(pharmaceuticals);
        }

        // POST: Pharmaceuticals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmaceuticals = await _context.Pharmaceuticals.FindAsync(id);
            if (pharmaceuticals != null)
            {
                _context.Pharmaceuticals.Remove(pharmaceuticals);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> DeleteRequiredQuantity(int? id, int PHARequiredQuantity)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaceuticals = await _context.Pharmaceuticals.FirstOrDefaultAsync(m => m.PHID == id);
            var item = await _context.Pharmaceuticals.FindAsync(id); // Replace MyItems with your entity set name




            if (pharmaceuticals == null)
            {
                return NotFound();
            }

            return View(pharmaceuticals);
        }


        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("DeleteRequiredQuantity")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredDeleteConfirmed(int id, int PHARequiredQuantity)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input." });
            }

            var item = await _context.Pharmaceuticals.FindAsync(id);

            if (item == null)
            {
                return Json(new { success = false, message = "Item not found." });
            }



            if (PHARequiredQuantity <= 0)
            {
                return Json(new { success = false, message = "Negative or Null is not Valid." });
            }


            if (item.Quantity < PHARequiredQuantity)
            {
                return Json(new { success = false, message = "Insufficient amount." });
            }



            try
            {





                // 1. Create the audit record *before* deleting the original item
                var pharmaceuticalsSalesRecord = new PHARMACEUTICALSSALESRECORD
                {

                    PHARecName = item.Name,
                    PHARecSoldQuantity = PHARequiredQuantity,
                    PHARecDescription = item.Description,
                    PHARecStockInPrice = item.Stock_In_Price_Per_Item,
                    PHARecStockOutPrice = item.Stock_Out_Price_Per_Item,
                    PHARecDateSold = DateTime.Now,
                    PHARecSupplierEmail = item.Supplier_Email

                };
                await _context.PHARMACEUTICALSSALESRECORD.AddAsync(pharmaceuticalsSalesRecord);

                item.Quantity -= PHARequiredQuantity;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SearchForm));

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Error reducing amount: " + ex.Message });
            }


        }




        private bool PharmaceuticalsExists(int id)
        {
            return _context.Pharmaceuticals.Any(e => e.PHID == id);
        }
    }
}
