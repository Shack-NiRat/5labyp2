namespace WinFormsApp1
{
    public partial class Авторизация : Form
    {

        public int mistakes = 0;

        private string? role;

        capcha f = new capcha();

        int time = 10;

        public Авторизация()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            button2.Text = "\U0001F441";
            timer1.Interval = 1000;
            timer1.Start();
        }

        

        void CheckAutorisation()
        {
            using (НоябрьУпКозловContext db = new НоябрьУпКозловContext())
            {
                string login = textBox1.Text;
                string password = textBox2.Text;


                Autorisation? autorisation = db.Autorisations.FirstOrDefault(p => p.Login == login && p.Password == password);

                if (autorisation == null)
                {
                    if (mistakes == 0)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                        mistakes++;
                        return;
                    }
                    if(mistakes == 1)
                    {
                        if (f != null)
                        {
                            f.Dispose();
                            f = new capcha();
                            f.Owner = this;
                        }
                        f.Show();
                    }
                    if(mistakes == 2)
                    {
                        label4.Visible = true;
                        button1.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        
                        History mistperson = new History { Login = textBox1.Text, Role = "mistaker", Status = "mistake", Date = DateTime.Now };
                        db.Histories.Add(mistperson);
                        db.SaveChanges();
                        
                        label4.Text = "заблокировано";
                    }
                }
                else
                {
                    role = autorisation.Role;
                }
            }
        }


        void GoToForm()
        {
            using (НоябрьУпКозловContext db = new НоябрьУпКозловContext())
            {
                if (role == null)
                {
                    
                    return;
                }
                

                History person = new History { Login = textBox1.Text, Role = role, Status = "complete", Date = DateTime.Now };
                db.Histories.Add(person);


                if (role == "Admin")
                {
                    Администратор админ = new Администратор();
                    this.Hide();
                    админ.ShowDialog();
                    timer1.Stop();
                    this.Close();
                }

                if (role == "Student")
                {
                    Студент студ = new Студент();
                    this.Hide();
                    студ.ShowDialog();
                    timer1.Stop();
                    this.Close();
                }

                if (role == "Teacher")
                {
                    Преподаватель препод = new Преподаватель();
                    this.Hide();
                    препод.ShowDialog();
                    timer1.Stop();
                    this.Close();
                }
                db.SaveChanges();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           CheckAutorisation();

            GoToForm();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                button1.Enabled = false;
            }
            else button1.Enabled = true;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mistakes == 2)
            {
                label4.Visible = true;
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                label4.Text = time.ToString();
                time--;
                if (time <= 0)
                {
                    label4.Visible = false;
                    timer1.Stop();
                    button1.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                }
            }
            
        }
    }
}