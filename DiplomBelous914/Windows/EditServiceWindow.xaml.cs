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
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        private  int test;
        View_ServiceWorker View_ServiceWorker1;
        private ClientContract editClientContract;
        public EditServiceWindow(View_ServiceWorker view_ServiceWorker)    
        {
            
            InitializeComponent();
            try
            {
                View_ServiceWorker1 = view_ServiceWorker;
                TbName.Text = view_ServiceWorker.NameService;
                TbContract.Text = view_ServiceWorker.NameContract;
                TbCost.Text = Convert.ToString( view_ServiceWorker.Cost);
                TbFullName.Text = view_ServiceWorker.FullName;
                cmbActive.ItemsSource = Context.ActivityService.ToList();
                cmbActive.DisplayMemberPath = "NameActivity";
                cmbActive.SelectedItem = Context.ActivityService.ToList().Where(i => i.IdActivityService == view_ServiceWorker.IdActivityService).FirstOrDefault();
                datePickerStart.Text = view_ServiceWorker.StartDateService.ToString();
                datePickerEnd.Text = view_ServiceWorker.EndDateService.ToString();

                test = view_ServiceWorker.IdClientContract;

                editClientContract = Context.ClientContract.Where(i => i.IdClientContract == test).FirstOrDefault();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            editClientContract.IDActivityService = (cmbActive.SelectedItem as ActivityService).IdActivityService;
            Context.SaveChanges();
            MessageBox.Show("Услуга сохранена");
            this.Close();
        }
    }
}
