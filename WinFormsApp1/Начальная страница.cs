using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Начальная_страница : Form
    {
        public Начальная_страница()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация авт = new Авторизация();
            this.Hide();
            авт.ShowDialog();
            this.Close();
        }
    }
}
