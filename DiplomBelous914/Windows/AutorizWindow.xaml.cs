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
using static DiplomBelous914.HelpClass.EFClass;

namespace DiplomBelous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizWindow.xaml
    /// </summary>
    public partial class AutorizWindow : Window
    {
        public AutorizWindow()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show(" Пароль не может быть пустым");
            }
            else
            {
                try
                {
                    var auth = Context.Password.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password1 == TbPassword.Text).FirstOrDefault();
                    var Worker = Context.Worker.ToList().Where(i => i.Password.Login == TbLogin.Text).FirstOrDefault();
                    if (Worker != null)
                    {
                        HelpClass.UserClass.Worker = Worker;
                        MenuWindow menuWindow = new MenuWindow();
                        menuWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
