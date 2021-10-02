using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_03
{
    public partial class Cinema : Form
    {
        public Cinema()
        {
            InitializeComponent();
        }

        private void Cinema_Load(object sender, EventArgs e)
        {
            CreateButton(3, 5);
        }

        private void CreateButton(int height, int width)
        {
            int w = 150, h = 100, count = 1, x = 3, y = 3;
            Button btn;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    btn = new Button();
                    btn.Text = count++.ToString();
                    btn.BackColor = Color.White;
                    btn.Font = new Font("Consolas", 25);
                    btn.Size = new Size(w, h);
                    btn.Location = new Point(x, y);
                    btn.Click += BtnCinemaSeats_Click;
                    pnlContainer.Controls.Add(btn);
                    x += w + 3;
                }
                y += h + 3;
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

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
