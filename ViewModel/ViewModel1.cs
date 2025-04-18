using Microsoft.AspNetCore.Mvc.Rendering;
using SUP_INV1._0.Models;
using static SUP_INV1._0.ViewModel.ViewModel1;
using static SUP_INV1._0.ViewModel.ViewModel1.MostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1.OTMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1.PAMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1.PHAMostSoldItem;
using static SUP_INV1._0.ViewModel.ViewModel1.TMostSoldItem;

namespace SUP_INV1._0.ViewModel
{
    public class ViewModel1
    {
        // FarmProuucts Data holder 
        public String TableNameFp { get; set; }
        public int TotNumItemsFp { get; set; }
        public Double TotalAmountFp { get; set; }
        public Double TotalStInPriceFp { get; set; }
        public Double TotalStOPriceFp { get; set; }
        public Double Income { get; set; }
        public List<SoldItemsToday> FpSoldItemsToday { get; set; } = new List<SoldItemsToday>();
        public List<MostSoldItem> MostSoldItems { get; set; } = new List<MostSoldItem>();
        public List<MostSoldItemsPreDay> MostSoldItemsPreDay { get; set; } = new List<MostSoldItemsPreDay>();
        public List<MostSoldItemsPreTwoDay> MostSoldItemsPreTwoDay { get; set; } = new List<MostSoldItemsPreTwoDay>();
        public List<MostSoldItemsPreWeek> FpMostSoldItemsPreWeek { get; set; } = new List<MostSoldItemsPreWeek>();
        public List<MostSoldItemsPreTwoWeeks> FpMostSoldItemsPreTwoWeeks { get; set; } = new List<MostSoldItemsPreTwoWeeks>();
        public List<MostSoldItemsPreThreeWeeks> FpMostSoldItemsPreThreeWeeks { get; set; } = new List<MostSoldItemsPreThreeWeeks>();
        public List<MostSoldItemsPreMonth> FpMostSoldItemsPreMonth { get; set; } = new List<MostSoldItemsPreMonth>();
        public List<ItemsPassedShelfLife> FpItemPassedMaxShelfLife { get; set; } = new List<ItemsPassedShelfLife>();
        public List<SoldOutItems> FpSoldOutItems { get; set; } = new List<SoldOutItems>();
        public List<SoldItemsRecordFP> FPSoldItemsRecord { get; set; } = new List<SoldItemsRecordFP>();
        public List<FPForcastResult> FPForcastResults { get; set; } = new List<FPForcastResult>();



        public Double InputAmount { get; set; }


        public Double TotalAmountSoldToday { get; set; }
        public Double TotalAmountSoldYesterday { get; set; }
        public Double TotalAmountSoldPastWeek { get; set; }
        public Double TotalAmountSoldPastTwoWeeks { get; set; }
        public Double TotalAmountSoldPastThreeWeeks { get; set; }
        public Double TotalAmountSoldPastMonth { get; set; }



        public Double TotalStockInPriceOfItemsSoldToday { get; set; }
        public Double TotalStockInPriceOfItemsSoldYesterday { get; set; }
        public Double TotalStockInPriceOfItemsSoldLastWeek { get; set; }
        public Double TotalStockInPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double TotalStockInPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double TotalStockInPriceOfItemsSoldLastMonth { get; set; }



        public Double TotalStockOutPriceOfItemsSoldToday { get; set; }
        public Double TotalStockOutPriceOfItemsSoldYesterday { get; set; }
        public Double TotalStockOutPriceOfItemsSoldLastWeek { get; set; }
        public Double TotalStockOutPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double TotalStockOutPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double TotalStockOutPriceOfItemsSoldLastMonth { get; set; }




        public Double TotalIncomeOfItemsSoldToday { get; set; }
        public Double TotalIncomeOfItemsSoldYesterday { get; set; }
        public Double TotalIncomeOfItemsSoldLastWeek { get; set; }
        public Double TotalIncomeOfItemsSoldLastTwoWeeks { get; set; }
        public Double TotalIncomeOfItemsSoldLastThreeWeeks { get; set; }
        public Double TotalIncomeOfItemsSoldLastMonth { get; set; }
        //pu


        public class FPForcastResult
        {

            public float PredictedAmount { get; set; } // Change to array to match output type
            public float LowerBounds { get; set; }
            public float UpperBounds { get; set; }
        }
        public class SoldItemsRecordFP
        {

            public int ItemIdSoldrec { get; set; }

            public float ItemAmountSoldrec { get; set; }
            public DateTime ItemDateSoldrec { get; set; }


        }


        public class SoldOutItems
        {

            public int ItemIdSoldout { get; set; }
            public String ItemNameSoldout { get; set; }
            public Double ItemAmountSoldout { get; set; }
            public String ItemDescriptionSoldout { get; set; }
            public Double ItemStockinpriceSoldout { get; set; }
            public Double ItemStockoutpriceSoldout { get; set; }
            public String ItemSupplierEmailSoldout { get; set; }
            public Double ItemNetIncomeSoldout { get; set; }

        }

        public class ItemsPassedShelfLife
        {

            public int ItemIdFpMaxSh { get; set; }
            public String ItemNameFpMaxSh { get; set; }
            public Double ItemAmountFpMaxSh { get; set; }
            public String ItemDescriptionFpMaxSh { get; set; }
            public Double ItemStockinpriceFpMaxSh { get; set; }
            public Double ItemStockoutpriceFpMaxSh { get; set; }
            public String ItemSupplierEmailFpMaxSh { get; set; }
            public Double ItemNetIncomeFpMaxSh { get; set; }

        }



        public class MostSoldItem
        {
            //Alltime MostSoldItems
            public int ProId { get; set; }
            public string ProName { get; set; }
            public Double TotQuaSold { get; set; }
            public string Desc { get; set; }
            public Double TotStockinprice { get; set; }
            public Double TotStockoutprice { get; set; }
            public DateTime Datesold { get; set; }
            public String supplieremail { get; set; }
            public Double NetIncomeFp { get; set; }



            public class SoldItemsToday
            {
                //MostSoldItems in Previous day
                public int ProIdToday { get; set; }
                public string ProNameToday { get; set; }
                public Double TotQuaSoldToday { get; set; }
                public string DescToday { get; set; }
                public Double StockinpriceToday { get; set; }
                public Double StockoutpriceToday { get; set; }
                public DateTime DatesoldToday { get; set; }
                public String supplieremaiToday { get; set; }
                public Double NetIncomeFpToday { get; set; }

            }

