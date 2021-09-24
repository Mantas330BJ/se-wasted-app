﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wasted_app
{
    public partial class RestaurantLogInControl : UserControl
    {
        private static RestaurantLogInControl _instance;
        public static RestaurantLogInControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RestaurantLogInControl();
                return _instance;
            }
        }
        public RestaurantLogInControl()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (!MainForm.mainForm.panel.Controls.Contains(RestaurantRegistrationControl.Instance))
            {
                MainForm.mainForm.panel.Controls.Add(RestaurantRegistrationControl.Instance);
                RestaurantRegistrationControl.Instance.Dock = DockStyle.Fill;
                RestaurantRegistrationControl.Instance.BringToFront();
            }
            else
            {
                RestaurantRegistrationControl.Instance.BringToFront();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm.mainForm.panel.Controls.Remove(_instance);
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            //Place holder: needs credentials validation funcion
            if (usernameTextBox.Text == "admin" && passwordTextBox.Text == "admin")
            {
                MessageBox.Show("Successfuly loged in!");
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }

        private void showPasswordButton_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.PasswordChar = '\0';
        }

        private void showPasswordButton_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }
    }
}