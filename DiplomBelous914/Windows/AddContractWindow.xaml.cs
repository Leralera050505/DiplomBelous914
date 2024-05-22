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
using System.Windows.Shapes;
using DiplomBelous914.DB;
using Microsoft.Win32;
using DiplomBelous914.HelpClass;
using System.Windows.Media.TextFormatting;
using static DiplomBelous914.HelpClass.EFClass;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        public AddContractWindow()
        {
            InitializeComponent();
            cmbService.ItemsSource = Context.Service.ToList();
            cmbService.SelectedIndex = 1;
            cmbService.DisplayMemberPath = "NameService";

            cmbFIOWorker.ItemsSource = Context.VW_FIO_Worker.ToList();
            cmbFIOWorker.SelectedIndex = 1;
            cmbFIOWorker.DisplayMemberPath = "FullName";

            cmbFIOClient.ItemsSource = Context.VW_FIO_Client.ToList();
            cmbFIOClient.SelectedIndex = 1;
            cmbFIOClient.DisplayMemberPath = "FullName";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
                Contractt contract = new Contractt();
                contract.NameContract = TbName.Text;
                if (datePicker == null )
                {
                    contract.StartDate = DateTime.Now;
                }
                else
                {
                    contract.StartDate = Convert.ToDateTime(datePicker.Text);
                }
                //Client client = new Client();
                //client = Context.Client.ToList().Where(i => i.FirstName == TbFirstName.Text 
                //|| i.LastName == TbLastName.Text
                //|| i.Patronymic == TbPatronymic.Text).FirstOrDefault();
               
                 contract.IdClient = (cmbFIOClient.SelectedItem as DB.VW_FIO_Client).IdClient;
            Context.Contractt.Add(contract);
                 ClientContract clientContract = new ClientContract();
                clientContract.IdService = (cmbService.SelectedItem as DB.Service).IdService;
                clientContract.StartDateService = Convert.ToDateTime(StartdatePicker.Text);
                //Worker worker = new Worker();
            //worker = Context.Worker.ToList().Where(i => i.FirstName == TbFirstNameW.Text
            //|| i.LastName == TbLastNameW.Text
            //|| i.Patronymic == TbPatronymicW.Text).FirstOrDefault();
             clientContract.IdWorker = (cmbFIOWorker.SelectedItem as DB.VW_FIO_Worker).IdWorker; 
            clientContract.Comment = TbComment.Text;
            Context.ClientContract.Add(clientContract);
            Context.SaveChanges();
                MessageBox.Show("Контракт Добавлен");
                this.Close();
            
        }
    }
}
