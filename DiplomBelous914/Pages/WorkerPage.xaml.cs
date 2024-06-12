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
using DiplomBelous914.HelpClass;

namespace DiplomBelous914.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        
        List<VW_Worker_T> workers = new List<VW_Worker_T>();
        List<string> sortlist = new List<string>()
        {
            "По имени",
            "По фамилии",
            "По отчеству",
            "По должности"
        };
        
        public WorkerPage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortlist;
            CmbSort.SelectedIndex = 0;
            GetListWorker();
            listviewWorker.ItemsSource = Context.VW_Worker_T.ToList();
        }

        private void GetListWorker()
        {
            workers = Context.VW_Worker_T.ToList(); 
            workers = workers.
                Where(i => i.LastName.Contains(TxbSearch.Text)
                || i.FirstName.Contains(TxbSearch.Text)
                || i.Patronymic.Contains(TxbSearch.Text)
                || i.Login.Contains(TxbSearch.Text)
                || i.Password.Contains(TxbSearch.Text)
                || i.NamePost.Contains(TxbSearch.Text)
                || i.StartStudy.Equals(TxbSearch.Text)
                || i.EndStudy.Equals(TxbSearch.Text)
                || i.NameEducation.Contains(TxbSearch.Text)
                || i.Diploma.Contains(TxbSearch.Text)
                || i.NameGender.Contains(TxbSearch.Text)
                ).ToList();
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    workers = workers.OrderBy(i => i.FirstName).ToList();
                    break;

                case 1:
                    workers = workers.OrderBy(i => i.LastName).ToList();
                    break;

                case 2:
                    workers = workers.OrderBy(i => i.Patronymic).ToList();
                    break;
                case 3:
                    workers = workers.OrderBy(i => i.NamePost).ToList();
                    break;
                case 4:
                    workers = workers.OrderBy(i => i.StartStudy).ToList();
                    break;
                case 5:
                    workers = workers.OrderBy(i => i.EndStudy).ToList();
                    break;
                case 6:
                    workers = workers.OrderBy(i => i.NameEducation).ToList();
                    break;
                case 7:
                    workers = workers.OrderBy(i => i.Diploma).ToList();
                    break;
                case 8:
                    workers = workers.OrderBy(i => i.NameGender).ToList();
                    break;
                case 9:
                    workers = workers.OrderBy(i => i.Login).ToList();
                    break;
                case 10:
                    workers = workers.OrderBy(i => i.Password).ToList();
                    break;
                default:
                    break;
            }
            listviewWorker.ItemsSource = workers;
        }
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListWorker();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListWorker();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            addWorkerWindow.ShowDialog();
        }
        private void btnUpdate_Click_2(object sender, RoutedEventArgs e)
        {
            Entities con2 = new Entities();
            listviewWorker.ItemsSource = con2.VW_Worker_T.ToList();
        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewWorker.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить работника", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    if (listviewWorker.SelectedItem != null)
                    {
                        VW_Worker_T worker = listviewWorker.SelectedItem as VW_Worker_T;

                        Password password = Context.Password.ToList().Where(i => i.IdPassword == worker.IdPassword).FirstOrDefault();
                        Context.Password.Remove(password);
                        Context.SaveChanges();
                        Worker worker1 = Context.Worker.ToList().Where(i => i.IdWorker == worker.IdWorker).FirstOrDefault();
                        Context.Worker.Remove(worker1);
                        Context.SaveChanges();
                        Education education = Context.Education.ToList().Where(i => i.IdWorker == worker.IdWorker).FirstOrDefault();
                        Context.Education.Remove(education);
                        Context.SaveChanges();
                        listviewWorker.ItemsSource = Context.VW_Worker_T.ToList();
                    }


                }
            }
            else
            {
                MessageBox.Show("Выделите запись, которую хотите удалить","Ошибка", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }
        }

  

        private void btnEditWorker_Click(object sender, RoutedEventArgs e)
        {
            if (listviewWorker.SelectedItem != null)
            {
                EditWorkerWindow editWorkerWindow = new EditWorkerWindow(listviewWorker.SelectedItem as VW_Worker_T);
                editWorkerWindow.Show();
            }
            else 
            {
                MessageBox.Show("Выберите работника, которого хотите изменить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Question);
            }
          

        }

      
    }
}
