﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {

        }

        private void UserButton_Click(object sender, EventArgs e)
        {

        }

        private void BookBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
