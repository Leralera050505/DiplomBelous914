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
using System.Windows.Shapes;
using Microsoft.Win32;
using DiplomBelous914.HelpClass;
using System.Windows.Media.TextFormatting;
using static DiplomBelous914.HelpClass.EFClass;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        Client client1;
        public EditClientWindow(Client client)
        {
            
            InitializeComponent();
            try
            {
                client1 = client;
                TbFirstName.Text = client1.FirstName;
                TbLastName.Text = client1.LastName;
                TbPatronymic.Text = client1.Patronymic;
                TbEmail.Text = client1.Email;
                TbPhone.Text = client1.Phone;
                cmbGender.ItemsSource = Context.Gender.ToList();
                cmbGender.DisplayMemberPath = "NameGender";
                cmbGender.SelectedItem = Context.Gender.ToList().Where(i => i.IdGender == client.IdGender).FirstOrDefault();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            client1.LastName = TbLastName.Text;
            client1.FirstName = TbFirstName.Text;
            client1.Patronymic = TbPatronymic.Text;
            client1.Email = TbEmail.Text;
            client1.Phone = TbPhone.Text;
            client1.IdGender = (cmbGender.SelectedItem as Gender).IdGender;
            Context.SaveChanges();
            MessageBox.Show("Клиент успешно сохранен!");

            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