            public class MostSoldItemsPreDay
            {
                //MostSoldItems in Previous day
                public int ProIdPreDay { get; set; }
                public string ProNamePreDay { get; set; }
                public Double TotQuaSoldPreDay { get; set; }
                public string DescPreDay { get; set; }
                public Double StockinpricePreDay { get; set; }
                public Double StockoutpricePreDay { get; set; }
                public DateTime DatesoldPreDay { get; set; }
                public String supplieremaiPreDayl { get; set; }
                public Double NetIncomeFpPreDay { get; set; }

            }

            public class MostSoldItemsPreTwoDay
            {
                //MostSoldItems in Previous day
                public int ProIdPreTwoDay { get; set; }
                public string ProNamePreTwoDay { get; set; }
                public Double TotQuaSoldPreTwoDay { get; set; }
                public string DescPreTwoDay { get; set; }
                public Double StockinpricePreTwoDay { get; set; }
                public Double StockoutpricePreTwoDay { get; set; }
                public DateTime DatesoldPreTwoDay { get; set; }
                public String supplieremaiPreTwoDayl { get; set; }
                public Double NetIncomeFpPreTwoDay { get; set; }

            }


            public class MostSoldItemsPreWeek
            {
                //MostSoldItems in Previous day
                public int ProIdPreWeek { get; set; }
                public string ProNamePreWeek { get; set; }
                public Double TotQuaSoldPreWeek { get; set; }
                public string DescPreWeek { get; set; }
                public Double StockinpricePreWeek { get; set; }
                public Double StockoutpricePreWeek { get; set; }
                public DateTime DatesoldPreWeek { get; set; }
                public String supplieremaiPreDayl { get; set; }
                public Double NetIncomeFpPreWeek { get; set; }

            }



            public class MostSoldItemsPreTwoWeeks
            {
                //MostSoldItems in Previous day
                public int ProIdPreTwoWeeks { get; set; }
                public string ProNamePreTwoWeeks { get; set; }
                public Double TotQuaSoldPreTwoWeeks { get; set; }
                public string DescPreTwoWeeks { get; set; }
                public Double StockinpricePreTwoWeeks { get; set; }
                public Double StockoutpricePreTwoWeeks { get; set; }
                public DateTime DatesoldPreTwoWeeks { get; set; }
                public String supplieremaiPreDayl { get; set; }
                public Double NetIncomeFpPreTwoWeeks { get; set; }

            }


            public class MostSoldItemsPreThreeWeeks
            {
                //MostSoldItems in Previous day
                public int ProIdPreThreeWeeks { get; set; }
                public string ProNamePreThreeWeeks { get; set; }
                public Double TotQuaSoldPreThreeWeeks { get; set; }
                public string DescPreThreeWeeks { get; set; }
                public Double StockinpricePreThreeWeeks { get; set; }
                public Double StockoutpricePreThreeWeeks { get; set; }
                public DateTime DatesoldPreThreeWeeks { get; set; }
                public String supplieremaiPreDayl { get; set; }
                public Double NetIncomeFpPreThreeWeeks { get; set; }

            }


            public class MostSoldItemsPreMonth
            {
                //MostSoldItems in Previous day
                public int ProIdPreMonth { get; set; }
                public string ProNamePreMonth { get; set; }
                public Double TotQuaSoldPreMonth { get; set; }
                public string DescPreMonth { get; set; }
                public Double StockinpricePreMonth { get; set; }
                public Double StockoutpricePreMonth { get; set; }
                public DateTime DatesoldPreMonth { get; set; }
                public String supplieremaiPreDayl { get; set; }
                public Double NetIncomeFpPreMonth { get; set; }

            }

        }

        public double FPRequiredAmount { get; set; }




        public string Name { get; set; }
        public Double TotalAmountSold { get; set; }
        public string Description { get; set; }
        public Double StockInPricePerKg { get; set; }
        public Double StockOutPricePerKg { get; set; }





        //Packed foods Data holder

        public String TableNamePAF { get; set; }
        public int TotNumItemsPAF { get; set; }
        public Double TotQuantityOfItemsPAF { get; set; }
        public Double TotalStInPricePAF { get; set; }
        public Double TotalStOPricePAF { get; set; }
        public Double NetIncomePAF { get; set; }
        public String mostSoldItemPAF { get; set; }
        public String MostProfitableItemPAF { get; set; }
        public String SoldOutItemPAF { get; set; }
        public String AbundantItemPAF { get; set; }
        public String ItemDescriptionPAF { get; set; }
        public String SupplierEmailPAF { get; set; }
        public String ExpiredItemPAF { get; set; }




        public List<PASoldItemsToday> PASoldItemsToday { get; set; } = new List<PASoldItemsToday>();
        public List<PAMostSoldItem> PAMostSoldItems { get; set; } = new List<PAMostSoldItem>();
        public List<PAMostSoldItemsPreDay> PAMostSoldItemsPreDay { get; set; } = new List<PAMostSoldItemsPreDay>();
        public List<PAMostSoldItemsPreWeek> PAMostSoldItemsPreWeek { get; set; } = new List<PAMostSoldItemsPreWeek>();
        public List<PAMostSoldItemsPreTwoWeeks> PAMostSoldItemsPreTwoWeeks { get; set; } = new List<PAMostSoldItemsPreTwoWeeks>();
        public List<PAMostSoldItemsPreThreeWeeks> PAMostSoldItemsPreThreeWeeks { get; set; } = new List<PAMostSoldItemsPreThreeWeeks>();
        public List<PAMostSoldItemsPreMonth> PAMostSoldItemsPreMonth { get; set; } = new List<PAMostSoldItemsPreMonth>();
        public List<PAExpiredItems> PAItemExpired { get; set; } = new List<PAExpiredItems>();
        public List<PASoldOutItems> PAvarSoldOutItems { get; set; } = new List<PASoldOutItems>();
        public List<PASoldItemsRecord> PASoldItemsRecords { get; set; } = new List<PASoldItemsRecord>();
        public List<PAForcastResult> PAForcastResults { get; set; } = new List<PAForcastResult>();





