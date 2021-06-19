using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsnFinalProjectHastahaneOtomasyon
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbProcess db = new DbProcess();
            var result = db.Login(textBox1.Text, textBox2.Text);
            if (result!=0)
            {
                this.Hide();
                MainForm mainForm = new MainForm(result);
                mainForm.Show();
            }
            else
            {
                label4.Text = "Giriş Başarısız";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            //Application.OpenForms[0].Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
