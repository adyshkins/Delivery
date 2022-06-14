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

        private bool isEdit = false;
        EF.Employee editEmployee;
        public AddEditEmployeePage()
        {
            InitializeComponent();

            CmbRole.ItemsSource = ClassHelper.AppData.context.Role.ToList();
            CmbRole.DisplayMemberPath = "NameRole";
            CmbRole.SelectedIndex = 0;

            isEdit = false;
        }

        public AddEditEmployeePage(EF.Employee employee)
        {
            InitializeComponent();

            TbTitle.Text = "Изменение сотрудника";
            BtnAddEmployee.Content = "Сохранить";
            CmbRole.ItemsSource = ClassHelper.AppData.context.Role.ToList();
            CmbRole.DisplayMemberPath = "NameRole";


            TxbLastName.Text = employee.LastName;
            TxbFirstName.Text = employee.FirstName;
            TxbPhone.Text = employee.Phone;
            TxbLogin.Text = employee.Login;
            TxbPassword.Password = employee.Password;
            CmbRole.SelectedIndex = employee.IDRole - 1;

            isEdit = true;
            editEmployee = employee;
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            if (isEdit)
            {
                // изменение

                editEmployee.LastName = TxbLastName.Text;
                editEmployee.FirstName = TxbFirstName.Text;
                editEmployee.Phone = TxbPhone.Text;
                editEmployee.Login = TxbLogin.Text;
                editEmployee.Password = TxbPassword.Password;
                editEmployee.IDRole = CmbRole.SelectedIndex + 1;


                ClassHelper.AppData.context.SaveChanges();

                MessageBox.Show("Данные изменены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                ClassHelper.NavigateClass.frame.Navigate(new Pages.EmployeePage());
            }
            else
            {
                // добавление

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
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.frame.GoBack();
        }
    }
}
///