        public Double PATotalAmountSoldToday { get; set; }
        public Double PATotalAmountSoldYesterday { get; set; }
        public Double PATotalAmountSoldPastWeek { get; set; }
        public Double PATotalAmountSoldPastTwoWeeks { get; set; }
        public Double PATotalAmountSoldPastThreeWeeks { get; set; }
        public Double PATotalAmountSoldPastMonth { get; set; }



        public Double PATotalStockInPriceOfItemsSoldToday { get; set; }
        public Double PATotalStockInPriceOfItemsSoldYesterday { get; set; }
        public Double PATotalStockInPriceOfItemsSoldLastWeek { get; set; }
        public Double PATotalStockInPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double PATotalStockInPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double PATotalStockInPriceOfItemsSoldLastMonth { get; set; }



        public Double PATotalStockOutPriceOfItemsSoldToday { get; set; }
        public Double PATotalStockOutPriceOfItemsSoldYesterday { get; set; }
        public Double PATotalStockOutPriceOfItemsSoldLastWeek { get; set; }
        public Double PATotalStockOutPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double PATotalStockOutPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double PATotalStockOutPriceOfItemsSoldLastMonth { get; set; }




        public Double PATotalIncomeOfItemsSoldToday { get; set; }
        public Double PATotalIncomeOfItemsSoldYesterday { get; set; }
        public Double PATotalIncomeOfItemsSoldLastWeek { get; set; }
        public Double PATotalIncomeOfItemsSoldLastTwoWeeks { get; set; }
        public Double PATotalIncomeOfItemsSoldLastThreeWeeks { get; set; }
        public Double PATotalIncomeOfItemsSoldLastMonth { get; set; }
        //pu


        public class PAForcastResult
        {
            public float PredictedSales { get; set; }
            public float LowerBounds { get; set; }
            public float UpperBounds { get; set; }
        }
        public class PASoldItemsRecord
        {

            public int ItemIdSoldrec { get; set; }
            public String ItemNameSoldrec { get; set; }
            public Double ItemAmountSoldrec { get; set; }
            public String ItemDescriptionSoldrec { get; set; }
            public Double ItemStockinpriceSoldrec { get; set; }
            public Double ItemStockoutpriceSoldrec { get; set; }
            public String ItemSupplierEmailSoldrec { get; set; }
            public Double ItemNetIncomeSoldrec { get; set; }

        }

        public class PASoldOutItems
        {

            public int PAItemIdSoldout { get; set; }
            public String PAItemNameSoldout { get; set; }
            public Double PAItemQuantitySoldout { get; set; }
            public String PAItemDescriptionSoldout { get; set; }
            public Double PAItemStockinpriceSoldout { get; set; }
            public Double PAItemStockoutpriceSoldout { get; set; }
            public String PAItemSupplierEmailSoldout { get; set; }
            public Double PAItemNetIncomeSoldout { get; set; }

        }

        public class PAExpiredItems
        {

            public int PAItemIdExp { get; set; }
            public String PAItemNameExp { get; set; }
            public Double PAItemQuantityExp { get; set; }
            public String PAItemDescriptionExp { get; set; }
            public Double PAItemStockinpriceExp { get; set; }
            public Double PAItemStockoutpriceExp { get; set; }
            public String PAItemSupplierEmailExp { get; set; }
            public Double PAItemNetIncomeExp { get; set; }

        }



        public class PAMostSoldItem
        {
            //Alltime MostSoldItems
            public int PAProId { get; set; }
            public string PAProName { get; set; }
            public Double PATotQuaSold { get; set; }
            public string PADesc { get; set; }
            public Double PATotStockinprice { get; set; }
            public Double PATotStockoutprice { get; set; }
            public DateTime PADatesold { get; set; }
            public String PAsupplieremail { get; set; }
            public Double PANetIncomeFp { get; set; }



            public class PASoldItemsToday
            {
                //MostSoldItems in Previous day
                public int PAProIdToday { get; set; }
                public string PAProNameToday { get; set; }
                public Double PATotQuaSoldToday { get; set; }
                public string PADescToday { get; set; }
                public Double PAStockinpriceToday { get; set; }
                public Double PAStockoutpriceToday { get; set; }
                public DateTime PADatesoldToday { get; set; }
                public String PAsupplieremaiToday { get; set; }
                public Double PANetIncomeFpToday { get; set; }

            }

            public class PAMostSoldItemsPreDay
            {
                //MostSoldItems in Previous day
                public int PAProIdPreDay { get; set; }
                public string PAProNamePreDay { get; set; }
                public Double PATotQuaSoldPreDay { get; set; }
                public string PADescPreDay { get; set; }
                public Double PAStockinpricePreDay { get; set; }
                public Double PAStockoutpricePreDay { get; set; }
                public DateTime PADatesoldPreDay { get; set; }
                public String PAsupplieremaiPreDayl { get; set; }
                public Double PANetIncomeFpPreDay { get; set; }

            }


            public class PAMostSoldItemsPreWeek
            {
                //MostSoldItems in Previous day
                public int PAProIdPreWeek { get; set; }
                public string PAProNamePreWeek { get; set; }
                public Double PATotQuaSoldPreWeek { get; set; }
                public string PADescPreWeek { get; set; }
                public Double PAStockinpricePreWeek { get; set; }
                public Double PAStockoutpricePreWeek { get; set; }
                public DateTime PADatesoldPreWeek { get; set; }
                public String PAsupplieremaiPreDayl { get; set; }
                public Double PANetIncomeFpPreWeek { get; set; }

            }



            public class PAMostSoldItemsPreTwoWeeks
            {
                //MostSoldItems in Previous day
                public int PAProIdPreTwoWeeks { get; set; }
                public string PAProNamePreTwoWeeks { get; set; }
                public Double PATotQuaSoldPreTwoWeeks { get; set; }
                public string PADescPreTwoWeeks { get; set; }
                public Double PAStockinpricePreTwoWeeks { get; set; }
                public Double PAStockoutpricePreTwoWeeks { get; set; }
                public DateTime PADatesoldPreTwoWeeks { get; set; }
                public String PAsupplieremaiPreDayl { get; set; }
                public Double PANetIncomeFpPreTwoWeeks { get; set; }

            }


