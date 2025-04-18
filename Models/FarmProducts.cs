using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace SUP_INV1._0.Models
{

    public class FarmProducts
    {
        [Key]
        public int FID { get; set; }
        public String Name { get; set; }
        public Double Amount_In_Kg { get; set; }
        public String Description { get; set; }
        public int Maximum_Shelf_Life_Days { get; set; }
        public Double Stock_In_Price_Per_Kg { get; set; }
        public Double Stock_Out_Price_Per_Kg { get; set; }
        public DateTime Date_Created { get; set; }
        [AllowNull]
        public String Supplier_Email { get; set; }

    }

    public class PackedFoods
    {
        [Key]
        public int PID { get; set; }
        public String Name { get; set; }
        public Double Quantity { get; set; }
        public String Description { get; set; }
        public DateTime Expiry_Date { get; set; }
        public Double Stock_In_Price_Per_Item { get; set; }
        public Double Stock_Out_Price_Per_Item { get; set; }
        public DateTime Date_Created { get; set; }
        [AllowNull]
        public String Supplier_Email { get; set; }
    }
    public class Pharmaceuticals
    {
        [Key]
        public int PHID { get; set; }
        public String Name { get; set; }
        public Double Quantity { get; set; }
        public String Description { get; set; }
        public DateTime Expiry_Date { get; set; }
        public Double Stock_In_Price_Per_Item { get; set; }
        public Double Stock_Out_Price_Per_Item { get; set; }
        public DateTime Date_Created { get; set; }
        [AllowNull]
        public String Supplier_Email { get; set; }
    }
    public class Tools
    {
        [Key]
        public int TID { get; set; }
        public String Name { get; set; }
        public Double Quantity { get; set; }
        public String Description { get; set; }
        public Double Stock_In_Price_Per_Item { get; set; }
        public Double Stock_Out_Price_Per_Item { get; set; }
        public DateTime Date_Created { get; set; }
        [AllowNull]
        public String Supplier_Email { get; set; }
    }
    public class Others
    {
        [Key]
        public int OID { get; set; }
        public String Name { get; set; }
        public Double Quantity { get; set; }
        public String Description { get; set; }
        [AllowNull]
        public DateTime Expiry_Date { get; set; }
        public Double Stock_In_Price_Per_Item { get; set; }
        public Double Stock_Out_Price_Per_Item { get; set; }
        public DateTime Date_Created { get; set; }
        [AllowNull]
        public String Supplier_Email { get; set; }
    }


    public class FARMPRODUCTSSALESRECORD
    {
        [Key]
        public int FPRecID { get; set; }
        public int ItemID { get; set; }
        public String FPRecName { get; set; }
        public Double FPRecSoldAmount { get; set; }
        public String FPRecDescription { get; set; }
        public Double FPRecStockInPrice { get; set; }
        public Double FPRecStockOutPrice { get; set; }
        public DateTime FPRecDateSold { get; set; }
        public String FPRecSupplierEmail { get; set; }
    }
    public class PACKEDFOODSSALESRECORD
    {
        [Key]
        public int PARecID { get; set; }
        public int ItemID { get; set; }
        public String PARecName { get; set; }
        public Double PARecSoldQuantity { get; set; }
        public String PARecDescription { get; set; }
        public Double PARecStockInPrice { get; set; }
        public Double PARecStockOutPrice { get; set; }
        public DateTime PARecDateSold { get; set; }
        public String PARecSupplierEmail { get; set; }
    }
    public class PHARMACEUTICALSSALESRECORD
    {
        [Key]
        public int PHARecID { get; set; }
        public int ItemID { get; set; }
        public String PHARecName { get; set; }
        public Double PHARecSoldQuantity { get; set; }
        public String PHARecDescription { get; set; }
        public Double PHARecStockInPrice { get; set; }
        public Double PHARecStockOutPrice { get; set; }
        public DateTime PHARecDateSold { get; set; }
        public String PHARecSupplierEmail { get; set; }
    }
    public class TOOLSSALESRECORD
    {
        [Key]
        public int TOOLSRecID { get; set; }
        public int ItemID { get; set; }
        public String TOOLSRecName { get; set; }
        public Double TOOLSRecSoldQuantity { get; set; }
        public String TOOLSRecDescription { get; set; }
        public Double TOOLSRecStockInPrice { get; set; }
        public Double TOOLSRecStockOutPrice { get; set; }
        public DateTime TOOLSRecDateSold { get; set; }
        public String TOOLSRecSupplierEmail { get; set; }
    }
    public class OTHERSSALESRECORD
    {
        [Key]
        public int OTHRecID { get; set; }
        public int ItemID { get; set; }
        public String OTHRecName { get; set; }
        public Double OTHRecSoldQuantity { get; set; }
        public String OTHRecDescription { get; set; }
        public Double OTHRecStockInPrice { get; set; }
        public Double OTHRecStockOutPrice { get; set; }
        public DateTime OTHRecDateSold { get; set; }
        public String OTHRecSupplierEmail { get; set; }
    }


    public class PREPAREDRECORD
    {
        [Key]
        public int RecID { get; set; }
        public int ItemID { get; set; }
        public String RecName { get; set; }
        public int Category { get; set; }
        public Double RecSoldAmountQuantity { get; set; }
        public String RecDescription { get; set; }
        public Double RecSt_InPrice { get; set; }
        public Double RecSt_OutPrice { get; set; }
        public DateTime RecDateSold { get; set; }
        public String RecSupplierEmail { get; set; }

    }

    public class FARMPRODUCTSPREPAREDRECORD
    {
        [Key]
        public int FPRecIDPREP { get; set; }
        public int ItemIDPREP { get; set; }
        public String FPRecNamePREP { get; set; }
        public Double FPRecSoldAmountPREP { get; set; }
        public String FPRecDescriptionPREP { get; set; }
        public Double FPRecStockInPricePREP { get; set; }
        public Double FPRecStockOutPricePREP { get; set; }
        public DateTime FPRecDateSoldPREP { get; set; }
        public String FPRecSupplierEmailPREP { get; set; }
          
    }
    public class PACKEDFOODPREPAREDRECORD
    {
        [Key]
        public int PARecIDPREP { get; set; }
        public int ItemIDPREP { get; set; }
        public String PARecNamePREP { get; set; }
        public Double PARecSoldQuantityPREP { get; set; }
        public String PARecDescriptionPREP { get; set; }
        public Double PARecStockInPricePREP { get; set; }
        public Double PARecStockOutPricePREP { get; set; }
        public DateTime PARecDateSoldPREP { get; set; }
        public String PARecSupplierEmailPREP { get; set; }
    }
    public class PHARMACEUTICALSPREPAREDRECORD
    {
        [Key]
        public int PHARecIDPREP { get; set; }
        public int ItemIDPREP { get; set; }
        public String PHARecNamePREP { get; set; }
        public Double PHARecSoldQuantityPREP { get; set; }
        public String PHARecDescriptionPREP { get; set; }
        public Double PHARecStockInPricePREP { get; set; }
        public Double PHARecStockOutPricePREP { get; set; }
        public DateTime PHARecDateSoldPREP { get; set; }
        public String PHARecSupplierEmailPREP { get; set; }
    }
    public class TOOLSPREPAREDRECORD
    {
        [Key]
        public int TOOLSRecIDPREP { get; set; }
        public int ItemIDPREP { get; set; }
        public String TOOLSRecNamePREP { get; set; }
        public Double TOOLSRecSoldQuantityPREP { get; set; }
        public String TOOLSRecDescriptionPREP { get; set; }
        public Double TOOLSRecStockInPricePREP { get; set; }
        public Double TOOLSRecStockOutPricePREP { get; set; }
        public DateTime TOOLSRecDateSoldPREP { get; set; }
        public String TOOLSRecSupplierEmailPREP { get; set; }
    }
    public class OTHERSPREPAREDRECORD
    {
        [Key]
        public int OTHRecIDPREP { get; set; }
        public int ItemIDPREP { get; set; }
        public String OTHRecNamePREP { get; set; }
        public Double OTHRecSoldQuantityPREP { get; set; }
        public String OTHRecDescriptionPREP { get; set; }
        public Double OTHRecStockInPricePREP { get; set; }
        public Double OTHRecStockOutPricePREP { get; set; }
        public DateTime OTHRecDateSoldPREP { get; set; }
        public String OTHRecSupplierEmailPREP { get; set; }
    }


}
