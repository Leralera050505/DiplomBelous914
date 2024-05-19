using DiplomBelous914.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Microsoft.Win32;
using DiplomBelous914.HelpClass;
using System.Windows.Media.TextFormatting;
using static DiplomBelous914.HelpClass.EFClass;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWorkerWindow.xaml
    /// </summary>
    public partial class EditWorkerWindow : Window
    {
        private int test;
        private int test2;
        private Password password;
        private Worker editworker;
        public EditWorkerWindow(VW_Worker_T worker)
        {

            InitializeComponent();
            try
            {
                
                TbFirstName.Text = worker.FirstName;
                TbLastName.Text = worker.LastName;
                TbPatronymic.Text = worker.Patronymic;
                TbPassword.Text = worker.Password;
                TbLogin.Text = worker.Login;
                cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
                cmbGender.DisplayMemberPath = "NameGender";
                cmbGender.SelectedItem = EFClass.Context.Gender.ToList().Where(i => i.IdGender == worker.IdGender).FirstOrDefault();

                cmbPost.ItemsSource = EFClass.Context.Post.ToList();
                cmbPost.DisplayMemberPath = "NamePost";
                cmbPost.SelectedItem = EFClass.Context.Post.ToList().Where(i => i.IdPost == worker.IdPost).FirstOrDefault();

                test = worker.IdWorker;

                password = EFClass.Context.Password.Where(i => i.IdPassword == worker.IdPassword).FirstOrDefault();
                editworker = EFClass.Context.Worker.Where(i => i.IdWorker == test).FirstOrDefault();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            editworker.FirstName = TbFirstName.Text;
            editworker.LastName = TbLastName.Text;
            editworker.Patronymic = TbPatronymic.Text;
            editworker.IdGender = (cmbGender.SelectedItem as Gender).IdGender;
            editworker.IdPost = (cmbPost.SelectedItem as Post).IdPost;
            password.Login = TbLogin.Text;
            password.Password1 = TbPassword.Text;
            EFClass.Context.SaveChanges();
            MessageBox.Show("Работник успешно изменен");

            this.Close();
        }
    }
}