            public class PAMostSoldItemsPreThreeWeeks
            {
                //MostSoldItems in Previous day
                public int PAProIdPreThreeWeeks { get; set; }
                public string PAProNamePreThreeWeeks { get; set; }
                public Double PATotQuaSoldPreThreeWeeks { get; set; }
                public string PADescPreThreeWeeks { get; set; }
                public Double PAStockinpricePreThreeWeeks { get; set; }
                public Double PAStockoutpricePreThreeWeeks { get; set; }
                public DateTime PADatesoldPreThreeWeeks { get; set; }
                public String PAsupplieremaiPreDayl { get; set; }
                public Double PANetIncomeFpPreThreeWeeks { get; set; }

            }


            public class PAMostSoldItemsPreMonth
            {
                //MostSoldItems in Previous day
                public int PAProIdPreMonth { get; set; }
                public string PAProNamePreMonth { get; set; }
                public Double PATotQuaSoldPreMonth { get; set; }
                public string PADescPreMonth { get; set; }
                public Double PAStockinpricePreMonth { get; set; }
                public Double PAStockoutpricePreMonth { get; set; }
                public DateTime PADatesoldPreMonth { get; set; }
                public String PAsupplieremaiPreDayl { get; set; }
                public Double PANetIncomeFpPreMonth { get; set; }

            }

        }



        //Pharmaceuticals Data Holder

        public String TableNamePHA { get; set; }
        public int TotNumItemsPHA { get; set; }
        public Double TotQuantityOfItemsPHA { get; set; }
        public Double TotalStInPricePHA { get; set; }
        public Double TotalStOPricePHA { get; set; }
        public Double NetIncomePHA { get; set; }
        public String mostSoldItemPHA { get; set; }
        public String MostProfitableItemPHA { get; set; }
        public String SoldOutItemPHA { get; set; }
        public String AbundantItemPHA { get; set; }
        public String ItemDescriptionPHA { get; set; }
        public String SupplierEmailPHA { get; set; }
        public String ExpiredItemPHA { get; set; }






        public List<PHASoldItemsToday> PHASoldItemsToday { get; set; } = new List<PHASoldItemsToday>();
        public List<PHAMostSoldItem> PHAMostSoldItems { get; set; } = new List<PHAMostSoldItem>();
        public List<PHAMostSoldItemsPreDay> PHAMostSoldItemsPreDay { get; set; } = new List<PHAMostSoldItemsPreDay>();
        public List<PHAMostSoldItemsPreWeek> PHAMostSoldItemsPreWeek { get; set; } = new List<PHAMostSoldItemsPreWeek>();
        public List<PHAMostSoldItemsPreTwoWeeks> PHAMostSoldItemsPreTwoWeeks { get; set; } = new List<PHAMostSoldItemsPreTwoWeeks>();
        public List<PHAMostSoldItemsPreThreeWeeks> PHAMostSoldItemsPreThreeWeeks { get; set; } = new List<PHAMostSoldItemsPreThreeWeeks>();
        public List<PHAMostSoldItemsPreMonth> PHAMostSoldItemsPreMonth { get; set; } = new List<PHAMostSoldItemsPreMonth>();
        public List<PHAExpiredItems> PHAItemExpired { get; set; } = new List<PHAExpiredItems>();
        public List<PHASoldOutItems> PHAvarSoldOutItems { get; set; } = new List<PHASoldOutItems>();
        public List<PHASoldItemsRecord> PHASoldItemsRecords { get; set; } = new List<PHASoldItemsRecord>();
        public List<PHAForcastResult> PHAForcastResults { get; set; } = new List<PHAForcastResult>();











        public Double PHATotalAmountSoldToday { get; set; }
        public Double PHATotalAmountSoldYesterday { get; set; }
        public Double PHATotalAmountSoldPastWeek { get; set; }
        public Double PHATotalAmountSoldPastTwoWeeks { get; set; }
        public Double PHATotalAmountSoldPastThreeWeeks { get; set; }
        public Double PHATotalAmountSoldPastMonth { get; set; }



        public Double PHATotalStockInPriceOfItemsSoldToday { get; set; }
        public Double PHATotalStockInPriceOfItemsSoldYesterday { get; set; }
        public Double PHATotalStockInPriceOfItemsSoldLastWeek { get; set; }
        public Double PHATotalStockInPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double PHATotalStockInPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double PHATotalStockInPriceOfItemsSoldLastMonth { get; set; }



        public Double PHATotalStockOutPriceOfItemsSoldToday { get; set; }
        public Double PHATotalStockOutPriceOfItemsSoldYesterday { get; set; }
        public Double PHATotalStockOutPriceOfItemsSoldLastWeek { get; set; }
        public Double PHATotalStockOutPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double PHATotalStockOutPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double PHATotalStockOutPriceOfItemsSoldLastMonth { get; set; }




        public Double PHATotalIncomeOfItemsSoldToday { get; set; }
        public Double PHATotalIncomeOfItemsSoldYesterday { get; set; }
        public Double PHATotalIncomeOfItemsSoldLastWeek { get; set; }
        public Double PHATotalIncomeOfItemsSoldLastTwoWeeks { get; set; }
        public Double PHATotalIncomeOfItemsSoldLastThreeWeeks { get; set; }
        public Double PHATotalIncomeOfItemsSoldLastMonth { get; set; }



        public class PHAForcastResult
        {
            public float PredictedSales { get; set; }
            public float LowerBounds { get; set; }
            public float UpperBounds { get; set; }
        }
        public class PHASoldItemsRecord
        {

            public int ItemIdSoldrec { get; set; }
            public String ItemNameSoldrec { get; set; }
            public Double ItemQuantitySoldrec { get; set; }
            public String ItemDescriptionSoldrec { get; set; }
            public Double ItemStockinpriceSoldrec { get; set; }
            public Double ItemStockoutpriceSoldrec { get; set; }
            public String ItemSupplierEmailSoldrec { get; set; }
            public Double ItemNetIncomeSoldrec { get; set; }

        }



        public class PHASoldOutItems
        {

            public int PHAItemIdSoldout { get; set; }
            public String PHAItemNameSoldout { get; set; }
            public Double PHAItemQuantitySoldout { get; set; }
            public String PHAItemDescriptionSoldout { get; set; }
            public Double PHAItemStockinpriceSoldout { get; set; }
            public Double PHAItemStockoutpriceSoldout { get; set; }
            public String PHAItemSupplierEmailSoldout { get; set; }
            public Double PHAItemNetIncomeSoldout { get; set; }

        }

