
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double Cost_of_Items()
        {
            Double sum = 0;
            int i = 0;
            for (i = 0; i < (dataGridView1.Rows.Count);
                i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void AddCost()
        {
            Double tax, q;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format("{0:c2}", (((Cost_of_Items() * tax) / 100)));
                lblSubTotal.Text = String.Format("{0:c2}", (Cost_of_Items()));
                q = ((Cost_of_Items() * tax) / 100);
                lblTotal.Text = String.Format("{0:c2}", ((Cost_of_Items() + q)));
                lblBarCode.Text = Convert.ToString(q + Cost_of_Items());
            }

        }
        private void Change()
        {
            Double tax, q, c;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Cost_of_Items() * tax) / 100) + Cost_of_Items();
                c = Convert.ToInt32(lblCash.Text);
                lblChange.Text = String.Format("{0:c2}", c - q);
            }
        }

        Bitmap bitmap;
        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {

            try
            {
                lblBarCode.Text = "";
                lblCash.Text = "";
                lblChange.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboPayment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Visa Card");
            cboPayment.Items.Add("Master Card");

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // Your custom painting logic here
        }

        private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (lblCash.Text == "0")
            {
                lblCash.Text = "";
                lblCash.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (!lblCash.Text.Contains("."))
                {
                    lblCash.Text = lblCash.Text + b.Text;
                }
            }
            else

                lblCash.Text = lblCash.Text + b.Text;
        }

        private void button10(object sender, EventArgs e)
        {
            lblCash.Text = "0";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void RemoveItem_Click_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Double CostofItem = 4500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Steel Straw"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Straw", "1", CostofItem);
            AddCost();

        }

        private void button23_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "earings  "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("earings  ", "1", CostofItem);
            AddCost();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            Double CostofItem = 3000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "earbuds "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("earbuds ", "1", CostofItem);
            AddCost();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double CostofItem = 3500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "mug "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("mug ", "1", CostofItem);
            AddCost();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Double CostofItem = 9000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "camera "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("camera ", "1", CostofItem);
            AddCost();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Double CostofItem = 4000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Elettra "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Elettra ", "1", CostofItem);
            AddCost();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "coffee "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("coffee ", "1", CostofItem);
            AddCost();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "candle "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("candle ", "1", CostofItem);
            AddCost();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "straw "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("straw ", "1", CostofItem);
            AddCost();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "coffee "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "earings "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("earings ", "1", CostofItem);
            AddCost();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "coffee "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("coffee ", "1", CostofItem);
            AddCost();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "hair dryer "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("hair dryer", "1", CostofItem);
            AddCost();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic ", "1", CostofItem);
            AddCost();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Bottle"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Bottle ", "1", CostofItem);
            AddCost();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " Bottle"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Bottle ", "1", CostofItem);
            AddCost();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "glasses "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("glasses ", "1", CostofItem);
            AddCost();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "glasses "))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("glasses ", "1", CostofItem);
            AddCost();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Double CostofItem = 2000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mystic Fragrance"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("Mystic Fragrance", "1", CostofItem);
            AddCost();
        }

        private void lblCash_Click(object sender, EventArgs e)
        {
            // Code to handle lblCash click event
            MessageBox.Show("lblCash was clicked!");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Code to handle lblChange click event
            MessageBox.Show("lblChange was clicked!");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Code to handle lblSubTotal click event

        }
        private void label6_Click(object sender, EventArgs e)
        {
            // Code to handle lblSubTotal click event
        }
        private void label7_Click(object sender, EventArgs e)
        {
            // Code to handle lblSubTotal click event

        }

        private void DataGridView1_CellContentClick(object sender, EventArgs e)
        {
            // Code to handle lblSubTotal click event

        }

        private void panel2_Paint(object sender, EventArgs e)
        {
            // Code to handle lblSubTotal click event

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}