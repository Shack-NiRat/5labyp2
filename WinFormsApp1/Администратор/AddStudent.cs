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
    public partial class AddStudent : Form
    {
        public AddStudent()
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

        private void AddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Администратор f = new Администратор();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (НоябрьУпКозловContext db = new НоябрьУпКозловContext())
                {
                    Студенты students = new Студенты { НомерЗачетнойКнижки = Int32.Parse(textBox1.Text), Фио = textBox2.Text, Факультет = textBox3.Text, Группа = textBox4.Text };
                    db.Студентыs.Add(students);
                    db.SaveChanges();
                    MessageBox.Show("Успех");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
