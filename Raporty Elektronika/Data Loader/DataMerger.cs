using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MST.MES.SqlOperations;
using static Raporty_Elektronika.MainWindow;
using MST.MES.Data_structures;
using MST.MES;
using static MST.MES.OrderStructureByOrderNo;

namespace Raporty_Elektronika.Data_Loader
{
    public class DataMerger
    {
        public static void MergeData(ref Dictionary<string, OrderStructureByOrderNo.dataByOrder> inputDict, 
            Dictionary<string, OrderStructureByOrderNo.Kitting> kitting =null, 
            Dictionary<string, OrderStructureByOrderNo.SMT> smt =null,
            Dictionary<string, TestInfo> test=null,
            Dictionary<string, OrderStructureByOrderNo.VisualInspection> vi =null,
            Dictionary<string, ReworkInfo> rework=null)
        {
            if (kitting!=null)
            {
                foreach (var kittingEntry in kitting)
                {
                    if (!inputDict.ContainsKey(kittingEntry.Key))
                    {
                        inputDict.Add(kittingEntry.Key, new dataByOrder());
                    }
                    if (inputDict[kittingEntry.Key].kitting != null) continue;

                    inputDict[kittingEntry.Key].kitting = kittingEntry.Value;
                }
            }

            if (smt!=null)
            {
                foreach (var smtEntry in smt)
                {
                    if (!inputDict.ContainsKey(smtEntry.Key))
                    {
                        inputDict.Add(smtEntry.Key, new dataByOrder());
                    }
                    if (inputDict[smtEntry.Key].smt != null) continue;

                    inputDict[smtEntry.Key].smt = smtEntry.Value;
                }
            }

            if (test != null)
            {
                foreach (var testEntry in test)
                {
                    if (!inputDict.ContainsKey(testEntry.Key))
                    {
                        inputDict.Add(testEntry.Key, new dataByOrder());
                    }
                    if (inputDict[testEntry.Key].test != null) continue;

                    inputDict[testEntry.Key].test = testEntry.Value;
                }
            }

            if (vi != null)
            {
                foreach (var viEntry in vi)
                {
                    if (!inputDict.ContainsKey(viEntry.Key))
                    {
                        inputDict.Add(viEntry.Key, new dataByOrder());
                    }
                    if (inputDict[viEntry.Key].visualInspection != null) continue;

                    inputDict[viEntry.Key].visualInspection = viEntry.Value;
                }
            }

            if (rework != null)
            {
                foreach (var reworkEntry in rework)
                {
                    if (!inputDict.ContainsKey(reworkEntry.Key))
                    {
                        inputDict.Add(reworkEntry.Key, new dataByOrder());
                    }
                    if (inputDict[reworkEntry.Key].rework != null) continue;

                    inputDict[reworkEntry.Key].rework = reworkEntry.Value;
                }
            }
        }



    }
}
