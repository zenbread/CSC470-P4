using System;
using System.Windows.Forms;

namespace P4
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            FormLogin formLogin = new FormLogin();
            DialogResult res;
            AppUser appUser;

            do
            {
                res = formLogin.ShowDialog();
                appUser = formLogin.ReturnUser;
                if (res != DialogResult.OK)
                {
                    this.Close();
                    break;
                }
            }
            while (!appUser.isAuthenticated && res == DialogResult.OK);

            SetText();
        }

        private void SetText()
        {
            Text = "Main - No Project Selected";
        }

    }
}
