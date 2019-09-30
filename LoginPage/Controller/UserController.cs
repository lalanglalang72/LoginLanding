﻿using LoginPage.Context;
using LoginPage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginPage.Controller
{
    class UserController
    {
        public void AddUser(string uname, string email, string password)
        {
            var result = 0;
            Users user = new Users();
            MyContext _context = new MyContext();

            user.Name = uname;
            user.Email = email;
            user.Password = password;

            _context.Users.Add(user);

            result = _context.SaveChanges();

            if (result > 0)
            {
                MessageBox.Show("Register Successful!");
            }
            else
            {
                MessageBox.Show("Register Failed!");
            }
        }

        public void UserLogin(string uname, string password)
        {
            Users user = new Model.Users();
            MyContext _context = new MyContext();

            var get = _context.Users.Where(u => u.Name == uname).FirstOrDefault<Users>();

            if (get == null)
            {
                MessageBox.Show("Your Username is Incorrect!");
            }
            else
            {
                if (get.Password != password)
                {
                    MessageBox.Show("Your Password is Incorrect!");
                }
                else
                {
                    MessageBox.Show("Login Successful!");
                    //MainWindow main = new MainWindow();
                    //main.Hide();
                    //Home home = new Home();
                    //home.Show();
                }
            }
        }

        public void ChangePassword(string name, string email, string password)
        {
            var result = 0;

            Users user = new Users();
            MyContext _context = new MyContext();

            var get = _context.Users.Where(u => u.Name == name).FirstOrDefault<Users>();

           if (get == null)
            {
                MessageBox.Show("Your Username is Incorrect!");
            }
            else
            {
                if (get.Password != password)
                {
                    get.Password = password;
                    result = _context.SaveChanges();

                    if (result > 0)
                    {
                        MessageBox.Show("Update Success!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!");
                    }

                }
                else
                {
                    MessageBox.Show("Your Password can't be the same!");
                }
            }
        }
    }
}
