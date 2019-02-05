using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raporty_Elektronika
{
    public class SmtData: MST.MES.OrderStructureByOrderNo.SMT
    {
        public SmtData(MST.MES.OrderStructureByOrderNo.SMT smtData) : base()
        {

        }

        public  DataTable dailyReportDataSource
        {
            get
            {
                base.

                return   new DataTable();
                
            }
        }


        
    }
}
