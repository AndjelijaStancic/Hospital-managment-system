﻿using System;
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
using Model;
using Controller;
using System.Diagnostics;


namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserController user_Controller;
        public List<User> users { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            var app = Application.Current as App;
            user_Controller = app.UserController;
            this.users = user_Controller.GetAll();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Feedback.Clear();
            User logged = this.user_Controller.CheckExistence(new LogInUser(EmailOrUserName.Text, PasswordTextBox.Password.ToString()));
            var app = Application.Current as App;
            app.Properties["IdUser"] = logged.Id;
            app.Properties["Role"] = logged.Role.ToString();

            if (logged.Id == -1)
            {
                Feedback.Text = "Greška, loše uneti podaci!";
                return;
            }
           
            if (logged.Role.ToString().Equals("Director"))
            {
                var main = new MainWindow();
                main.Show();
                Close();
            }
            else if (logged.Role.ToString().Equals("Secretary"))
            {
                Close();
            }
            else if (logged.Role.ToString().Equals("Doctor"))
            {
                Close();
            }
            else if (logged.Role.ToString().Equals("Patient"))
            {
                Close();
            }
        }
       
        private void RegisterClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
