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
        public EmployeePage()
        {
            InitializeComponent();
            GetListEmployee();
        }

        private void GetListEmployee()
        {
            employees = ClassHelper.AppData.context.Employee.ToList();

            // издевательства над списком сотрудников

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
    }
}
