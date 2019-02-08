using MST.MES;
using Raporty_Elektronika.Data_Loader;
using Raporty_Elektronika.DataStructure;
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
       OrderStructureByOrderNo.dataByProcess sqlDataByProcess = new OrderStructureByOrderNo.dataByProcess();
        Dictionary<string, OrderStructureByOrderNo.dataByOrder> sqlDataByOrder = new Dictionary<string, OrderStructureByOrderNo.dataByOrder>();
        Dictionary<int, string> testerIdToName = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
            
            

        }

        public static class GlobalParameters
        {
            public static readonly int daysBackDataKitting = 90;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            testerIdToName = MST.MES.SqlDataReaderMethods.LedTest.TesterIdToName();

            Stopwatch st = new Stopwatch();
            st.Start();
            sqlDataByProcess.Smt = MST.MES.SqlDataReaderMethods.SMT.GetOrdersByDataReader(10);
            Debug.WriteLine($"smt done:{st.Elapsed}");
            st.Reset();
            sqlDataByProcess.VisualInspection = MST.MES.SqlDataReaderMethods.VisualInspection.GetViRecords(10);
            Debug.WriteLine($"vi done:{st.Elapsed}");
            st.Reset();
            sqlDataByProcess.Test = MST.MES.SqlDataReaderMethods.LedTest.GetTestRecords(10, testerIdToName);
            Debug.WriteLine($"test done:{st.Elapsed}");
            st.Reset();
            sqlDataByProcess.Rework = MST.MES.SqlDataReaderMethods.LedRework.GetReworkList
            Debug.WriteLine($"rework done:{st.Elapsed}");
            st.Reset();
            DataMerger.MergeData(ref sqlDataByOrder, null, sqlDataByProcess.Smt, sqlDataByProcess.Test, sqlDataByProcess.VisualInspection, null);
            Debug.WriteLine($"merge done:{st.Elapsed}");
            st.Reset();
            MainOrderStructure dataStructure = new MainOrderStructure(sqlDataByProcess);
            Debug.WriteLine($"struct done:{st.Elapsed}");
            st.Reset();
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
