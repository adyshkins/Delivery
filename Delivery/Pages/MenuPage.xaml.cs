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
using Delivery.Pages;
using Delivery.ClassHelper;


namespace Delivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new MainPage());
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new EmployeePage());
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new ProducrPage());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new ClientPage());
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new DeliveryPage());
        }
    }
}
