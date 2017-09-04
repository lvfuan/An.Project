using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helper.Common;
using System.Data;

namespace UnitTest.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("t1");
            dt.Columns.Add("t2");
            dt.Columns.Add("t3");
            dt.Columns.Add("t4");
            dt.Columns.Add("t5");
            Console.ReadKey();
        }
    }
    public class Project
    {
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
