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
using static DiplomBelous914.HelpClass.EFClass;
using DiplomBelous914.Windows;
using System.Collections;
using System.Data.Entity;

namespace DiplomBelous914.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        View_ServiceWorker View_ServiceWorker1;
        List<View_ServiceWorker> services = new List<View_ServiceWorker>();
        List<string> sortlist = new List<string>()
        {
            "По названию",
            "По цене",
            "По работнику",
            "По активности",
            "По дате создания",
            "По дате окнчания"
        };
        public ServicePage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortlist;
            CmbSort.SelectedIndex = 0;
            GetListService();
            if (HelpClass.UserClass.Worker.Post.IdPost == 3 /*Юрист*/)
            {
                listviewService.ItemsSource = Context.View_ServiceWorker.ToList().Where(i => i.IdWorker == HelpClass.UserClass.Worker.IdWorker);
            }
            else if (HelpClass.UserClass.Worker.Post.IdPost == 2 /*Менеджер*/ )
            {
                listviewService.ItemsSource = Context.View_ServiceWorker.ToList();
            }
            
        }
        

        private void GetListService()
        {
            services = Context.View_ServiceWorker.ToList();
            services = services.
                Where(i => i.NameContract.Contains(TxbSearch.Text)
                || i.Cost.Equals(TxbSearch.Text)
                || i.FullName.Contains(TxbSearch.Text)
                || i.NameActivity.Contains(TxbSearch.Text)
                || i.EndDateService.Equals(TxbSearch.Text)
                || i.StartDateService.Equals(TxbSearch.Text)
                ).ToList();

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(i => i.NameContract).ToList();
                    break;

                case 1:
                    services = services.OrderBy(i => i.Cost).ToList();
                    break;

                case 2:
                    services = services.OrderBy(i => i.FullName).ToList();
                    break;

                case 3:
                    services = services.OrderBy(i => i.NameActivity).ToList();
                    break;
                case 4:
                    services = services.OrderBy(i => i.EndDateService).ToList();
                    break;
                case 5:
                    services = services.OrderBy(i => i.StartDateService).ToList();
                    break;
                default:
                    break;
            }
            listviewService.ItemsSource = services;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListService();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListService();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (HelpClass.UserClass.Worker.Post.IdPost == 3 /*Юрист*/)
            {
                listviewService.ItemsSource = Context.View_ServiceWorker.ToList().Where(i => i.IdWorker == HelpClass.UserClass.Worker.IdWorker);
            }
            else if (HelpClass.UserClass.Worker.Post.IdPost == 2 /*Менеджер*/ )
            {
                listviewService.ItemsSource = Context.View_ServiceWorker.ToList();
            }

        }

        private void btnEditStatus_Click(object sender, RoutedEventArgs e)
        {
            EditServiceWindow editServiceWindow = new EditServiceWindow(listviewService.SelectedItem as View_ServiceWorker);
            editServiceWindow.ShowDialog();
            
        }
    }
}
