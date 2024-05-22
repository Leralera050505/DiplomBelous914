using DiplomBelous914.DB;
using System;
using System.Collections.Generic;
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
using System.Xml;
using static DiplomBelous914.HelpClass.EFClass;
using DiplomBelous914.Windows;
using System.Collections;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;

namespace DiplomBelous914.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        List<View_Contract> contracts = new List<View_Contract>();
        List<string> sortlist = new List<string>()
        {
            "По названию",
            "По дате",
            "По цене",
            "По клиенту",

        };
        public ContractPage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortlist;
            CmbSort.SelectedIndex = 0;
            GetListContract();
            listviewContract.ItemsSource = Context.View_Contract.ToList();
        }

        private void GetListContract()
        {
            contracts = Context.View_Contract.ToList();
            contracts = contracts.
                Where(i => i.NameContract.Contains(TxbSearch.Text)
                || i.StartDate.Equals(TxbSearch.Text)
                || i.FullCost.Equals(TxbSearch.Text)
                || i.Activity.Equals(TxbSearch.Text)
                || i.Client.Equals(TxbSearch.Text)
                ).ToList();
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    contracts = contracts.OrderBy(i => i.NameContract).ToList();
                    break;

                case 1:
                    contracts = contracts.OrderBy(i => i.StartDate).ToList();
                    break;

                case 2:
                    contracts = contracts.OrderBy(i => i.FullCost).ToList();
                    break;

                case 3:
                    contracts = contracts.OrderBy(i => i.Activity).ToList();
                    break;
                case 4:
                    contracts = contracts.OrderBy(i => i.Client).ToList();
                    break;
                default:
                    break;
            }
            listviewContract.ItemsSource = contracts;
        }
        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListContract();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListContract();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            listviewContract.ItemsSource = Context.View_Contract1.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow addContractWindow = new AddContractWindow();
            addContractWindow.ShowDialog();
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddContractServiceWindow add = new AddContractServiceWindow(listviewContract.SelectedItem as View_Contract);
            add.ShowDialog();
        }

       

        //private void btnDeleteContract_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить работника", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //    if (result == MessageBoxResult.Yes)
        //    {

        //        if (listviewContract.SelectedItem != null)
        //        {
        //            View_Contract Vcontract = listviewContract.SelectedItem as View_Contract;

                   
                      
                    
        //            Contractt contract = Context.Contractt.ToList().Where(i => i.IdContract == Vcontract.IdContract).FirstOrDefault();
        //            Context.Contractt.Remove(contract);
        //            Context.SaveChanges();
        //            ClientContract clientContract = Context.ClientContract.ToList().Where(i => i.IdContract == Vcontract.IdContract).FirstOrDefault();
        //            Context.ClientContract.Remove(clientContract);
        //            Context.SaveChanges();
        //            MessageBox.Show("Контракт удален");

        //            listviewContract.ItemsSource = Context.View_Contract.ToList();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Выделите запись, которую хотите удалить");
        //            return;
        //        }
        //    }
        //}
    }
}
