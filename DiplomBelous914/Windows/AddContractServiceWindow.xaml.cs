using DiplomBelous914.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Shapes;
using static DiplomBelous914.HelpClass.EFClass;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddContractServiceWindow.xaml
    /// </summary>
    public partial class AddContractServiceWindow : Window
    {
        View_Contract contract1;
        public AddContractServiceWindow(View_Contract contract )
        {
            InitializeComponent();
            cmbService.ItemsSource = Context.Service.ToList();
            cmbService.SelectedIndex = 1;
            cmbService.DisplayMemberPath = "NameService";
            contract1 = contract;
            TbContract.Text = contract.NameContract;
            cmbFIOWorker.ItemsSource = Context.VW_FIO_Worker.ToList();
            cmbFIOWorker.SelectedIndex = 1;
            cmbFIOWorker.DisplayMemberPath = "FullName";

        }

       
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TbContract.Text) && !string.IsNullOrEmpty(cmbFIOWorker.Text) && !string.IsNullOrEmpty(cmbService.Text) && !string.IsNullOrEmpty(StartdatePicker.Text) ) //проверка на пустые значения
            {
                ClientContract clientContract = new ClientContract();
                clientContract.IdService = (cmbService.SelectedItem as DB.Service).IdService;
                clientContract.StartDateService = Convert.ToDateTime(StartdatePicker.Text);

                clientContract.IdWorker = (cmbFIOWorker.SelectedItem as DB.VW_FIO_Worker).IdWorker;
                clientContract.Comment = TbComment.Text;
                Context.ClientContract.Add(clientContract);
                clientContract.IdContract = contract1.IdContract;
                Context.SaveChanges();
                MessageBox.Show("Услуга добавлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Все поля со знаком * должны быть заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
