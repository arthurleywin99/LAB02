using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_02
{
    public partial class StudentManagement : Form
    {
        public StudentManagement()
        {
            InitializeComponent();
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            List<string> Falcuties = new List<string>();
            Falcuties.Add("Quản trị kinh doanh");
            Falcuties.Add("Công nghệ thông tin");
            Falcuties.Add("Công nghệ ô tô");
            Falcuties.Add("Ngôn ngữ Anh");
            Falcuties.Add("Ngôn ngữ Nhật");
            Falcuties.Add("Cơ điện tử");
            Falcuties.Add("Công nghệ sinh học");

            foreach (var item in Falcuties)
            {
                cmbFaculty.Items.Add(item);
            }

            cmbFaculty.SelectedIndex = 0;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtAverageScore.Text))
                {
                    throw new Exception("Không được để trống");
                }

                int index = GetSelectedRow(txtStudentID.Text);

                if (index == -1)
                {
                    index = dgvStudentList.Rows.Add();
                    Update(index);
                    MessageBox.Show("Thêm thành công", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    Update(index);
                    MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = GetSelectedRow(txtStudentID.Text);
                if (index == -1)
                {
                    throw new Exception("Không tìm thấy MSSV cần xóa");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa sinh viên này không?", "YES/NO?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow row = this.dgvStudentList.SelectedRows[0];
                        dgvStudentList.Rows.RemoveAt(index);
                        if (row.Cells[2].Value.ToString().Equals("Nam"))
                        {
                            txtSumMale.Text = (int.Parse(txtSumMale.Text) - 1).ToString();
                        }
                        else
                        {
                            txtSumFemale.Text = (int.Parse(txtSumFemale.Text) - 1).ToString();
                        }
                        MessageBox.Show("Xóa sinh viên thành công", "Nofication", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudentList.Rows.Count; ++i)
            {
                if (dgvStudentList.Rows[i].Cells[0].Value == null)
                {
                    return -1;
                }
                if (dgvStudentList.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Update(int index)
        {
            dgvStudentList.Rows[index].Cells[0].Value = txtStudentID.Text;
            dgvStudentList.Rows[index].Cells[1].Value = txtFullName.Text;
            dgvStudentList.Rows[index].Cells[2].Value = optMale.Checked ? "Nam" : "Nữ";
            dgvStudentList.Rows[index].Cells[3].Value = txtAverageScore.Text;
            dgvStudentList.Rows[index].Cells[4].Value = cmbFaculty.Text;

            if (optMale.Checked)
            {
                txtSumMale.Text = (int.Parse(txtSumMale.Text) + 1).ToString();
            }
            else
            {
                txtSumFemale.Text = (int.Parse(txtSumFemale.Text) + 1).ToString();
            }
        }

        private void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvStudentList.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells[0].Value.ToString();
                txtFullName.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString().Equals("Nam"))
                {
                    optMale.Enabled = true;
                }
                else
                {
                    optFemale.Enabled = true;
                }
                txtAverageScore.Text = row.Cells[3].Value.ToString();
                for (int i = 0; i < cmbFaculty.Items.Count; i++)
                {
                    if (row.Cells[4].Value.ToString().Equals(cmbFaculty.GetItemText(cmbFaculty.Items[i])))
                    {
                        cmbFaculty.SelectedIndex = i;
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}