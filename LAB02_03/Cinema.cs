﻿using LAB02_03.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;
using LAB02_03.Model;
using System.Collections.Generic;
using System.Globalization;

namespace LAB02_03
{
    public partial class Cinema : Form
    {
        private Button[,] buttons;
        public Cinema()
        {
            InitializeComponent();
        }

        private void Cinema_Load(object sender, EventArgs e)
        {
            CreateButton(3, 5);
            LoadBill();
        }

        private void CreateButton(int height, int width)
        {
            buttons = new Button[height, width];
            int w = 150, h = 100, count = 1, x = 3, y = 3;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    buttons[i,j] = new Button();
                    buttons[i, j].Text = count++.ToString();
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].Font = new Font("Consolas", 25);
                    buttons[i, j].Size = new Size(w, h);
                    buttons[i, j].Location = new Point(x, y);
                    buttons[i, j].Click += BtnCinemaSeats_Click;
                    pnlContainer.Controls.Add(buttons[i, j]);
                    x += w + 3;
                }
                y += h + 3;
            }
        }

        private void LoadBill()
        {
            dgvBill.Rows.Clear();
            var result = GetBillController.GetBill();
            var ordered = GetBillDetailsController.OrderedSeat();
            foreach (var item in ordered)
            {
                var index = Convert.ToInt32(item.SeatID);
                if (index <= 5)
                {
                    buttons[0, index - 1].BackColor = Color.Yellow;
                }
                else if (item.SeatID <= 10)
                {
                    buttons[1, index - 6].BackColor = Color.Yellow;
                }
                else
                {
                    buttons[2, index - 11].BackColor = Color.Yellow;
                }
            }
            foreach (var item in result)
            {
                DataGridViewRow row = (DataGridViewRow)dgvBill.Rows[0].Clone();
                row.Cells[0].Value = item.BillID.ToString();
                row.Cells[1].Value = item.PurchaseDate.Value.ToShortDateString();
                row.Cells[2].Value = GetBillDetailsController.GetBillDetails(item.BillID).Count;
                row.Cells[3].Value = item.Total.Value.ToString();
                dgvBill.Rows.Add(row);
            }
        }

        private void BtnCinemaSeats_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Blue;
            }
            else if (button.BackColor == Color.Blue)
            {
                button.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Ghế này đã được mua", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < buttons.GetLength(0); ++i)
            {
                for (int j = 0; j < buttons.GetLength(1); ++j)
                {
                    if (buttons[i, j].BackColor == Color.Blue)
                    {
                        total += GetBillDetailsController.GetPrice(5 * i + j + 1);
                    }
                }
            }
            txtTotal.Text = total.ToString();

            AddDataToDB();
        }

        private void AddDataToDB()
        {
            BillController.AddBill(new Bill() { BillID = dgvBill.RowCount, PurchaseDate = Convert.ToDateTime(dtpPurchaseDate.Value.ToShortDateString().ToString()), Total = Convert.ToDecimal(txtTotal.Text) });

            for (int i = 0; i < buttons.GetLength(0); ++i)
            {
                for (int j = 0; j < buttons.GetLength(1); ++j)
                {
                    if (buttons[i, j].BackColor == Color.Blue)
                    {
                        BillDetailsController.AddBillDetails(new BillDetail { BillID = dgvBill.RowCount, SeatID = 5 * i + j + 1 });
                        buttons[i, j].BackColor = Color.Yellow;
                    }
                }
            }
            LoadBill();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBillDetails.Rows.Clear();
            int rowIndex = e.RowIndex;
            var result = GetBillDetailsController.GetBillDetails(int.Parse(dgvBill.Rows[rowIndex].Cells[0].Value.ToString()));
            foreach (var item in result)
            {
                DataGridViewRow row = (DataGridViewRow)dgvBillDetails.Rows[0].Clone();
                row.Cells[0].Value = int.Parse(dgvBill.Rows[rowIndex].Cells[0].Value.ToString());
                row.Cells[1].Value = dgvBill.Rows[rowIndex].Cells[1].Value;
                row.Cells[2].Value = item.SeatID.ToString();
                row.Cells[3].Value = GetBillDetailsController.GetPrice(Convert.ToInt32(item.SeatID));
                dgvBillDetails.Rows.Add(row); 
            }

            dtpPurchaseDate.Value = Convert.ToDateTime(dgvBill.Rows[rowIndex].Cells[1].Value.ToString());

            txtTotal.Text = dgvBill.Rows[rowIndex].Cells[3].Value.ToString();
        }
    }
}