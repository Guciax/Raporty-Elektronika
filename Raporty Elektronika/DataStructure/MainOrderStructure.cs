using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raporty_Elektronika.DataStructure
{
    public class MainOrderStructure: MST.MES.OrderStructureByOrderNo.AllOrdersByProcess
    {
        public MainOrderStructure(MST.MES.OrderStructureByOrderNo.AllOrdersByProcess sqlObject) : base()
        {

        }


        public static class SmtTab
        {
            public static bool checkBoxMst;
            public static bool checkBoxLg;

        }

        public DataTable sourceForDailyReport
        {
            get
            {
                var filteredList = base.Smt.Select(o => o.Value);

                if (!SmtTab.checkBoxLg)
                {
                    filteredList = filteredList.Where(o => o.clientGroup != "LG");
                }
                if (!SmtTab.checkBoxMst)
                {
                    filteredList = filteredList.Where(o => o.clientGroup != "MST");
                }

                var result = new DataTable();

                Dictionary<DateTime, List<MST.MES.OrderStructureByOrderNo.SmtRecords>> dictByDay = filteredList.SelectMany(o=>o.smtOrders).GroupBy(o => o.smtEndDate.Date).ToDictionary(x => x.Key, x => x.ToList());
                

                return result;
            }
        }
        
    }
    
}
