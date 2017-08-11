using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestConsole
{
     public class TestDemo2
    {
        public TestDemo2()
        {
            Del = false;
            State = true;
            IsDiscount = false;
            IsIntergral = false;
            IsSalePaking = false;
            IsShelves = false;
            DefaultImage = "#";
        }   
        public Guid KID { get; set; }
        public string SkuNo { get; set; }
        public string PublicSkuNo { get; set; }
        public string Offer_ProductsProductNo { get; set; }
        public string Offer_ProducrColorCode { get; set; }
        public string Offer_ProductSizeCode { get; set; }
        public string Offier_ProductUnitCode { get; set; }
        public string SkuBarCode { get; set; }
        public decimal SkuWeight { get; set; }
        public decimal SkuLength { get; set; }
        public decimal SkuWidth { get; set; }
        public decimal SkuHeight { get; set; }
        public decimal SkuMarketPrice { get; set; }
        public decimal SkuWholeSalePrice { get; set; }
        public decimal SkuPurchasePrice { get; set; }
        public bool IsSalePaking { get; set; }
        public string StrIsSalePaking { get { return IsSalePaking == true ? "是" : "否"; } }
        public bool IsIntergral { get; set; }
        public string StrIsIntergral { get { return IsSalePaking == true ? "是" : "否"; } }
        public bool Del { get; set; }
        public bool State { get; set; }
        public string StrState { get { return State == true ? "是" : "否"; } }
        public int Version { get; set; }
        public bool IsNew { get; set; }
        public string StrIsNew { get { return IsNew == true ? "是" : "否"; } }
        public bool IsTest { get; set; }
        public bool IsHot { get; set; }
        public string StrIsHot { get { return IsHot == true ? "是" : "否"; } }
        public string DefaultImage { get; set; }
        public string ProductSkuName { get; set; }
        public DateTime UpDate { get; set; }
        public int SaleNumber { get; set; }
        public bool IsDiscount { get; set; }
        public string StrIsDiscount { get { return IsDiscount == true ? "是" : "否"; } }
        public int AutogRowID { get; set; }
        public bool IsShelves { get; set; }
        public string StrIsShelves { get { return IsShelves == true ? "是" : "否"; } }
        public bool IsPerSale { get; set; }
        public string StrIsPerSale { get { return IsPerSale == true ? "是" : "否"; } }
        public Guid Offer_ProductPropertyKID { get; set; }
        public string HtmlDetailContent { get; set; }
        public string DetailContent { get; set; }
        public String Introduce { get; set; }
    }
}
