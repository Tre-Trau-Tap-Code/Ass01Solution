namespace MyStoreWinApp
{
    public partial class ChangePassword : Form
    {
        public BusinessObject.Member Member { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
        }
        private bool CheckPassword()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txtOldPass.Text)|| string.IsNullOrEmpty(txtNewPass.Text)|| string.IsNullOrEmpty(txtConfirm.Text))
            {
                lbError.Text = "Every field has to be fulfilled!";
                check = false;
            }
            if (!txtNewPass.Text.Equals(txtConfirm.Text))
            {
                lbError.Text = "Incorrect confirm password!";
                check = false;
            }
            return check;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckPassword())
            {
                Member.Password = txtNewPass.Text;
                MessageBox.Show("Change password successfully!");
                Close();
            }
        }
    }
}
