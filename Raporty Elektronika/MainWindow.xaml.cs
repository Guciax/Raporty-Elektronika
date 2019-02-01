using MST.MES;
using Raporty_Elektronika.Data_Loader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Raporty_Elektronika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    


    public partial class MainWindow : Window
    {
        Dictionary<string, OrderStructureByOrderNo> dataStructoreByOrder = new Dictionary<string, OrderStructureByOrderNo>();

        public MainWindow()
        {
            InitializeComponent();
           
        }

        public static class GlobalParameters
        {
            public static int daysBackDataKitting = 90;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dPVIWasteLevelFrom.DisplayDate = DateTime.Now.AddDays(-30);
            dPVIWasteLevelTo.DisplayDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var smt = MST.MES.SqlDataReaderMethods.SMT.GetOrdersByDataReader(90);
            var testIdToName = MST.MES.SqlDataReaderMethods.LedTest.TesterIdToName();
            var test = MST.MES.SqlDataReaderMethods.LedTest.GetTestRecords(60, testIdToName);
            ;
        }
    }
}
