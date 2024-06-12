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
            Entities context = new Entities();
            listviewContract.ItemsSource = context.View_Contract.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow addContractWindow = new AddContractWindow();
            addContractWindow.ShowDialog();
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            if (listviewContract.SelectedItem !=  null)
            {
                AddContractServiceWindow add = new AddContractServiceWindow(listviewContract.SelectedItem as View_Contract);
                add.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Выберете контракт, в который хотите добавить услугу", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
          
        }

      
    }
}
