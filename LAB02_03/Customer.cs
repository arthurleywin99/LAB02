using LAB02_03.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;
using LAB02_03.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Data;

namespace LAB02_03
{
    public partial class frmCustomer : Form
    {
        private DataTable data;
        public frmCustomer()
        {
            CenterToParent();
            InitializeComponent();
            data = new DataTable();
            data.Columns.Add("Mã Khách Hàng", typeof(int));
            data.Columns.Add("Tên Khách Hàng", typeof(string));
            dgvCustomer.DataSource = data;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            List<Customer> customers = GetCustomerController.GetCustomer();
            foreach (var item in customers)
            {
                DataRow row = data.NewRow();
                row["Mã Khách Hàng"] = item.CustomerID;
                row["Tên Khách Hàng"] = item.CustomerName;
                data.Rows.Add(row);
            }
        }
    }
}