        public class PHAExpiredItems
        {

            public int PHAItemIdExp { get; set; }
            public String PHAItemNameExp { get; set; }
            public Double PHAItemQuantityExp { get; set; }
            public String PHAItemDescriptionExp { get; set; }
            public Double PHAItemStockinpriceExp { get; set; }
            public Double PHAItemStockoutpriceExp { get; set; }
            public String PHAItemSupplierEmailExp { get; set; }
            public Double PHAItemNetIncomeExp { get; set; }

        }

        public class PHAMostSoldItem
        {
            //Alltime MostSoldItems
            public int PHAProId { get; set; }
            public string PHAProName { get; set; }
            public Double PHATotQuaSold { get; set; }
            public string PHADesc { get; set; }
            public Double PHATotStockinprice { get; set; }
            public Double PHATotStockoutprice { get; set; }
            public DateTime PHADatesold { get; set; }
            public String PHAsupplieremail { get; set; }
            public Double PHANetIncomeFp { get; set; }



            public class PHASoldItemsToday
            {
                //MostSoldItems in Previous day
                public int PHAProIdToday { get; set; }
                public string PHAProNameToday { get; set; }
                public Double PHATotQuaSoldToday { get; set; }
                public string PHADescToday { get; set; }
                public Double PHAStockinpriceToday { get; set; }
                public Double PHAStockoutpriceToday { get; set; }
                public DateTime PHADatesoldToday { get; set; }
                public String PHAsupplieremaiToday { get; set; }
                public Double PHANetIncomeFpToday { get; set; }

            }

            public class PHAMostSoldItemsPreDay
            {
                //MostSoldItems in Previous day
                public int PHAProIdPreDay { get; set; }
                public string PHAProNamePreDay { get; set; }
                public Double PHATotQuaSoldPreDay { get; set; }
                public string PHADescPreDay { get; set; }
                public Double PHAStockinpricePreDay { get; set; }
                public Double PHAStockoutpricePreDay { get; set; }
                public DateTime PHADatesoldPreDay { get; set; }
                public String PHAsupplieremaiPreDayl { get; set; }
                public Double PHANetIncomeFpPreDay { get; set; }

            }


            public class PHAMostSoldItemsPreWeek
            {
                //MostSoldItems in Previous day
                public int PHAProIdPreWeek { get; set; }
                public string PHAProNamePreWeek { get; set; }
                public Double PHATotQuaSoldPreWeek { get; set; }
                public string PHADescPreWeek { get; set; }
                public Double PHAStockinpricePreWeek { get; set; }
                public Double PHAStockoutpricePreWeek { get; set; }
                public DateTime PHADatesoldPreWeek { get; set; }
                public String PHAsupplieremaiPreDayl { get; set; }
                public Double PHANetIncomeFpPreWeek { get; set; }

            }



            public class PHAMostSoldItemsPreTwoWeeks
            {
                //MostSoldItems in Previous day
                public int PHAProIdPreTwoWeeks { get; set; }
                public string PHAProNamePreTwoWeeks { get; set; }
                public Double PHATotQuaSoldPreTwoWeeks { get; set; }
                public string PHADescPreTwoWeeks { get; set; }
                public Double PHAStockinpricePreTwoWeeks { get; set; }
                public Double PHAStockoutpricePreTwoWeeks { get; set; }
                public DateTime PHADatesoldPreTwoWeeks { get; set; }
                public String PHAsupplieremaiPreDayl { get; set; }
                public Double PHANetIncomeFpPreTwoWeeks { get; set; }

            }


            public class PHAMostSoldItemsPreThreeWeeks
            {
                //MostSoldItems in Previous day
                public int PHAProIdPreThreeWeeks { get; set; }
                public string PHAProNamePreThreeWeeks { get; set; }
                public Double PHATotQuaSoldPreThreeWeeks { get; set; }
                public string PHADescPreThreeWeeks { get; set; }
                public Double PHAStockinpricePreThreeWeeks { get; set; }
                public Double PHAStockoutpricePreThreeWeeks { get; set; }
                public DateTime PHADatesoldPreThreeWeeks { get; set; }
                public String PHAsupplieremaiPreDayl { get; set; }
                public Double PHANetIncomeFpPreThreeWeeks { get; set; }

            }


            public class PHAMostSoldItemsPreMonth
            {
                //MostSoldItems in Previous day
                public int PHAProIdPreMonth { get; set; }
                public string PHAProNamePreMonth { get; set; }
                public Double PHATotQuaSoldPreMonth { get; set; }
                public string PHADescPreMonth { get; set; }
                public Double PHAStockinpricePreMonth { get; set; }
                public Double PHAStockoutpricePreMonth { get; set; }
                public DateTime PHADatesoldPreMonth { get; set; }
                public String PHAsupplieremaiPreDayl { get; set; }
                public Double PHANetIncomeFpPreMonth { get; set; }

            }

        }





        //Tools Table Data Holder
        public String TableNameTools { get; set; }
        public int TotNumItemsTools { get; set; }
        public Double TotQuantityOfItemsTools { get; set; }
        public Double TotalStInPriceTools { get; set; }
        public Double TotalStOPriceTools { get; set; }
        public Double NetIncomeTools { get; set; }
        public String mostSoldItemTools { get; set; }
        public String MostProfitableItemTools { get; set; }
        public String SoldOutItemTools { get; set; }
        public String AbundantItemTools { get; set; }
        public String ItemDescriptionTools { get; set; }
        public String SupplierEmailTools { get; set; }
        public String ExpiredItemTools { get; set; }












