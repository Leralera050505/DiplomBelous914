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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        List<Client> clients = new List<Client>();
        List<string> sortlist = new List<string>()
        {
            "По имени",
            "По фамилии",
            "По отчеству",
            "По телефону",
            "По Email",
        };

        public ClientPage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortlist;
            CmbSort.SelectedIndex = 0;
            GetListClient();
            listviewClient.ItemsSource = Context.Client.ToList();
        }
        private void GetListClient()
        {
            clients = Context.Client.ToList();
            clients = clients.
                Where(i => i.FirstName.Contains(TxbSearch.Text)
                || i.LastName.Contains(TxbSearch.Text)
                || i.Patronymic.Contains(TxbSearch.Text)
                || i.Phone.Contains(TxbSearch.Text)
                || i.Email.Contains(TxbSearch.Text)
                ).ToList();

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    clients = clients.OrderBy(i => i.FirstName).ToList();
                    break;

                case 1:
                    clients = clients.OrderBy(i => i.LastName).ToList();
                    break;

                case 2:
                    clients = clients.OrderBy(i => i.Patronymic).ToList();
                    break;

                case 3:
                    clients = clients.OrderBy(i => i.Phone).ToList();
                    break;
                case 4:
                    clients = clients.OrderBy(i => i.Email).ToList();
                    break;
                default:
                    break;
            }
            listviewClient.ItemsSource = clients;
        }


        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListClient();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListClient();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить клиента", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    Client client = listviewClient.SelectedItem as Client;
                    Context.Client.Remove(client);
                    Context.SaveChanges();
                    listviewClient.ItemsSource = Context.Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            EditClientWindow editClientWindow = new EditClientWindow(listviewClient.SelectedItem as Client);
            editClientWindow.ShowDialog();
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            listviewClient.ItemsSource = Context.Client.ToList();
        }
    }
}
