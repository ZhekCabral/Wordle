﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public partial class helpWordle : Form
    {
        public helpWordle()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameArea gameArea = new gameArea();
            gameArea.Show();

            this.Hide();
        }

        private void helpWordle_Load(object sender, EventArgs e)
        {

        }
    }
}
