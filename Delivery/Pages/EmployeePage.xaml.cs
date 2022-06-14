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

namespace Delivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        List<EF.Employee> employees = new List<EF.Employee>();

        List<string> sortList = new List<string>() 
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По логину",
            "По должности"
        };
        public EmployeePage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetListEmployee();
        }

        private void GetListEmployee()
        {
            employees = ClassHelper.AppData.context.Employee.ToList();

            // поиск

            employees = employees.
                Where(i => i.LastName.Contains(TxbSearch.Text) 
                || i.FirstName.Contains(TxbSearch.Text)
                || i.Login.Contains(TxbSearch.Text)
                ).ToList();

            // сортировка

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    employees = employees.OrderBy(i => i.ID).ToList();
                    break;

                    case 1: employees = employees.OrderBy(i => i.LastName).ToList();
                    break;

                case 2: employees = employees.OrderBy(i => i.FirstName).ToList();
                    break;

                case 3: employees = employees.OrderBy(i => i.Login).ToList();
                    break;

                case 4:
                    employees = employees.OrderBy(i => i.IDRole).ToList();
                    break;
                default:
                    break;
            }


            DgEmployee.ItemsSource = employees;
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.frame.Navigate(new Pages.AddEditEmployeePage());
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (DgEmployee.SelectedItem is EF.Employee)
            {
                var item = DgEmployee.SelectedItem as EF.Employee;

                ClassHelper.AppData.context.Employee.Remove(item);
                ClassHelper.AppData.context.SaveChanges();
                GetListEmployee();
                MessageBox.Show("Пользователь удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }      
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {

            if (DgEmployee.SelectedItem is EF.Employee)
            {
                var employee = DgEmployee.SelectedItem as EF.Employee;
                ClassHelper.NavigateClass.frame.Navigate(new Pages.AddEditEmployeePage(employee));

            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListEmployee();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListEmployee();
        }
    }
}
