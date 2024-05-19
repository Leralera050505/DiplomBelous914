using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using DiplomBelous914.HelpClass;
using System.Windows.Media.TextFormatting;
using static DiplomBelous914.HelpClass.EFClass;
using System.Security.Cryptography.X509Certificates;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
       

        public AddWorkerWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = Context.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "NameGender";
            cmbPost.ItemsSource = Context.Post.ToList();
            cmbPost.SelectedIndex = 0;
            cmbPost.DisplayMemberPath = "NamePost";
        }
        string S;
        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            if ((TbEdication != null) && (datePickerEnd != null) && (datePickerStart!= null))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    S = filePath;
                    MessageBox.Show(S);
                }
            }
            else
            {
                MessageBox.Show("Заполнена не вся дополнительная информция");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Password password = new Password();
                password.Login = TbLogin.Text;
                password.Password1 = TbPassword.Text;

                Context.Password.Add(password);
                Context.SaveChanges();
                Worker worker = new Worker();
                worker.FirstName = TbFirstName.Text;
                worker.LastName = TbLastName.Text;  
                worker.Patronymic = TbPatronymic.Text;
                worker.IdGender = (cmbGender.SelectedItem as DB.Gender).IdGender;
                worker.IdPost = (cmbPost.SelectedItem as DB.Post).IdPost;
                worker.IdPassword = Context.Password.ToList().Where(i => i.Login == password.Login).FirstOrDefault().IdPassword;

                Education education = new Education();
                education.NameEducation = TbEdication.Text;
                education.IdWorker = worker.IdWorker;
                education.StartStudy = Convert.ToDateTime(datePickerStart.Text);
                education.EndStudy = Convert.ToDateTime(datePickerEnd.Text);
                education.Diploma = S;
               
                Context.Worker.Add(worker);
                Context.Education.Add(education);
               
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
