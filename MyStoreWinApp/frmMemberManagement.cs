﻿using BusinessObject;
using DataAccess;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        BindingSource source;
        MemberDAO dao = new MemberDAO();
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        private void LoadMembers()
        {
            var members = dao.GetMembers;

            source = new BindingSource();
            source.DataSource = members;

           
            lbId.DataBindings.Clear();
            txtMemberName.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtCity.DataBindings.Clear();
            txtCountry.DataBindings.Clear();
            lbTotal.DataBindings.Clear();
                

            lbId.DataBindings.Add("Text", source, "MemberID");
            txtMemberName.DataBindings.Add("Text", source, "MemberName");
            txtEmail.DataBindings.Add("Text", source, "Email");
            txtCity.DataBindings.Add("Text", source, "City");
            txtCountry.DataBindings.Add("Text", source, "Country");
            lbTotal.Text = $"Total: {dao.GetMembers.Count()}";

            dvgMembers.DataSource = null;
            dvgMembers.DataSource = members;

            /*lbId.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;*/
        }
        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout successfully!");
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var member = GetMember();

            member.MemberName = txtMemberName.Text;
            member.Email = txtEmail.Text;
            member.City = txtCity.Text;
            member.Country = txtCountry.Text;
            MessageBox.Show("Update member successfully!");
            LoadMembers();
        }
        private Member GetMember()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberID = int.Parse(lbId.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMember();
                dao.Remove(member.MemberID);
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMember createMember = new CreateMember();
            createMember.ShowDialog();
            LoadMembers();
        }

        /*private void dvgMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // make sure user select at least 1 row 
            {
                DataGridViewRow row = this.dvgMembers.Rows[e.RowIndex];
                lbId.Text = row.Cells[0].Value.ToString();
                txtMemberName.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtCity.Text = row.Cells[4].Value.ToString();
                txtCountry.Text = row.Cells[5].Value.ToString();

            }
            btnDelete.Enabled = true;
        }*/
    }
}
