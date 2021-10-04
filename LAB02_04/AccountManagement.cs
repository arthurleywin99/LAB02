using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB02_04.Controller;
using LAB02_04.Model;

namespace LAB02_04
{
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void LoadAccount()
        {
            dgvAccount.Rows.Clear();
            List<Account> accounts = GetAccountController.GetAccounts();
            foreach (var item in accounts)
            {
                DataGridViewRow row = (DataGridViewRow)dgvAccount.Rows[0].Clone();
                row.Cells[0].Value = item.AccountID;
                row.Cells[1].Value = item.FullName;
                row.Cells[2].Value = item.Address;
                row.Cells[3].Value = item.Total;
                dgvAccount.Rows.Add(row);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = GetSelectedStudent(txtAccountID.Text);
            if (index == -1)
            {
                Account account = new Account() { AccountID = txtAccountID.Text, FullName = txtFullName.Text, Address = txtAddress.Text, Total = Convert.ToInt32(txtTotal.Text) };
                AccountController.AddAccount(account);
                DataGridViewRow row = (DataGridViewRow)dgvAccount.Rows[0].Clone();
                row.Cells[0].Value = account.AccountID;
                row.Cells[1].Value = account.FullName;
                row.Cells[2].Value = account.Address;
                row.Cells[3].Value = account.Total;
                dgvAccount.Rows.Add(row);
            }
            else
            {
                AccountController.UpdateAccount(txtAccountID.Text, new Account() { AccountID = txtAccountID.Text, FullName = txtFullName.Text, Address = txtAddress.Text, Total = Convert.ToInt32(txtTotal.Text) });
                LoadAccount();
            }
        }

        private int GetSelectedStudent(string id)
        {
            for (int i = 0; i < dgvAccount.Rows.Count; ++i)
            {
                if (dgvAccount.Rows[i].Cells[1].Value == null)
                {
                    return -1;
                }
                if (dgvAccount.Rows[i].Cells[1].Value.ToString() == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = GetSelectedStudent(txtAccountID.Text);
                if (index == -1)
                {
                    throw new Exception("Mã tài khoản không hợp lệ");
                }
                else
                {
                    Account account = new Account() { AccountID = txtAccountID.Text, FullName = txtFullName.Text, Address = txtAddress.Text, Total = Convert.ToInt32(txtTotal.Text) };
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa tài khoản này không?", "Warning", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        AccountController.DeleteAccount(account);
                        LoadAccount();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtAccountID.Text = dgvAccount.Rows[rowIndex].Cells[0].Value.ToString();
            txtFullName.Text = dgvAccount.Rows[rowIndex].Cells[1].Value.ToString();
            txtAddress.Text = dgvAccount.Rows[rowIndex].Cells[2].Value.ToString();
            txtTotal.Text = dgvAccount.Rows[rowIndex].Cells[3].Value.ToString();
        }
    }
}