        public List<TSoldItemsToday> TSoldItemsToday { get; set; } = new List<TSoldItemsToday>();
        public List<TMostSoldItem> TMostSoldItems { get; set; } = new List<TMostSoldItem>();
        public List<TMostSoldItemsPreDay> TMostSoldItemsPreDay { get; set; } = new List<TMostSoldItemsPreDay>();
        public List<TMostSoldItemsPreWeek> TMostSoldItemsPreWeek { get; set; } = new List<TMostSoldItemsPreWeek>();
        public List<TMostSoldItemsPreTwoWeeks> TMostSoldItemsPreTwoWeeks { get; set; } = new List<TMostSoldItemsPreTwoWeeks>();
        public List<TMostSoldItemsPreThreeWeeks> TMostSoldItemsPreThreeWeeks { get; set; } = new List<TMostSoldItemsPreThreeWeeks>();
        public List<TMostSoldItemsPreMonth> TMostSoldItemsPreMonth { get; set; } = new List<TMostSoldItemsPreMonth>();
        public List<TExpiredItems> TItemExpired { get; set; } = new List<TExpiredItems>();
        public List<TSoldOutItems> TvarSoldOutItems { get; set; } = new List<TSoldOutItems>();
        public List<TSoldItemsRecord> TSoldItemsRecords { get; set; } = new List<TSoldItemsRecord>();
        public List<TForcastResult> TForcastResults { get; set; } = new List<TForcastResult>();








        public Double ToTotalAmountSoldToday { get; set; }
        public Double ToTotalAmountSoldYesterday { get; set; }
        public Double ToTotalAmountSoldPastWeek { get; set; }
        public Double ToTotalAmountSoldPastTwoWeeks { get; set; }
        public Double ToTotalAmountSoldPastThreeWeeks { get; set; }
        public Double ToTotalAmountSoldPastMonth { get; set; }



        public Double ToTotalStockInPriceOfItemsSoldToday { get; set; }
        public Double ToTotalStockInPriceOfItemsSoldYesterday { get; set; }
        public Double ToTotalStockInPriceOfItemsSoldLastWeek { get; set; }
        public Double ToTotalStockInPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double ToTotalStockInPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double ToTotalStockInPriceOfItemsSoldLastMonth { get; set; }



        public Double ToTotalStockOutPriceOfItemsSoldToday { get; set; }
        public Double ToTotalStockOutPriceOfItemsSoldYesterday { get; set; }
        public Double ToTotalStockOutPriceOfItemsSoldLastWeek { get; set; }
        public Double ToTotalStockOutPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double ToTotalStockOutPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double ToTotalStockOutPriceOfItemsSoldLastMonth { get; set; }




        public Double ToTotalIncomeOfItemsSoldToday { get; set; }
        public Double ToTotalIncomeOfItemsSoldYesterday { get; set; }
        public Double ToTotalIncomeOfItemsSoldLastWeek { get; set; }
        public Double ToTotalIncomeOfItemsSoldLastTwoWeeks { get; set; }
        public Double ToTotalIncomeOfItemsSoldLastThreeWeeks { get; set; }
        public Double ToTotalIncomeOfItemsSoldLastMonth { get; set; }



        public class TForcastResult
        {
            public float PredictedSales { get; set; }
            public float LowerBounds { get; set; }
            public float UpperBounds { get; set; }
        }

        public class TSoldItemsRecord
        {

            public int ItemIdSoldrec { get; set; }
            public String ItemNameSoldrec { get; set; }
            public Double ItemQuantitySoldrec { get; set; }
            public String ItemDescriptionSoldrec { get; set; }
            public Double ItemStockinpriceSoldrec { get; set; }
            public Double ItemStockoutpriceSoldrec { get; set; }
            public String ItemSupplierEmailSoldrec { get; set; }
            public Double ItemNetIncomeSoldrec { get; set; }

        }

        public class TSoldOutItems
        {

            public int TItemIdSoldout { get; set; }
            public String TItemNameSoldout { get; set; }
            public Double TItemQuantitySoldout { get; set; }
            public String TItemDescriptionSoldout { get; set; }
            public Double TItemStockinpriceSoldout { get; set; }
            public Double TItemStockoutpriceSoldout { get; set; }
            public String TItemSupplierEmailSoldout { get; set; }
            public Double TItemNetIncomeSoldout { get; set; }

        }

        public class TExpiredItems
        {

            public int TItemIdExp { get; set; }
            public String TItemNameExp { get; set; }
            public Double TItemQuantityExp { get; set; }
            public String TItemDescriptionExp { get; set; }
            public Double TItemStockinpriceExp { get; set; }
            public Double TItemStockoutpriceExp { get; set; }
            public String TItemSupplierEmailExp { get; set; }
            public Double TItemNetIncomeExp { get; set; }

        }


        public class TMostSoldItem
        {
            //Alltime MostSoldItems
            public int TProId { get; set; }
            public string TProName { get; set; }
            public Double TTotQuaSold { get; set; }
            public string TDesc { get; set; }
            public Double TTotStockinprice { get; set; }
            public Double TTotStockoutprice { get; set; }
            public DateTime TDatesold { get; set; }
            public String Tsupplieremail { get; set; }
            public Double TNetIncomeFp { get; set; }



            public class TSoldItemsToday
            {
                //SoldItems in Today
                public int TProIdToday { get; set; }
                public string TProNameToday { get; set; }
                public Double TTotQuaSoldToday { get; set; }
                public string TDescToday { get; set; }
                public Double TStockinpriceToday { get; set; }
                public Double TStockoutpriceToday { get; set; }
                public DateTime TDatesoldToday { get; set; }
                public String TsupplieremaiToday { get; set; }
                public Double TNetIncomeFpToday { get; set; }

            }

            public class TMostSoldItemsPreDay
            {
                //MostSoldItems in Previous day
                public int TProIdPreDay { get; set; }
                public string TProNamePreDay { get; set; }
                public Double TTotQuaSoldPreDay { get; set; }
                public string TDescPreDay { get; set; }
                public Double TStockinpricePreDay { get; set; }
                public Double TStockoutpricePreDay { get; set; }
                public DateTime TDatesoldPreDay { get; set; }
                public String TsupplieremaiPreDayl { get; set; }
                public Double TNetIncomeFpPreDay { get; set; }

            }


            public class TMostSoldItemsPreWeek
            {
                //MostSoldItems in Previous PreWeek
                public int TProIdPreWeek { get; set; }
                public string TProNamePreWeek { get; set; }
                public Double TTotQuaSoldPreWeek { get; set; }
                public string TDescPreWeek { get; set; }
                public Double TStockinpricePreWeek { get; set; }
                public Double TStockoutpricePreWeek { get; set; }
                public DateTime TDatesoldPreWeek { get; set; }
                public String TsupplieremaiPreDayl { get; set; }
                public Double TNetIncomeFpPreWeek { get; set; }

            }



