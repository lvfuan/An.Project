using SR.Models.TModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Models.SRContext
{
    public class SRDbContext : DbContext
    {
        private static string CONTEXT_NAME = "name=SRDbContext";
        public SRDbContext() : base(CONTEXT_NAME) { Database.SetInitializer(new InitSRDataBase()); }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<LanguageTypeModel> LanguageType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuModel>().ToTable("Sys_Menu");
            modelBuilder.Entity<LanguageTypeModel>().ToTable("Sys_LanguageType");
            base.OnModelCreating(modelBuilder);
        }
    }
    public class InitSRDataBase :DropCreateDatabaseAlways<SRDbContext>
    {
        protected override void Seed(SRDbContext context)
        {
            List<MenuModel> mlist = new List<MenuModel>()
            {
               #region 一级菜单
               new MenuModel(){ Code="m001", Name="首页", PageUrl="home/index" , Level=0,UrlString="boot/m001" ,State=true  },
               new MenuModel(){ Code="m002", Name="精选博文",PageUrl="jxbw/index", Level=0,UrlString="boot/m002" ,State=true  },
               new MenuModel(){ Code="m003", Name="资源分享",PageUrl="zyfx/index", Level=0,UrlString="boot/m003" ,State=true  },
               new MenuModel(){ Code="m004", Name="求助大神",PageUrl="qzds/index", Level=0,UrlString="boot/m004" ,State=true  },
               new MenuModel(){ Code="m005", Name="今日快报",PageUrl="jrkb/index", Level=0,UrlString="boot/m005" ,State=true  },
               new MenuModel(){ Code="m006", Name="关于我们",PageUrl="gywm/index", Level=0,UrlString="boot/m006" ,State=true  }
               #endregion
            };
            //mlist.ForEach(x => context.Menu.Add(x));
            //context.SaveChanges();
            foreach (var item in mlist)
            {
                TEntitySaveDb.SaveDB(context, item);
            }
            //var mq = from k in mlist.AsParallel() select TEntitySaveDb.SaveDB(context, k);
            //mq.Max();//异步调用会产生重复主键

            List<LanguageTypeModel> lList = new List<LanguageTypeModel>()
            {
                new LanguageTypeModel(){ Code="L001", Name="C", State=true },
                new LanguageTypeModel(){ Code="L002", Name="C++", State=true },
                new LanguageTypeModel(){ Code="L003", Name="C#", State=true },
                new LanguageTypeModel(){ Code="L004", Name="Java", State=true },
                new LanguageTypeModel(){ Code="L005", Name="Python", State=true },
                new LanguageTypeModel(){ Code="L006", Name="PHP", State=true },
                new LanguageTypeModel(){ Code="L007", Name="JavaScript", State=true },
                new LanguageTypeModel(){ Code="L008", Name="Go", State=true },
                new LanguageTypeModel(){ Code="L009", Name="Swift", State=true },
                new LanguageTypeModel(){ Code="L010", Name="Objective-C", State=true }
            };
            //lList.ForEach(x => context.LanguageType.Add(x));
            //context.SaveChanges();
            foreach (var item in lList)
            {
                TEntitySaveDb.SaveDB(context, item);
            }
            //var lq = from k in lList.AsParallel() select TEntitySaveDb.SaveDB(context, k);
            //lq.Max(); //异步调用会产生重复主键
            base.Seed(context);
        }
    }

    public class TEntitySaveDb
    {
        /// <summary>
        /// 初始化保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string SaveDB<T>(SRDbContext context, T t) where T : class
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
            return string.Empty;
        }
    }
}
