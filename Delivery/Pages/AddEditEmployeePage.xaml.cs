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
    /// Логика взаимодействия для AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {
        public AddEditEmployeePage()
        {
            InitializeComponent();

            CmbRole.ItemsSource = ClassHelper.AppData.context.Role.ToList();
            CmbRole.DisplayMemberPath = "NameRole";
            CmbRole.SelectedIndex = 0;
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EF.Employee employee = new EF.Employee();
            employee.LastName = TxbLastName.Text;
            employee.FirstName = TxbFirstName.Text;
            employee.Phone = TxbPhone.Text;
            employee.Login = TxbLogin.Text;
            employee.Password = TxbPassword.Password;
            employee.IDRole = CmbRole.SelectedIndex + 1;
            ClassHelper.AppData.context.Employee.Add(employee);
            ClassHelper.AppData.context.SaveChanges();

            MessageBox.Show("Сотрудник добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            
            ClassHelper.NavigateClass.frame.Navigate(new Pages.EmployeePage());
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.frame.GoBack();
        }
    }
}
