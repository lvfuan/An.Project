using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTest.AspNetCoreDemo.Data;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace UnitTest.AspNetCoreDemo.Controllers
{
    public class WeatherdtController : Controller
    {
        private readonly DefaultContext DB;
        private readonly static string URL="http://api.weatherdt.com/common/?area=101010100&type=forecast&key=8bbd2cdf754e62fbf6ce72382addb3c8";//请求地址
        public WeatherdtController(DefaultContext db)
        {
            this.DB = db;
        }
        public  IActionResult Index()
        {
            {
                HttpClient client = new HttpClient();
                var str = client.GetAsync("http://api.weatherdt.com/common/?area=101010100&type=forecast&key=8bbd2cdf754e62fbf6ce72382addb3c8")
                     .Result.Content.ReadAsStringAsync().Result;
            }

            {
                HttpWebRequest client = (HttpWebRequest)HttpWebRequest.Create(URL);  //建立HttpWebRequest對象
                client.Timeout = 60000;        //定義服務器超時時間
                                               //WebProxy wp = new WebProxy();       //定義一個網關對象
                                               //wp.Address = new Uri("http://wp.domain.com:3128");     //網關服務器:端口
                                               //wp.Credentials = new NetworkCredential("f3210316","6978233"); //用戶名,密碼
                                               //client.UseDefaultCredentials = true;     //啟用網關認証
                                               //client.Proxy = wp;                       //設置網關
                HttpWebResponse clients = (HttpWebResponse)client.GetResponse();   //取得回應
                Stream s = clients.GetResponseStream();                        //得到回應的流對象
                StreamReader sr = new StreamReader(s, Encoding.UTF8);       //以UTF-8編碼讀取流
                StringBuilder sb = new StringBuilder();
                while (sr.Peek() != -1)                                  //每次讀取一行,直到
                {
                    sb.Append(sr.ReadLine() + "\r\n");      //下一個字節沒有內容 返回為止
                }
            }
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            string cityName = HttpContext.Request.Form["txtCityName"];
            ServiceReference1.WeatherWebServiceSoapClient w = new ServiceReference1.WeatherWebServiceSoapClient( ServiceReference1.WeatherWebServiceSoapClient.EndpointConfiguration.WeatherWebServiceSoap12);
            string[] res = new string[23];
            res = await w.getWeatherbyCityNameAsync(cityName);
            ViewData.Model = res;
            return View();
        }
    }
}