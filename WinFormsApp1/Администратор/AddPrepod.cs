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
    public partial class AddPrepod : Form
    {
        public AddPrepod()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.') && (e.KeyChar != '+' && (e.KeyChar != '(') && (e.KeyChar != ')') && (e.KeyChar != '-')))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                using (НоябрьУпКозловContext db = new НоябрьУпКозловContext())
                {
                    Преподаватели prepods = new Преподаватели { КодПреподавателя = Int32.Parse(textBox1.Text), Фио = textBox2.Text, Степень = textBox3.Text, Звание = textBox7.Text, Кафедра = textBox4.Text, Телефон = textBox5.Text, Email = textBox6.Text };
                    db.Преподавателиs.Add(prepods);
                    db.SaveChanges();
                    MessageBox.Show("Успех");
                }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void AddPrepod_FormClosed(object sender, FormClosedEventArgs e)
        {
            Администратор f = new Администратор();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
