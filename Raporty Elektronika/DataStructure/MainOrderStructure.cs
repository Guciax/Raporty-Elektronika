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

        

        public DataTable sourceForDailyReport
        {
            get
            {

                var result = new DataTable();

                Dictionary<DateTime, List<MST.MES.OrderStructureByOrderNo.SmtRecords>> dictByDay = base.Smt.SelectMany(o => o.Value.smtOrders).GroupBy(o => o.smtEndDate.Date).ToDictionary(x => x.Key, x => x.ToList());



                return result;
            }
        }

    }
    
}
