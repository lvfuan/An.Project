using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest.AspNetCoreDemo.Models
{
    public class WeatherModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 风力
        /// </summary>
        public string WindPower { get; set; }
        public string Content { get; set; }

    }
}
