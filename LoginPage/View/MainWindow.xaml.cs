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
            Properties.Settings.Default.Email = textEmail.Text;
            Properties.Settings.Default.Save();
            if (textEmail.Text.Length == 0 && textPassword.Password.Length == 0)
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

                var status = CallUser.UserLogin(email, password);
                if (status == true)
                {
                    this.Hide();
                    Home home = new Home(email);
                    home.Show();
                }

            }

        }

       
        private void RememberMe_Checked(object sender, RoutedEventArgs e)
        {
            textEmail.Text = Properties.Settings.Default.Email;
        }
    }
}
