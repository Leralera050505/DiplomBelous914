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
using System.Text.RegularExpressions;

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
                }
            }
            else
            {
                MessageBox.Show("Заполнена не вся дополнительная информция", "Не успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TbFirstName.Text) && !string.IsNullOrEmpty(TbLastName.Text) && !string.IsNullOrEmpty(TbPassword.Text) && !string.IsNullOrEmpty(TbLogin.Text)) //Проверка на пустые значения
                {
                    if (TbFirstName.Text == Convert.ToString(Regex.Match(TbFirstName.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase))) //Проверка на Имя
                    {
                        if (TbLastName.Text == Convert.ToString(Regex.Match(TbLastName.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase)))//Проверка на Фамилию
                        {

                            if (TbPatronymic.Text == Convert.ToString(Regex.Match(TbPatronymic.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase)) || TbPatronymic.Text == null) //Проверка на Отчество
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
                                MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Отчество  введено не корректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Фамилия введено не корректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Имя введено не корректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Все поля со знаком * должны быть заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
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
