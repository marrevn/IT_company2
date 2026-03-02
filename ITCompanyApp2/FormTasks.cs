using ITCompanyApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCompanyApp2
{
    public partial class FormTasks : Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormTasks(User user, bool guest)
        {
            InitializeComponent();

            var colName = new DataGridViewTextBoxColumn();
            colName.Name = "colName";
            colName.FillWeight = 20;
            colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 70;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDays = new DataGridViewTextBoxColumn();
            colDays.Name = "colDays";
            colDays.FillWeight = 10;
            colDays.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTasks.Columns.AddRange(
                colName, colInfo, colDays
            );

            LoadTasks();

            CurrentUser = user;
            IsGuest = guest;
            lblUsername.Text = IsGuest ? "Гость" : CurrentUser.Fio;
        }

        private void LoadTasks()
        {
            using (var db = new ItCompanyContext())
            {
                var tasks = db.Tasks
                    .Include(i => i.StatusesTask)
                    .Include(i => i.Priority)
                    .Include(i => i.Project)
                    .Include(i => i.User)
                    .ToList();

                dgvTasks.SuspendLayout();
                dgvTasks.Rows.Clear();

            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
