using EmitMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestConsole;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo1 = new TestDemo1()
            {
                KID = Guid.NewGuid(),
                AutogRowID = 2676,
                DefaultImage = "",
                Del = false,
                DetailContent = "",
                HtmlDetailContent = "",
                Introduce = "",
                IsDiscount = true,
                IsHot = true,
                IsIntergral = true,
                IsNew = false,
                IsPerSale = false,
                IsSalePaking = true,
                IsShelves = false,
                IsTest = false,
                Offer_ProducrColorCode = "002",
                Offer_ProductPropertyKID = Guid.Parse("de9f1781-ad71-9927-2204-30fa18625027"),
                Offer_ProductSizeCode = "003",
                Offer_ProductsProductNo = "1000629010CN",
                Offier_ProductUnitCode = "002",
                ProductSkuName = "Diovia黄金荷荷巴油50ml",
                PublicSkuNo = "1000629010CN002003            ",
                SaleNumber = 0,
                SkuBarCode = "",
                SkuHeight = decimal.Parse("102.60"),
                SkuLength = decimal.Parse("102.60"),
                SkuMarketPrice = decimal.Parse("228.00"),
                SkuNo = "1000629010CN002003                                ",
                SkuPurchasePrice = decimal.Parse("0.00"),
                SkuWeight = decimal.Parse("102.60"),
                SkuWholeSalePrice = decimal.Parse("102.60"),
                SkuWidth = decimal.Parse("102.60"),
                State = true,
                UpDate = DateTime.Now,
                Version = 0
            };
            var demo2 = ObjectMapperManager.DefaultInstance.GetMapper<TestDemo1, TestDemo2>().Map(demo1);
            Console.WriteLine(demo1.ProductSkuName);
            Console.ReadKey();
        }
    }
}
