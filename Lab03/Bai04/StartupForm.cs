using System;
using System.Windows.Forms;

namespace Lab02
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServerForm serverForm = new ServerForm();
            serverForm.ShowDialog();
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
            this.Close();
        }

        private void btnForm5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }
    }
}
