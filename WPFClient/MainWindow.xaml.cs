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

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new DataContext();

            Refresh();
           // btnRef.Click += delegate { listView.ItemsSource = context.GetPhoneBooks().ToObservableCollection(); };
        }

        private void Refresh()
        {
            btnRef.Click += delegate { listView.ItemsSource = context.GetPhoneBooks().ToObservableCollection(); };
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            context.Add(
                new PhoneBook
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MiddleName = txtMiddleName.Text,
                    TelephonNumber = Decimal.Parse(txtTelephonNumber.Text),
                    Email = txtEmail.Text,
                    Submit = $"create by WPF - {DateTime.Now}"
                });

            Refresh();
        }

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
