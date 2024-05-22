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
                cmbGender.ItemsSource = Context.Gender.ToList();
                cmbGender.DisplayMemberPath = "NameGender";
                cmbGender.SelectedItem = Context.Gender.ToList().Where(i => i.IdGender == worker.IdGender).FirstOrDefault();

                cmbPost.ItemsSource = Context.Post.ToList();
                cmbPost.DisplayMemberPath = "NamePost";
                cmbPost.SelectedItem = Context.Post.ToList().Where(i => i.IdPost == worker.IdPost).FirstOrDefault();
                
                test = worker.IdWorker;
                test2 = worker.IdPassword;

                password = Context.Password.Where(i => i.IdPassword == test2).FirstOrDefault();
                editworker = Context.Worker.Where(i => i.IdWorker == test).FirstOrDefault();
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
            Context.SaveChanges();
            MessageBox.Show("Работник успешно изменен");
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
