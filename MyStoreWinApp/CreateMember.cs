using BusinessObject;

namespace MyStoreWinApp
{
    public partial class CreateMember : Form
    {
        public CreateMember()
        {
            InitializeComponent();
        }
        private bool CheckRegister()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txtMemberName.Text)) { 
                check = false;
                lbErrorName.Text = "Name should be from 6 to 25 characters!";
            }
            if (!txtPassword.Text.Equals(txtConfirmPassword.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                check = false;
                lbErrorPass.Text = "Password or confirm password is not incorrect!";
            }
            return check;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (CheckRegister())
            {
                DataAccess.MemberDAO dao = new DataAccess.MemberDAO();
                dao.AddNew(new Member
                {
                    MemberID = dao.GetMembers.Count()+1,
                    MemberName = txtMemberName.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                });
                MessageBox.Show("Register successfully!");
                Close();
                return;
            }
            MessageBox.Show("Register failed!");
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
