using DataAccess;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        MemberDAO memberDAO = new MemberDAO();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            bool enabled = false;
            bool show = false;
            if (email.Equals(MemberDAO.Admin.Email) && password.Equals(MemberDAO.Admin.Password))
            {
                frmMemberManagement frmMemberManagement = new frmMemberManagement();
                frmMemberManagement.ShowDialog();
                Close();
                return;
            }
            else if (!enabled)
            {
                var members = memberDAO.GetMembers;
                foreach (var member in members)
                {
                    if (email.Equals(member.Email) && password.Equals(member.Password))
                    {
                        MemberDetails memberDetails = new MemberDetails
                        {
                            Member = member
                        };
                        memberDetails.ShowDialog();
                        Close();
                        return;
                    }
                }
            }
            else MessageBox.Show("Incorrect email or password");
    }

    private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateMember createMember = new CreateMember();
            createMember.ShowDialog();
        }
    }
}