            public class TMostSoldItemsPreTwoWeeks
            {
                //MostSoldItems in Previous TwoWeeks
                public int TProIdPreTwoWeeks { get; set; }
                public string TProNamePreTwoWeeks { get; set; }
                public Double TTotQuaSoldPreTwoWeeks { get; set; }
                public string TDescPreTwoWeeks { get; set; }
                public Double TStockinpricePreTwoWeeks { get; set; }
                public Double TStockoutpricePreTwoWeeks { get; set; }
                public DateTime TDatesoldPreTwoWeeks { get; set; }
                public String TsupplieremaiPreDayl { get; set; }
                public Double TNetIncomeFpPreTwoWeeks { get; set; }

            }


            public class TMostSoldItemsPreThreeWeeks
            {
                //MostSoldItems in Previous ThreeWeeks
                public int TProIdPreThreeWeeks { get; set; }
                public string TProNamePreThreeWeeks { get; set; }
                public Double TTotQuaSoldPreThreeWeeks { get; set; }
                public string TDescPreThreeWeeks { get; set; }
                public Double TStockinpricePreThreeWeeks { get; set; }
                public Double TStockoutpricePreThreeWeeks { get; set; }
                public DateTime TDatesoldPreThreeWeeks { get; set; }
                public String TsupplieremaiPreDayl { get; set; }
                public Double TNetIncomeFpPreThreeWeeks { get; set; }

            }


            public class TMostSoldItemsPreMonth
            {
                //MostSoldItems in Previous Month
                public int TProIdPreMonth { get; set; }
                public string TProNamePreMonth { get; set; }
                public Double TTotQuaSoldPreMonth { get; set; }
                public string TDescPreMonth { get; set; }
                public Double TStockinpricePreMonth { get; set; }
                public Double TStockoutpricePreMonth { get; set; }
                public DateTime TDatesoldPreMonth { get; set; }
                public String TsupplieremaiPreDayl { get; set; }
                public Double TNetIncomeFpPreMonth { get; set; }

            }

        }



        //Others Table Data Holder

        public String TableNameOth { get; set; }
        public int TotNumItemsOth { get; set; }
        public Double TotQuantityOfItemsOth { get; set; }
        public Double TotalStInPriceOth { get; set; }
        public Double TotalStOPriceOth { get; set; }
        public Double NetIncomeOth { get; set; }
        public String mostSoldItemOth { get; set; }
        public String MostProfitableItemOth { get; set; }
        public String SoldOutItemOth { get; set; }
        public String AbundantItemOth { get; set; }
        public String ItemDescriptionOth { get; set; }
        public String SupplierEmailOth { get; set; }
        public String ExpiredItemOth { get; set; }





        public List<OTSoldItemsToday> OTSoldItemsToday { get; set; } = new List<OTSoldItemsToday>();
        public List<OTMostSoldItem> OTMostSoldItems { get; set; } = new List<OTMostSoldItem>();
        public List<OTMostSoldItemsPreDay> OTMostSoldItemsPreDay { get; set; } = new List<OTMostSoldItemsPreDay>();
        public List<OTMostSoldItemsPreWeek> OTMostSoldItemsPreWeek { get; set; } = new List<OTMostSoldItemsPreWeek>();
        public List<OTMostSoldItemsPreTwoWeeks> OTMostSoldItemsPreTwoWeeks { get; set; } = new List<OTMostSoldItemsPreTwoWeeks>();
        public List<OTMostSoldItemsPreThreeWeeks> OTMostSoldItemsPreThreeWeeks { get; set; } = new List<OTMostSoldItemsPreThreeWeeks>();
        public List<OTMostSoldItemsPreMonth> OTMostSoldItemsPreMonth { get; set; } = new List<OTMostSoldItemsPreMonth>();
        public List<OTExpiredItems> OTItemExpired { get; set; } = new List<OTExpiredItems>();
        public List<OTSoldOutItems> OTvarSoldOutItems { get; set; } = new List<OTSoldOutItems>();
        public List<OTSoldItemsRecord> OTSoldItemsRecords { get; set; } = new List<OTSoldItemsRecord>();
        public List<OTForcastResult> OTForcastResults { get; set; } = new List<OTForcastResult>();







        public Double OTTotalAmountSoldToday { get; set; }
        public Double OTTotalAmountSoldYesterday { get; set; }
        public Double OTTotalAmountSoldPastWeek { get; set; }
        public Double OTTotalAmountSoldPastTwoWeeks { get; set; }
        public Double OTTotalAmountSoldPastThreeWeeks { get; set; }
        public Double OTTotalAmountSoldPastMonth { get; set; }



        public Double OTTotalStockInPriceOfItemsSoldToday { get; set; }
        public Double OTTotalStockInPriceOfItemsSoldYesterday { get; set; }
        public Double OTTotalStockInPriceOfItemsSoldLastWeek { get; set; }
        public Double OTTotalStockInPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double OTTotalStockInPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double OTTotalStockInPriceOfItemsSoldLastMonth { get; set; }



        public Double OTTotalStockOutPriceOfItemsSoldToday { get; set; }
        public Double OTTotalStockOutPriceOfItemsSoldYesterday { get; set; }
        public Double OTTotalStockOutPriceOfItemsSoldLastWeek { get; set; }
        public Double OTTotalStockOutPriceOfItemsSoldLastTwoWeeks { get; set; }
        public Double OTTotalStockOutPriceOfItemsSoldLastThreeWeeks { get; set; }
        public Double OTTotalStockOutPriceOfItemsSoldLastMonth { get; set; }




        public Double OTTotalIncomeOfItemsSoldToday { get; set; }
        public Double OTTotalIncomeOfItemsSoldYesterday { get; set; }
        public Double OTTotalIncomeOfItemsSoldLastWeek { get; set; }
        public Double OTTotalIncomeOfItemsSoldLastTwoWeeks { get; set; }
        public Double OTTotalIncomeOfItemsSoldLastThreeWeeks { get; set; }
        public Double OTTotalIncomeOfItemsSoldLastMonth { get; set; }



