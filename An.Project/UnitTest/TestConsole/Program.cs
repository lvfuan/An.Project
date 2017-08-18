using EmitMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using System.Reflection;
using log4net;
using System.IO;
using System.Web;
using System.Data;

namespace TestConsole
{
    class Program
    {
        //private static log4net.ILog myLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            //var s =new DataSet().ReadXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            ILog log = LogHelper.GetInstance();
            log.Fatal("Fatal");
            #region 
            //var demo1 = new TestDemo1()
            //{
            //    KID = Guid.NewGuid(),
            //    AutogRowID = 2676,
            //    DefaultImage = "",
            //    Del = false,
            //    DetailContent = "",
            //    HtmlDetailContent = "",
            //    Introduce = "",
            //    IsDiscount = true,
            //    IsHot = true,
            //    IsIntergral = true,
            //    IsNew = false,
            //    IsPerSale = false,
            //    IsSalePaking = true,
            //    IsShelves = false,
            //    IsTest = false,
            //    Offer_ProducrColorCode = "002",
            //    Offer_ProductPropertyKID = Guid.Parse("de9f1781-ad71-9927-2204-30fa18625027"),
            //    Offer_ProductSizeCode = "003",
            //    Offer_ProductsProductNo = "1000629010CN",
            //    Offier_ProductUnitCode = "002",
            //    ProductSkuName = "Diovia黄金荷荷巴油50ml",
            //    PublicSkuNo = "1000629010CN002003            ",
            //    SaleNumber = 0,
            //    SkuBarCode = "",
            //    SkuHeight = decimal.Parse("102.60"),
            //    SkuLength = decimal.Parse("102.60"),
            //    SkuMarketPrice = decimal.Parse("228.00"),
            //    SkuNo = "1000629010CN002003                                ",
            //    SkuPurchasePrice = decimal.Parse("0.00"),
            //    SkuWeight = decimal.Parse("102.60"),
            //    SkuWholeSalePrice = decimal.Parse("102.60"),
            //    SkuWidth = decimal.Parse("102.60"),
            //    State = true,
            //    UpDate = DateTime.Now,
            //    Version = 0
            //};
            //var demo2 = ObjectMapperManager.DefaultInstance.GetMapper<TestDemo1, TestDemo2>().Map(demo1);
            //Console.WriteLine(demo1.ProductSkuName);
            #endregion
            Console.ReadKey();
        }
    }
    public class LogHelper
    {
        /// <summary>
        /// 日志辅助类
        /// </summary>
        private static ILog log;
        private static LogHelper logHelper = null;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ILog GetInstance()
        {
            logHelper = new LogHelper(null);

            return log;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static ILog GetInstance(string configPath)
        {
            logHelper = new LogHelper(configPath);

            return log;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configPath"></param>
        private LogHelper(string configPath)
        {
            if (!string.IsNullOrEmpty(configPath))
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configPath));
            }
            else
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }
    }
}
