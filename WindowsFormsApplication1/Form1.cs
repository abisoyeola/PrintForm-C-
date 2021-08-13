using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Rows.Add(i, i, i, i);
                dataGridView1.Height += 20;
                dataGridView2.Rows.Add(i, i, i, i);
                dataGridView2.Height += 20;
                dataGridView3.Rows.Add(i, i, i, i);
                dataGridView3.Height += 20;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height+ this.dataGridView2.Height+ this.dataGridView3.Height+label1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            dataGridView2.DrawToBitmap(bm, new Rectangle(0, 0 + dataGridView1.Height, this.dataGridView2.Width, this.dataGridView2.Height));
            dataGridView3.DrawToBitmap(bm, new Rectangle(0, 0 + dataGridView1.Height+dataGridView3.Height, this.dataGridView3.Width, this.dataGridView3.Height));
            label1.DrawToBitmap(bm, new Rectangle(0, dataGridView1.Height + dataGridView3.Height + dataGridView2.Height , label1.Width, label1.Height));

            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
