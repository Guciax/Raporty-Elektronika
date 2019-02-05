using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raporty_Elektronika.Tools
{
    public class DateTools
    {
        public static int DateToShiftrNumber(DateTime date)
        {
            if (date.Hour < 6) return 3;
            if (date.Hour < 14) return 1;
            if (date.Hour < 22) return 2;
            return 3;
        }
    }
}
