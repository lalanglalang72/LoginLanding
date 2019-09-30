using LoginPage.Controller;
using LoginPage.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LoginPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();

        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            UserController CallUser = new UserController();

            if(textEmail.Text.Length==0&&textPassword.Password.Length==0)
            {
                EmailErrorMessage.Text = "You Must Enter Valid Email";
                PasswordErrorMessage.Text = "You MUst Enter Valid Password";
                textEmail.Focus();
                textPassword.Focus();
            }
            else if (textEmail.Text.Length == 0)
            {
                EmailErrorMessage.Text = "You Must Enter Valid Username!";
                textEmail.Focus();
            }
            else if (textPassword.Password.Length == 0)
            {
                PasswordErrorMessage.Text = "You Must Enter Password!";
                textPassword.Focus();
            }
            else
            {
                string email = textEmail.Text;
                string password = textPassword.Password;

                CallUser.UserLogin(email, password);
                this.Hide();
                Home home = new Home(email);
                home.Show();
            }
        }
    }
}
