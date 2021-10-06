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
            try
            {
                do
                {
                    res = formLogin.ShowDialog();
                    appUser = formLogin.ReturnUser;
                }
                while (!appUser.isAuthenticated && res == DialogResult.OK);

                if (res != DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (NullReferenceException) {
                this.Close();
            }
            SetText();
        }

        private void SetText()
        {
            Text = "Main - No Project Selected";
        }

    }
}
