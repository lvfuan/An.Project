using System;
using System.Collections.Generic;

namespace UnitTest.MvcPager.Models
{
    public class InitPagerDate
    {
        private List<PagerDemo> _list=new List<PagerDemo>();
        public InitPagerDate()
        {
            for (int i = 1; i <= 1000; i++)
            {
                _list.Add(new PagerDemo()
                {
                    Id = i,
                    Title = "我是分页Demo标题" + i,
                    Content = "我是分页Demo数据"+ i,
                    CreateTime = DateTime.Now,
                    CreateUser = "admin"
                });
            }
        }
        public List<PagerDemo> GetPagerDate
        {
            get { return _list; }
        }
    }
}