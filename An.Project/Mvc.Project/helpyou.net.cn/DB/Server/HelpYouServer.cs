using helpyou.net.cn.DB.Interface;
using System.Configuration;
using System.Data.SqlClient;

namespace helpyou.net.cn.DB.Server
{
    public class HelpYouServe<T> : IHelpYou<T> where T : class, new()
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private readonly static string sqlConnectionString = ConfigurationManager.ConnectionStrings["HelpYouDbContext"].ToString();
        /// <summary>
        /// 获取Sql Server的连接数据库对象。
        /// </summary>
        /// <returns></returns>
        public SqlConnection openSqlConnection { get { SqlConnection sqlConnection = new SqlConnection(sqlConnectionString); sqlConnection.Open(); return sqlConnection; } }
        ~HelpYouServe()
        {
            this.openSqlConnection.Close();
        }
    }
}
