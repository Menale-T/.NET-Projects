using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1.MostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1;
using SUP_INV1._0.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace SUP_INV1._0.Controllers
{
    public class FarmProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> CheckItemsPassedShelfLife()
        {
            var expiredItems = await _context.FarmProducts.Where(i => i.Maximum_Shelf_Life_Days <= 0).ToListAsync();
            var soldOutitem = await _context.FarmProducts.Where(i => i.Amount_In_Kg == 0).ToListAsync();
            return Json(new
            {
                count = expiredItems.Count,
                count2 = soldOutitem.Count
            });
        }

        // GET: FarmProducts
        [Authorize]
        public async Task<IActionResult> Index(int? id)
        {
            var farmProducts = await _context.FarmProducts.FindAsync(id);
            var today = DateTime.Today;



            return View(await _context.FarmProducts.ToListAsync());
        }




        public async Task<IActionResult> FPAnalysis(int? id, ViewModel1 model, int topN = 10)
        {
            var farmProducts = await _context.FarmProducts.FindAsync(id);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var beforeyesterday = DateTime.Today.AddDays(-2);
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastTwoWeeks = DateTime.Today.AddDays(-14);
            var PastThreeWeeks = DateTime.Today.AddDays(-21);
            var PastMonth = DateTime.Today.AddDays(-28);


            var totalNumberOfRecords = await _context.FarmProducts.CountAsync();
            var totalAmountOfRecordedItems = await _context.FarmProducts.SumAsync(fp => fp.Amount_In_Kg);
            var totalStockInPrice = await _context.FarmProducts.SumAsync(farmProducts => (farmProducts.Amount_In_Kg * farmProducts.Stock_In_Price_Per_Kg));
            var totalStockOutPrice = await _context.FarmProducts.SumAsync(farmProducts => (farmProducts.Amount_In_Kg * farmProducts.Stock_Out_Price_Per_Kg));



            var totalAmountSoldToday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold > yesterday && farmProducts.FPRecDateSold < tomorrow).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);
            var totalAmountSoldYesterday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold <= today && farmProducts.FPRecDateSold >= yesterday).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);
            var totalAmountSoldInLastweek = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastWeek && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);
            var totalAmountSoldInLastTwoweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastTwoWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);
            var totalAmountSoldInLastThreeweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastThreeWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);
            var totalAmountSoldInLastMonth = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastMonth && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => farmProducts.FPRecSoldAmount);



            var totalStockinpriceToday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold > today && farmProducts.FPRecDateSold < tomorrow).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));
            var totalStockinpriceYesterday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold <= today && farmProducts.FPRecDateSold >= yesterday).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));
            var totalStockinpriceInLastweek = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastWeek && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));
            var totalStockinpriceInLastTwoweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastTwoWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));
            var totalStockinpriceInLastThreeweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastThreeWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));
            var totalStockinpriceInLastMonth = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastMonth && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockInPrice * farmProducts.FPRecSoldAmount));




            var totalStockoutpriceToday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold > today && farmProducts.FPRecDateSold < tomorrow).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));
            var totalStockoutpriceYesterday = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold <= today && farmProducts.FPRecDateSold >= yesterday).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));
            var totalStockoutpriceInLastweek = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastWeek && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));
            var totalStockoutpriceInLastTwoweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= pastTwoWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));
            var totalStockoutpriceInLastThreeweeks = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastThreeWeeks && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));
            var totalStockoutpriceInLastMonth = await _context.FARMPRODUCTSSALESRECORD.Where(farmProducts => farmProducts.FPRecDateSold >= PastMonth && farmProducts.FPRecDateSold <= today).SumAsync(farmProducts => (farmProducts.FPRecStockOutPrice * farmProducts.FPRecSoldAmount));




            var totalIncomeToday = totalStockoutpriceToday - totalStockinpriceToday;
            var totalIncomeYesterday = totalStockoutpriceYesterday - totalStockinpriceYesterday;
            var totalIncomeInLastweek = totalStockoutpriceInLastweek - totalStockinpriceInLastweek;
            var totalIncomeInLastTwoweeks = totalStockoutpriceInLastTwoweeks - totalStockinpriceInLastTwoweeks;
            var totalIncomeInLastThreeweeks = totalStockoutpriceInLastThreeweeks - totalStockinpriceInLastThreeweeks;
            var totalIncomeInLastMonth = totalStockoutpriceInLastMonth - totalStockinpriceInLastMonth;


            //solditems for today
            var todaysSoldItems = await (from record in _context.FARMPRODUCTSSALESRECORD
                                         where record.FPRecDateSold > today && record.FPRecDateSold < tomorrow
                                         group record by record.FPRecName into grouped
                                         select new
                                         {

                                             ProductName = grouped.Key,
                                             TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                             TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                             TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                             TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                         })
                                     .OrderByDescending(x => x.TotalQuantitySold)

                                     .ToListAsync();


            //mostsolditems for all time
            var mostSoldItems = await (from record in _context.FARMPRODUCTSSALESRECORD
                                       group record by record.FPRecName into grouped
                                       select new
                                       {

                                           ProductName = grouped.Key,
                                           TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                           TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                           TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                           TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                       })
                                     .OrderByDescending(x => x.TotalQuantitySold)
                                     .Take(topN)
                                     .ToListAsync();



            //mostsolditems for previous day

            var mostSoldItemsInTheLastDay = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                   where record.FPRecDateSold <= today && record.FPRecDateSold >= yesterday
                                                   group record by record.FPRecName into grouped
                                                   select new
                                                   {
                                                       ProductName = grouped.Key,
                                                       TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                       TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                       TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                       TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                   })
                                          .OrderByDescending(x => x.TotalQuantitySold)
                                          .ToListAsync();
            var mostSoldItemsInTheLastTwoDay = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                      where record.FPRecDateSold == beforeyesterday
                                                      group record by record.FPRecName into grouped
                                                      select new
                                                      {
                                                          ProductName = grouped.Key,
                                                          TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                          TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                          TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                          TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                      })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous week
            var mostSoldItemsInTheLastWeek = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                    where record.FPRecDateSold >= pastWeek && record.FPRecDateSold <= today
                                                    group record by record.FPRecName into grouped
                                                    select new
                                                    {
                                                        ProductName = grouped.Key,
                                                        TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                        TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                        TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                        TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                    })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //mostsolditems for previous Two weeks
            var mostSoldItemsInTheLastTwoWeeks = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                        where record.FPRecDateSold >= pastTwoWeeks && record.FPRecDateSold <= today
                                                        group record by record.FPRecName into grouped
                                                        select new
                                                        {
                                                            ProductName = grouped.Key,
                                                            TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                            TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                            TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                            TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                        })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();



            //mostsolditems for previous Three weeks
            var mostSoldItemsInTheLastThreeWeeks = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                          where record.FPRecDateSold >= PastThreeWeeks && record.FPRecDateSold <= today
                                                          group record by record.FPRecName into grouped
                                                          select new
                                                          {
                                                              ProductName = grouped.Key,
                                                              TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                              TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                              TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                              TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                          })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();

            //mostsolditems for previous Month
            var mostSoldItemsInTheLastMonth = await (from record in _context.FARMPRODUCTSSALESRECORD
                                                     where record.FPRecDateSold >= PastMonth && record.FPRecDateSold <= today
                                                     group record by record.FPRecName into grouped
                                                     select new
                                                     {
                                                         ProductName = grouped.Key,
                                                         TotalQuantitySold = grouped.Sum(r => r.FPRecSoldAmount),
                                                         TotalStInPr = grouped.Sum(r => r.FPRecStockInPrice),
                                                         TotalStOuPr = grouped.Sum(r => r.FPRecStockOutPrice),
                                                         TotalProfit = grouped.Sum(r => (r.FPRecSoldAmount * r.FPRecStockOutPrice) - (r.FPRecSoldAmount * r.FPRecStockInPrice))
                                                     })
                                         .OrderByDescending(x => x.TotalQuantitySold)
                                         .ToListAsync();


            //items passed maximum shelf life
            var itemsPassedMaxShelfLife = await (from record in _context.FarmProducts
                                                 where record.Maximum_Shelf_Life_Days == 0 && record.Maximum_Shelf_Life_Days <= 1
                                                 group record by record.Name into grouped
                                                 select new
                                                 {

                                                     ProductName = grouped.Key,
                                                     TotalAmount = grouped.Sum(r => r.Amount_In_Kg),
                                                     TotalStInPr = grouped.Sum(r => r.Stock_In_Price_Per_Kg),
                                                     TotalStOuPr = grouped.Sum(r => r.Stock_Out_Price_Per_Kg),
                                                     TotalProfit = grouped.Sum(r => (r.Amount_In_Kg * r.Stock_Out_Price_Per_Kg) - (r.Amount_In_Kg * r.Stock_In_Price_Per_Kg))
                                                 })
                                     .OrderByDescending(x => x.TotalAmount)

                                     .ToListAsync();

            //Sold out items
            var soldOutItems = await (from record in _context.FarmProducts
                                      where record.Amount_In_Kg == 0
                                      group record by record.Name into grouped
                                      select new
                                      {

                                          ProductName = grouped.Key,
                                          TotalAmount = grouped.Sum(r => r.Amount_In_Kg),
                                          TotalStInPr = grouped.Sum(r => r.Stock_In_Price_Per_Kg),
                                          TotalStOuPr = grouped.Sum(r => r.Stock_Out_Price_Per_Kg),
                                          TotalProfit = grouped.Sum(r => (r.Amount_In_Kg * r.Stock_Out_Price_Per_Kg) - (r.Amount_In_Kg * r.Stock_In_Price_Per_Kg))
                                      })
                                     .OrderByDescending(x => x.TotalAmount)

                                     .ToListAsync();

            // Insert The Data into ViewModel
            var viewModel = new ViewModel1
            {


                TotNumItemsFp = totalNumberOfRecords,
                TotalAmountFp = totalAmountOfRecordedItems,
                TotalStInPriceFp = totalStockInPrice,
                TotalStOPriceFp = totalStockOutPrice,
                Income = totalStockOutPrice - totalStockInPrice,



                TotalAmountSoldToday = totalAmountSoldToday,
                TotalAmountSoldYesterday = totalAmountSoldYesterday,
                TotalAmountSoldPastWeek = totalAmountSoldInLastweek,
                TotalAmountSoldPastTwoWeeks = totalAmountSoldInLastTwoweeks,
                TotalAmountSoldPastThreeWeeks = totalAmountSoldInLastThreeweeks,
                TotalAmountSoldPastMonth = totalAmountSoldInLastMonth,



                TotalStockInPriceOfItemsSoldToday = totalStockinpriceToday,
                TotalStockInPriceOfItemsSoldYesterday = totalStockinpriceYesterday,
                TotalStockInPriceOfItemsSoldLastWeek = totalStockinpriceInLastweek,
                TotalStockInPriceOfItemsSoldLastTwoWeeks = totalStockinpriceInLastTwoweeks,
                TotalStockInPriceOfItemsSoldLastThreeWeeks = totalStockinpriceInLastThreeweeks,
                TotalStockInPriceOfItemsSoldLastMonth = totalStockinpriceInLastMonth,




                TotalStockOutPriceOfItemsSoldToday = totalStockoutpriceToday,
                TotalStockOutPriceOfItemsSoldYesterday = totalStockoutpriceYesterday,
                TotalStockOutPriceOfItemsSoldLastWeek = totalStockoutpriceInLastweek,
                TotalStockOutPriceOfItemsSoldLastTwoWeeks = totalStockoutpriceInLastTwoweeks,
                TotalStockOutPriceOfItemsSoldLastThreeWeeks = totalStockoutpriceInLastThreeweeks,
                TotalStockOutPriceOfItemsSoldLastMonth = totalStockoutpriceInLastMonth,





                TotalIncomeOfItemsSoldToday = totalIncomeToday,
                TotalIncomeOfItemsSoldYesterday = totalIncomeYesterday,
                TotalIncomeOfItemsSoldLastWeek = totalIncomeInLastweek,
                TotalIncomeOfItemsSoldLastTwoWeeks = totalIncomeInLastTwoweeks,
                TotalIncomeOfItemsSoldLastThreeWeeks = totalIncomeInLastThreeweeks,
                TotalIncomeOfItemsSoldLastMonth = totalIncomeInLastMonth,





                FpSoldOutItems = soldOutItems.Select(item => new SoldOutItems
                {
                    ItemNameSoldout = item.ProductName,
                    ItemAmountSoldout = item.TotalAmount,
                    ItemStockinpriceSoldout = item.TotalStInPr,
                    ItemStockoutpriceSoldout = item.TotalStOuPr,
                    ItemNetIncomeSoldout = item.TotalProfit,

                }).ToList(),


                FpItemPassedMaxShelfLife = itemsPassedMaxShelfLife.Select(item => new ItemsPassedShelfLife
                {

                    ItemNameFpMaxSh = item.ProductName,
                    ItemAmountFpMaxSh = item.TotalAmount,
                    ItemStockinpriceFpMaxSh = item.TotalStInPr,
                    ItemStockoutpriceFpMaxSh = item.TotalStOuPr,
                    ItemNetIncomeFpMaxSh = item.TotalProfit,



                }).ToList(),





                FpSoldItemsToday = todaysSoldItems.Select(item => new SoldItemsToday
                {
                    ProNameToday = item.ProductName,
                    TotQuaSoldToday = item.TotalQuantitySold,
                    StockinpriceToday = item.TotalStInPr,
                    StockoutpriceToday = item.TotalStOuPr,
                    NetIncomeFpToday = item.TotalProfit,



                }).ToList(),


                MostSoldItems = mostSoldItems.Select(item => new MostSoldItem
                {

                    ProName = item.ProductName,
                    TotQuaSold = item.TotalQuantitySold,
                    TotStockinprice = item.TotalStInPr,
                    TotStockoutprice = item.TotalStOuPr,
                    NetIncomeFp = item.TotalProfit,



                }).ToList(),




                MostSoldItemsPreDay = mostSoldItemsInTheLastDay.Select(item => new MostSoldItemsPreDay
                {




                    ProNamePreDay = item.ProductName,
                    TotQuaSoldPreDay = item.TotalQuantitySold,
                    StockinpricePreDay = item.TotalStInPr,
                    StockoutpricePreDay = item.TotalStOuPr,
                    NetIncomeFpPreDay = item.TotalProfit


                }).ToList(),
                MostSoldItemsPreTwoDay = mostSoldItemsInTheLastTwoDay.Select(item => new MostSoldItemsPreTwoDay
                {




                    ProNamePreTwoDay = item.ProductName,
                    TotQuaSoldPreTwoDay = item.TotalQuantitySold,
                    StockinpricePreTwoDay = item.TotalStInPr,
                    StockoutpricePreTwoDay = item.TotalStOuPr,
                    NetIncomeFpPreTwoDay = item.TotalProfit


                }).ToList(),


                FpMostSoldItemsPreWeek = mostSoldItemsInTheLastWeek.Select(item => new MostSoldItemsPreWeek
                {


                    ProNamePreWeek = item.ProductName,
                    TotQuaSoldPreWeek = item.TotalQuantitySold,
                    StockinpricePreWeek = item.TotalStInPr,
                    StockoutpricePreWeek = item.TotalStOuPr,
                    NetIncomeFpPreWeek = item.TotalProfit
                }).ToList(),

                FpMostSoldItemsPreTwoWeeks = mostSoldItemsInTheLastTwoWeeks.Select(item => new MostSoldItemsPreTwoWeeks
                {
                    ProNamePreTwoWeeks = item.ProductName,
                    TotQuaSoldPreTwoWeeks = item.TotalQuantitySold,
                    StockinpricePreTwoWeeks = item.TotalStInPr,
                    StockoutpricePreTwoWeeks = item.TotalStOuPr,
                    NetIncomeFpPreTwoWeeks = item.TotalProfit
                }).ToList(),


                FpMostSoldItemsPreThreeWeeks = mostSoldItemsInTheLastThreeWeeks.Select(item => new MostSoldItemsPreThreeWeeks
                {
                    ProNamePreThreeWeeks = item.ProductName,
                    TotQuaSoldPreThreeWeeks = item.TotalQuantitySold,
                    StockinpricePreThreeWeeks = item.TotalStInPr,
                    StockoutpricePreThreeWeeks = item.TotalStOuPr,
                    NetIncomeFpPreThreeWeeks = item.TotalProfit
                }).ToList(),


                FpMostSoldItemsPreMonth = mostSoldItemsInTheLastMonth.Select(item => new MostSoldItemsPreMonth
                {
                    ProNamePreMonth = item.ProductName,
                    TotQuaSoldPreMonth = item.TotalQuantitySold,
                    StockinpricePreMonth = item.TotalStInPr,
                    StockoutpricePreMonth = item.TotalStOuPr,
                    NetIncomeFpPreMonth = item.TotalProfit
                }).ToList()
            };




            return View(viewModel);

        }




        [Authorize]
        public async Task<IActionResult> SearchForm()
        {
            return View();
        }


        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View(await _context.FarmProducts.Where(item => item.Name.Contains(SearchPhrase)).ToListAsync());
        }







        // GET: FarmProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProducts = await _context.FarmProducts
                .FirstOrDefaultAsync(m => m.FID == id);
            if (farmProducts == null)
            {
                return NotFound();
            }

            return View(farmProducts);
        }

        // GET: FarmProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Amount_In_Kg,Description,Maximum_Shelf_Life_Days,Stock_In_Price_Per_Kg,Stock_Out_Price_Per_Kg,Date_Created,Supplier_Email")] FarmProducts farmProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmProducts);
        }

        // GET: FarmProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProducts = await _context.FarmProducts.FindAsync(id);
            if (farmProducts == null)
            {
                return NotFound();
            }
            return View(farmProducts);
        }

        // POST: FarmProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Amount_In_Kg,Description,Maximum_Shelf_Life_Days,Stock_In_Price_Per_Kg,Stock_Out_Price_Per_Kg,Date_Created,Supplier_Email")] FarmProducts farmProducts)
        {
            if (id != farmProducts.FID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmProductsExists(farmProducts.FID))
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
            return View(farmProducts);
        }

        // GET: FarmProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProducts = await _context.FarmProducts
                .FirstOrDefaultAsync(m => m.FID == id);
            if (farmProducts == null)
            {
                return NotFound();
            }

            return View(farmProducts);
        }

        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmProducts = await _context.FarmProducts.FindAsync(id);
            if (farmProducts != null)
            {
                _context.FarmProducts.Remove(farmProducts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> DeleteRequiredAmount(int? id, Double FPRequiredAmount)
        {

            if (id == null)
            {
                return NotFound();
            }

            var farmProducts = await _context.FarmProducts.FirstOrDefaultAsync(m => m.FID == id);
            var item = await _context.FarmProducts.FindAsync(id); // Replace MyItems with your entity set name




            if (farmProducts == null)
            {
                return NotFound();
            }



            return View(farmProducts);
        }


        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("DeleteRequiredAmount")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredDeleteConfirmed(int id, Double FPRequiredAmount)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input." });
            }



            var item = await _context.FarmProducts.FindAsync(id);


            if (item == null)
            {
                return Json(new { success = false, message = "Item not found." });
            }


            if (FPRequiredAmount <= 0)
            {
                return Json(new { success = false, message = "Negative Amount in not Valid." });
            }


            if (item.Amount_In_Kg < FPRequiredAmount)
            {
                return Json(new { success = false, message = "Insufficient amount." });
            }
            
            try
            {
                var now = DateTime.Now;
                var farmProductsSalesRecord = new FARMPRODUCTSSALESRECORD
                {

                    FPRecName = item.Name,
                    ItemID = item.FID,
                    FPRecSoldAmount = FPRequiredAmount,
                    FPRecDescription = item.Description,
                    FPRecStockInPrice = item.Stock_In_Price_Per_Kg,
                    FPRecStockOutPrice = item.Stock_Out_Price_Per_Kg,
                    FPRecDateSold = now,
                    FPRecSupplierEmail = item.Supplier_Email

                };
                await _context.FARMPRODUCTSSALESRECORD.AddAsync(farmProductsSalesRecord);
                var ProductsPreparedRecord = new PREPAREDRECORD
                {
                    RecName = item.Name,
                    ItemID = item.FID,
                    Category = 1,
                    RecSoldAmountQuantity = FPRequiredAmount,
                    RecDescription = item.Description,
                    RecSt_InPrice = item.Stock_In_Price_Per_Kg,
                    RecSt_OutPrice = item.Stock_Out_Price_Per_Kg,
                    RecDateSold = now,
                    RecSupplierEmail = item.Supplier_Email
                };

                await _context.PREPAREDRECORD.AddAsync(ProductsPreparedRecord);

                item.Amount_In_Kg -= FPRequiredAmount; 
                await _context.SaveChangesAsync();

               /*
                // Check if a record with the same Name and Date exists
                var existingRecord = await _context.PREPAREDRECORD
                    .FirstOrDefaultAsync(record => record.RecName == item.Name && record.RecDateSold.Date == now.Date);

                if (existingRecord == null)
                {

                    
                    // Create a new record if no matching record exists
                    var ProductsPreparedRecord = new PREPAREDRECORD
                    {
                        RecName = item.Name,
                        ItemID = item.FID,
                        Category = 1,
                        RecSoldAmountQuantity = FPRequiredAmount,
                        RecDescription = item.Description,
                        RecSt_InPrice = item.Stock_In_Price_Per_Kg,
                        RecSt_OutPrice = item.Stock_Out_Price_Per_Kg,
                        RecDateSold = now,
                        RecSupplierEmail = item.Supplier_Email
                    };

                    await _context.PREPAREDRECORD.AddAsync(ProductsPreparedRecord);

                }
                else
                {
                    // Update the existing record's values
                    existingRecord.RecSoldAmountQuantity += FPRequiredAmount; // Increment sold amount

                    existingRecord.RecSt_InPrice =
                    (existingRecord.RecSt_InPrice * existingRecord.RecSoldAmountQuantity + item.Stock_In_Price_Per_Kg * FPRequiredAmount)
                    / (existingRecord.RecSoldAmountQuantity + FPRequiredAmount); // Weighted average for stock-in price
                    existingRecord.RecSt_OutPrice =
                    (existingRecord.RecSt_OutPrice * existingRecord.RecSoldAmountQuantity + item.Stock_Out_Price_Per_Kg * FPRequiredAmount)
                    / (existingRecord.RecSoldAmountQuantity + FPRequiredAmount); // Weighted average for stock-out price
                    existingRecord.RecDescription = $"Updated data for {item.Name} on {now.ToShortDateString()}";

                    existingRecord.RecSupplierEmail = $"{existingRecord.RecSupplierEmail}, {item.Supplier_Email}".Trim(',');// Append supplier email



                }

                */

               // await _context.SaveChangesAsync();
                

                return RedirectToAction(nameof(SearchForm));

            }
            catch (Exception ex)
            {




                return Json(new { success = false, message = "Error reducing amount: " + ex.Message });
            }





        }


        private bool FarmProductsExists(int id)
        {
            return _context.FarmProducts.Any(e => e.FID == id);
        }
    }
}
