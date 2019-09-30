using LoginPage.Controller;
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

namespace LoginPage.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            UserController CallUser = new UserController();

            if (textName.Text.Length == 0 && textEmail.Text.Length == 0 && textPassword.Password.Length == 0 && confirmPassword.Password.Length == 0)
            {
                NameErrorMessage.Text = "You Must Enter Valid Name!";
                EmailErrorMessage.Text = "You Must Enter Valid Name!";
                PasswordErrorMessage.Text = "You Must Enter Password!";
                ValidationPasswordErrorMessage.Text = "You Must Enter Confirm Password!";
               confirmPassword.Focus();
                textPassword.Focus();
                textName.Focus();
                textEmail.Focus();
            }
            else if (textPassword.Password.Length == 0 && textName.Text.Length == 0)
            {
                NameErrorMessage.Text = "You Must Enter Valid Username!";
                PasswordErrorMessage.Text = "You Must Enter Password!";
                textName.Focus();
                textPassword.Focus();
            }
            else if (textPassword.Password.Length == 0 && confirmPassword.Password.Length == 0)
            {
                PasswordErrorMessage.Text = "You Must Enter Password!";
                ValidationPasswordErrorMessage.Text = "You Must Enter Confirm Password!";
              confirmPassword.Focus();
                textPassword.Focus();
            }
            else if (textName.Text.Length == 0 && confirmPassword.Password.Length == 0)
            {
                NameErrorMessage.Text = "You Must Enter Valid Username!";
                ValidationPasswordErrorMessage.Text = "You Must Enter Confirm Password!";
                confirmPassword.Focus();
                textName.Focus();
            }
            else if (textEmail.Text.Length == 0 && textName.Text.Length == 0)
            {
                EmailErrorMessage.Text = "You Must Enter Valid Username!";
                NameErrorMessage.Text = "You Must Enter Confirm Password!";
                textEmail.Focus();
                textName.Focus();
            }
            else if (textPassword.Password.Length == 0)
            {
                PasswordErrorMessage.Text = "You Must Enter Password!";
                textPassword.Focus();
            }
            else if (confirmPassword.Password.Length == 0)
            {
                ValidationPasswordErrorMessage.Text = "You Must Enter Confirm Password!";
                confirmPassword.Focus();
            }
            else if (confirmPassword.Password != textPassword.Password)
            {
                ValidationPasswordErrorMessage.Text = "Your Password Need to Enter The Same Password!";
               confirmPassword.Focus();
            }
            else
            {
                string username = textName.Text;
                string password = textPassword.Password;
                string email = textEmail.Text;

                CallUser.AddUser(username,email, password);
                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
