using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4
{
    public partial class FormLogin : Form
    {
        public AppUser ReturnUser { get; set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
 
            if (String.IsNullOrEmpty(this.textBoxUserName.Text) || String.IsNullOrEmpty(this.textBoxPass.Text))
            {
                MessageBox.Show("Please Enter Username and Password.", "Error");
                return;
            }
            string user = this.textBoxUserName.Text.ToString();
            string pass = this.textBoxPass.Text.ToString();

            FakeAppUserRepository repo = new FakeAppUserRepository();
            bool auth = repo.Login(user, pass);
            if (!auth)
            {
                MessageBox.Show("Incorrect Username or Password.", "Attention");
                this.Close();
            }

            repo.SetAuthentication(user, true);
            this.ReturnUser = repo.GetByUserName(user);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
