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
       OrderStructureByOrderNo.AllOrdersByProcess sqlDataStructoreByOrder = new OrderStructureByOrderNo.AllOrdersByProcess();

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
            sqlDataStructoreByOrder.Smt = MST.MES.SqlDataReaderMethods.SMT.GetOrdersByDataReader(90);
            sqlDataStructoreByOrder.VisualInspection = MST.MES.SqlDataReaderMethods.VisualInspection.GetViRecords(90);
            MainOrderStructure dataStructure = new MainOrderStructure(sqlDataStructoreByOrder);
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
