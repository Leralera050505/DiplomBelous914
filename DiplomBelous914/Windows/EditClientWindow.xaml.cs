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
using System.Text.RegularExpressions;

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
            if (!string.IsNullOrEmpty(TbFirstName.Text) && !string.IsNullOrEmpty(TbLastName.Text) && !string.IsNullOrEmpty(TbPhone.Text) && !string.IsNullOrEmpty(TbEmail.Text)) //Проверка на пустые значения
            {
                if (TbPhone.Text == Convert.ToString(Regex.Match(TbPhone.Text, "^(?:\\+7|8|7)\\d{10}$", RegexOptions.IgnoreCase))) //Проверка формата Телефона
                {

                    if (TbFirstName.Text == Convert.ToString(Regex.Match(TbFirstName.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase))) //Проверка на Имя
                    {
                        if (TbLastName.Text == Convert.ToString(Regex.Match(TbLastName.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase)))//Проверка на Фамилию
                        {

                            if (TbPatronymic.Text == Convert.ToString(Regex.Match(TbPatronymic.Text, "^[А-ЯЁ]+[а-яё]$", RegexOptions.IgnoreCase)) || TbPatronymic.Text == null) //Проверка на Отчество
                            {

                                if (TbEmail.Text == Convert.ToString(Regex.Match(TbEmail.Text, "^[^@\\s]+@[^@\\s]+\\.(com|net|org|gov|ru)$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))) //проверка формата Эл.Почты
                                {
                                    client1.LastName = TbLastName.Text;
                                    client1.FirstName = TbFirstName.Text;
                                    client1.Patronymic = TbPatronymic.Text;
                                    client1.Email = TbEmail.Text;
                                    client1.Phone = TbPhone.Text;
                                    client1.IdGender = (cmbGender.SelectedItem as Gender).IdGender;
                                    Context.SaveChanges();
                                    MessageBox.Show("Клиент успешно сохранен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный формат электронной почты", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                                    return;
                                }
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
                    MessageBox.Show("Неверно введен телефон", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Все поля со знаком * должны быть заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
