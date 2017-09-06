using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helper.Common;
using System.Data;
using System.Threading;

namespace UnitTest.Consoles
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                Action act = () => { Project.Get("结束");/*异步任务*/ };
                act.BeginInvoke((x)=> { Project.Show(); }/*异步任务结束执行的任务*/,null/*返回值*/);
                Console.WriteLine("线程2");//异步不会阻塞
            }

            {
                //DataTable dt = new DataTable();
                //dt.Columns.Add("t1");
                //dt.Columns.Add("t2");
                //dt.Columns.Add("t3");
                //dt.Columns.Add("t4");
                //dt.Columns.Add("t5");
            }
            Console.ReadKey();
        }
    }
    public class Project
    {
        public static void Get(object num)
        {
            Console.WriteLine("开始");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine(num);
        }
        public static void Show()
        {
            Console.WriteLine("Hello World");
        }
        public string Project_Name { get; set; }
        public string Project_Code { get; set; }
        public string Stimulus_Type_code { get; set; }
        public string Stimulus_Dose { get; set; }
        public string Threshold_Code { get; set; }
        public string Stimulus_Strength { get; set; }
        public string Stimulus_Frequency { get; set; }
        public string Stimulus_Time { get; set; }
        public string Intermission_Time { get; set; }
        public string Total_Pulse { get; set; }
        public string Total_Time { get; set; }
        public string Subject_Desc { get; set; }
        public string Disease_Desc { get; set; }
        public string Project_Explain { get; set; }
        public string Stimulus_Position { get; set; }
        public string Treatment_Explain { get; set; }
        public string Range_Explain { get; set; }
        public string Operation_Explain { get; set; }
        public string Reference { get; set; }
    }
}
