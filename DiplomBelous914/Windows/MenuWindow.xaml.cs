using DiplomBelous914.HelpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DiplomBelous914.Pages;
using DiplomBelous914.DB;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            Navigation.frame = frameName;
            Navigation.frame.Navigate(new Page());
            txtFullName.Text = HelpClass.UserClass.Worker.LastName + " " + HelpClass.UserClass.Worker.FirstName;
            if (HelpClass.UserClass.Worker.Post.IdPost == 1 /*админ*/)
            {
                BtnContract.Visibility = Visibility.Collapsed;
                BtnService.Visibility = Visibility.Collapsed;
            }
            else if (HelpClass.UserClass.Worker.Post.IdPost == 2 /*менеджер*/)
            {
                BtnWorker.Visibility = Visibility.Collapsed;
            }
            else if (HelpClass.UserClass.Worker.Post.IdPost == 3)
            {
                BtnClient.Visibility = Visibility.Collapsed;
                BtnWorker.Visibility = Visibility.Collapsed;
                BtnContract.Visibility= Visibility.Collapsed;
            }
              BtnCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            BtnOpenMenu.Visibility = Visibility.Collapsed;
            BtnCloseMenu.Visibility = Visibility.Visible;
        }
        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
           BtnOpenMenu.Visibility = Visibility.Visible;
           BtnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
           
            Navigation.frame.Navigate(new ClientPage());
        }

        private void BtnWorker_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new WorkerPage());
        }

        private void BtnContract_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new ContractPage());
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new ServicePage());
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            AutorizWindow autorizWindow = new AutorizWindow();
            autorizWindow.Show();
            this.Close();
        }
    }
}
