using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MST.MES.SqlOperations;
using static Raporty_Elektronika.MainWindow;
using MST.MES.Data_structures;


namespace Raporty_Elektronika.Data_Loader
{
    public class KittingLoader
    {
        public static List<OrderStructure.Kitting> LoadKitting()
        {
            //Columns: Nr_Zlecenia_Produkcyjnego,NC12_wyrobu,Ilosc_wyrobu_zlecona,Data_Poczatku_Zlecenia,IloscKIT,MRM FROM tb_Zlecenia_produkcyjne
            return MST.MES.SqlOperations.Kitting.GetOrdersInfoByDataReader(GlobalParameters.daysBackDataKitting);
        }

        private static DateTime DateTimeParsing(string input)
        {
            return DateTime.Parse(input);
        }

        

    }
}
