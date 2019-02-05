using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MST.MES;
using Raporty_Elektronika.Tools;

namespace Raporty_Elektronika.DataStructure
{
    public class MainOrderStructure: MST.MES.OrderStructureByOrderNo.AllOrdersByProcess
    {
        private readonly OrderStructureByOrderNo.AllOrdersByProcess _sqlObject;

        public MainOrderStructure(MST.MES.OrderStructureByOrderNo.AllOrdersByProcess sqlObject) : base()
        {
            _sqlObject = sqlObject;
        }


        public static class SmtTab
        {
            public static bool checkBoxMst;
            public static bool checkBoxLg;

        }

        public DataTable SourceForDailyReport
        {
            get
            {
                var result = new DataTable();
                result.Columns.Add("Mies");
                result.Columns.Add("Tydz");
                result.Columns.Add("Dzien");
                result.Columns.Add("Zmiana");
                var filteredList = _sqlObject.Smt.Select(o => o.Value);

                if (!SmtTab.checkBoxLg) {
                    filteredList = filteredList.Where(o => o.clientGroup != "LG");
                }
                if (!SmtTab.checkBoxMst) {
                    filteredList = filteredList.Where(o => o.clientGroup != "MST");
                }

                

                Dictionary<DateTime, List<MST.MES.OrderStructureByOrderNo.SmtRecords>> dictByDay = filteredList.SelectMany(o=>o.smtOrders).GroupBy(o => o.smtEndDate.Date).ToDictionary(x => x.Key, x => x.ToList());
                var smtLines = filteredList.SelectMany(smt => smt.smtOrders).Select(records => records.smtLine)
                    .Distinct();
                foreach (var smtLine in smtLines) {
                    result.Columns.Add(smtLine);
                }

                foreach (var dayEntry in dictByDay) {
                    var shiftsList = dayEntry.Value.GroupBy(day => DateTools.DateToShiftrNumber(day.smtEndDate))
                        .ToDictionary(x => x.Key, x => x.ToList());
                    foreach (var shiftEntry in shiftsList) {
                        var linesList = shiftEntry.Value.GroupBy(line => line.smtLine)
                            .ToDictionary(x => x.Key, x => x.ToList());
                        var newRow = result.NewRow();
                        newRow["Mies"] = dayEntry.Key.Month;
                        newRow["Tydz"] = dayEntry.Key.DayOfWeek;
                        newRow["Dzien"] = dayEntry.Key.Day;
                        newRow["Zmiana"] = shiftEntry.Key;
                        foreach (var lineEntry in linesList) {
                            newRow[lineEntry.Key] = lineEntry.Value.Select(q => q.manufacturedQty).Sum();
                        }

                        result.Rows.Add(newRow);
                    }
                }

                return result;
            }
        }
        
    }
    
}
