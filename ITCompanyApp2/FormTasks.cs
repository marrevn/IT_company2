using ITCompanyApp2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ITCompanyApp2
{
    public partial class FormTasks : Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormTasks(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;
            lblUsername.Text = IsGuest ? "Гость" : CurrentUser.Fio;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
