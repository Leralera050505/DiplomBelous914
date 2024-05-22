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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = Context.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "NameGender";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((TbFirstName != null) && (TbLastName != null) && (TbPhone != null) && (TbEmail != null))
                {
                    Client client = new Client();

                    client.LastName = TbLastName.Text;
                    client.FirstName = TbFirstName.Text;
                    client.Email = TbEmail.Text;
                    client.Phone = TbPhone.Text;
                    client.Patronymic = TbPatronymic.Text;
                    client.IdGender = (cmbGender.SelectedItem as DB.Gender).IdGender;
                    Context.Client.Add(client);
                    Context.SaveChanges();
                    MessageBox.Show("Добавление прошло успешно");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}