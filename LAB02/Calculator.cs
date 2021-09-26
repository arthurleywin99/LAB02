using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Tag.Equals("Add"))
            {
                try
                {
                    txtResult.Text = (float.Parse(txtA.Text) + float.Parse(txtB.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (button.Tag.Equals("Subtract"))
            {
                try
                {
                    txtResult.Text = (float.Parse(txtA.Text) - float.Parse(txtB.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (button.Tag.Equals("Multiply"))
            {
                try
                {
                    txtResult.Text = (float.Parse(txtA.Text) * float.Parse(txtB.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (button.Tag.Equals("Divide"))
            {
                if (float.Parse(txtB.Text) == 0f)
                {
                    txtResult.Text = "Cannot Divide By Zero";
                }
                else
                {
                    try
                    {
                        txtResult.Text = (float.Parse(txtA.Text) / float.Parse(txtB.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void txtA_Validating(object sender, CancelEventArgs e)
        {
            float Result = -1f;
            bool isSuccess = float.TryParse(txtA.Text, out Result);
            if (string.IsNullOrEmpty(txtA.Text))
            {
                e.Cancel = true;
                txtA.Focus();
                errorProvider.SetError(txtA, "Không được để trống");
            }
            else if (!isSuccess)
            {
                e.Cancel = true;
                txtA.Focus();
                errorProvider.SetError(txtA, "Sai định dạng số");                
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtA, null);
            }
        }

        private void txtB_Validating(object sender, CancelEventArgs e)
        {
            float Result = -1f;
            bool isSuccess = float.TryParse(txtB.Text, out Result);
            if (string.IsNullOrEmpty(txtB.Text))
            {
                e.Cancel = true;
                txtB.Focus();
                errorProvider.SetError(txtB, "Không được để trống");
            }
            else if (!isSuccess)
            {
                e.Cancel = true;
                txtB.Focus();
                errorProvider.SetError(txtB, "Sai định dạng số");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtB, null);
            }
        }
    }
}