        public class OTForcastResult
        {
            public float PredictedSales { get; set; }
            public float LowerBounds { get; set; }
            public float UpperBounds { get; set; }
        }
        public class OTSoldItemsRecord
        {

            public int ItemIdSoldrec { get; set; }
            public String ItemNameSoldrec { get; set; }
            public Double ItemQuantitySoldrec { get; set; }
            public String ItemDescriptionSoldrec { get; set; }
            public Double ItemStockinpriceSoldrec { get; set; }
            public Double ItemStockoutpriceSoldrec { get; set; }
            public String ItemSupplierEmailSoldrec { get; set; }
            public Double ItemNetIncomeSoldrec { get; set; }

        }


        public class OTSoldOutItems
        {

            public int OTItemIdSoldout { get; set; }
            public String OTItemNameSoldout { get; set; }
            public Double OTItemQuantitySoldout { get; set; }
            public String OTItemDescriptionSoldout { get; set; }
            public Double OTItemStockinpriceSoldout { get; set; }
            public Double OTItemStockoutpriceSoldout { get; set; }
            public String OTItemSupplierEmailSoldout { get; set; }
            public Double OTItemNetIncomeSoldout { get; set; }

        }


        public class OTExpiredItems
        {

            public int OTItemIdExp { get; set; }
            public String OTItemNameExp { get; set; }
            public Double OTItemQuantityExp { get; set; }
            public String OTItemDescriptionExp { get; set; }
            public Double OTItemStockinpriceExp { get; set; }
            public Double OTItemStockoutpriceExp { get; set; }
            public String OTItemSupplierEmailExp { get; set; }
            public Double OTItemNetIncomeExp { get; set; }

        }


        public class OTMostSoldItem
        {
            //Alltime MostSoldItems
            public int OTProId { get; set; }
            public string OTProName { get; set; }
            public Double OTTotQuaSold { get; set; }
            public string OTDesc { get; set; }
            public Double OTTotStockinprice { get; set; }
            public Double OTTotStockoutprice { get; set; }
            public DateTime OTDatesold { get; set; }
            public String OTsupplieremail { get; set; }
            public Double OTNetIncomeFp { get; set; }



            public class OTSoldItemsToday
            {
                //SoldItems in Today
                public int OTProIdToday { get; set; }
                public string OTProNameToday { get; set; }
                public Double OTTotQuaSoldToday { get; set; }
                public string OTDescToday { get; set; }
                public Double OTStockinpriceToday { get; set; }
                public Double OTStockoutpriceToday { get; set; }
                public DateTime OTDatesoldToday { get; set; }
                public String OTsupplieremaiToday { get; set; }
                public Double OTNetIncomeFpToday { get; set; }

            }

            public class OTMostSoldItemsPreDay
            {
                //MostSoldItems in Previous day
                public int OTProIdPreDay { get; set; }
                public string OTProNamePreDay { get; set; }
                public Double OTTotQuaSoldPreDay { get; set; }
                public string OTDescPreDay { get; set; }
                public Double OTStockinpricePreDay { get; set; }
                public Double OTStockoutpricePreDay { get; set; }
                public DateTime OTDatesoldPreDay { get; set; }
                public String OTsupplieremaiPreDayl { get; set; }
                public Double OTNetIncomeFpPreDay { get; set; }

            }


            public class OTMostSoldItemsPreWeek
            {
                //MostSoldItems in Previous PreWeek
                public int OTProIdPreWeek { get; set; }
                public string OTProNamePreWeek { get; set; }
                public Double OTTotQuaSoldPreWeek { get; set; }
                public string OTDescPreWeek { get; set; }
                public Double OTStockinpricePreWeek { get; set; }
                public Double OTStockoutpricePreWeek { get; set; }
                public DateTime OTDatesoldPreWeek { get; set; }
                public String OTsupplieremaiPreDayl { get; set; }
                public Double OTNetIncomeFpPreWeek { get; set; }

            }



            public class OTMostSoldItemsPreTwoWeeks
            {
                //MostSoldItems in Previous TwoWeeks
                public int OTProIdPreTwoWeeks { get; set; }
                public string OTProNamePreTwoWeeks { get; set; }
                public Double OTTotQuaSoldPreTwoWeeks { get; set; }
                public string OTDescPreTwoWeeks { get; set; }
                public Double OTStockinpricePreTwoWeeks { get; set; }
                public Double OTStockoutpricePreTwoWeeks { get; set; }
                public DateTime OTDatesoldPreTwoWeeks { get; set; }
                public String OTsupplieremaiPreDayl { get; set; }
                public Double OTNetIncomeFpPreTwoWeeks { get; set; }

            }


            public class OTMostSoldItemsPreThreeWeeks
            {
                //MostSoldItems in Previous ThreeWeeks
                public int OTProIdPreThreeWeeks { get; set; }
                public string OTProNamePreThreeWeeks { get; set; }
                public Double OTTotQuaSoldPreThreeWeeks { get; set; }
                public string OTDescPreThreeWeeks { get; set; }
                public Double OTStockinpricePreThreeWeeks { get; set; }
                public Double OTStockoutpricePreThreeWeeks { get; set; }
                public DateTime OTDatesoldPreThreeWeeks { get; set; }
                public String OTsupplieremaiPreDayl { get; set; }
                public Double OTNetIncomeFpPreThreeWeeks { get; set; }

            }


            public class OTMostSoldItemsPreMonth
            {
                //MostSoldItems in Previous Month
                public int OTProIdPreMonth { get; set; }
                public string OTProNamePreMonth { get; set; }
                public Double OTTotQuaSoldPreMonth { get; set; }
                public string OTDescPreMonth { get; set; }
                public Double OTStockinpricePreMonth { get; set; }
                public Double OTStockoutpricePreMonth { get; set; }
                public DateTime OTDatesoldPreMonth { get; set; }
                public String OTsupplieremaiPreDayl { get; set; }
                public Double OTNetIncomeFpPreMonth { get; set; }

            }

        }

        public String SelectedItem { get; set; }
        public int SelectedId { get; set; }
        public List<SelectListItem> ItemName { get; set; } = new List<SelectListItem>();
        public Dictionary<string, object> row { get; set; }

        public ViewModel1()
        {
            ItemName = new List<SelectListItem>();
            FPSoldItemsRecord = new List<SoldItemsRecordFP>();
        }


    }

}





