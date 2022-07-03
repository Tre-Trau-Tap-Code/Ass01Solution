using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class MemberDetails : Form
    {
        public BusinessObject.Member Member { get; set; }
        public MemberDetails()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Member.MemberName = txtMemberName.Text;
            Member.Email = txtEmail.Text;
            Member.City = txtCity.Text;
            Member.Country = txtCountry.Text;
            MessageBox.Show("Update information successfully!");
        }

        private void MemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberName.Text = Member.MemberName;
            txtEmail.Text = Member.Email;
            txtCity.Text = Member.City;
            txtCountry.Text = Member.Country;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout successfully!");
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword
            {
                Member = Member
            };
            changePassword.ShowDialog();
        }
    }
}