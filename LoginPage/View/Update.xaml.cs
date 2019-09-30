using LoginPage.Context;
using LoginPage.Controller;
using LoginPage.Model;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    { 
        public string Lemail;
        public string Gname;
        public Update(string Gemail)
        {
            InitializeComponent();
            UnameSetter(Gemail);
            GnameGetter(Gemail);
            textEmail.Text = Gemail;
            textName.Text = Gname;
        }
        public void UnameSetter(string Gemail)
        {
            Lemail = Gemail;
        }

        public void GnameGetter(string Gemail)
        {
            Users user = new Users();
            MyContext _context = new MyContext();
            var get = _context.Users.Where(u => u.Email == Gemail).FirstOrDefault<Users>();
            Gname = get.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserController CallUser = new UserController();
            if (textName.Text.Length == 0 && textEmail.Text.Length == 0 && textPassword.Password.Length == 0)
            {
                NameErrorMessage.Text = "You Must Enter Valid Name!";
                EmailErrorMessage.Text = "You Must Enter Valid Email!";
                PasswordErrorMessage.Text = "You Must Enter Password!";
                textPassword.Focus();
                textName.Focus();
                textEmail.Focus();
            }
            else if (textName.Text.Length == 0)
            {
                NameErrorMessage.Text = "You Must Enter Valid Name!";
                textName.Focus();
            }
            else if (textPassword.Password.Length == 0)
            {
                PasswordErrorMessage.Text = "You Must Enter Password!";
                textPassword.Focus();
            }
            else if (textEmail.Text.Length == 0)
            {
                EmailErrorMessage.Text = "You Must Enter Email!";
                textEmail.Focus();
            }
            else
            {
                string username = textName.Text;
                string password = textPassword.Password;
                string email = textEmail.Text;

                CallUser.ChangePassword(email, username, password);

                this.Hide();
                Home home = new Home(email);
                home.Show();
              
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home home = new Home(Lemail);
            home.Show();
        }
    }
}
