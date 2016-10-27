using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Cash_Register
{
    public partial class Form1 : Form
    {
        const double SHEETS_COST = 2.25;
        const double TEST_COSTS = 3.75;
        const double TAX_AMOUNT = 0.13;

        int tests, sheets, amountPaid;

        double price, taxAmount, totalWithTax, changeDue, sheetprice, testprice;

        private void changeLabel_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) 
        {
            sheets = Convert.ToInt32(gradeInput.Text);
            tests = Convert.ToInt32(amountInput.Text);

            sheetprice = SHEETS_COST * sheets;
            testprice = TEST_COSTS * tests;
            price = SHEETS_COST * sheets + TEST_COSTS * tests;
            taxAmount = TAX_AMOUNT * price;
            totalWithTax = taxAmount + price;
            
            costOutput.Text = price.ToString("C");
            taxOutput.Text = taxAmount.ToString("C");
            costWithTaxOutput.Text = totalWithTax.ToString("C");
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToInt32(payBox.Text);
            changeDue = amountPaid - totalWithTax;
            changeOutput.Text = changeDue.ToString("C");
        }
        private void receiptButton_Click(object sender, EventArgs e)
        {
            Graphics FormGraphics = this.CreateGraphics();
            Pen firstpen = new Pen(Color.Black, 10);
            Pen Secondpen = new Pen(Color.Maroon, 10);
            SolidBrush drawbrush = new SolidBrush(Color.White);
            SolidBrush Blackbrush = new SolidBrush(Color.Black);
            SolidBrush Redbrush = new SolidBrush(Color.Red);
            SolidBrush titlebrush = new SolidBrush(Color.Maroon);
            Font drawfont = new Font("Consolas", 12, FontStyle.Bold);
            Font titlefont = new Font("Consolas", 27);

            FormGraphics.FillRectangle(drawbrush, 400, 50, 300, 500);
            FormGraphics.DrawLine(firstpen, 400, 50, 700, 50);
            FormGraphics.DrawLine(firstpen, 400, 45, 400, 555);
            FormGraphics.DrawLine(firstpen, 700, 45, 700, 555);
            FormGraphics.DrawLine(firstpen, 400, 550, 700, 550);

            FormGraphics.DrawString("CCS", titlefont, titlebrush, 520, 60);
            FormGraphics.DrawString("Thank you for shopping at CSS", drawfont, Blackbrush, 420, 90);
            FormGraphics.DrawString("Products", drawfont, Blackbrush, 420, 120);
            FormGraphics.DrawString("    Sheets     X" + sheets, drawfont, Blackbrush, 420, 170);
            FormGraphics.DrawString("                       " + sheetprice.ToString("C"), drawfont, Blackbrush, 420, 170);
            FormGraphics.DrawString("    Tests      X" + tests, drawfont, Blackbrush, 420, 190);
            FormGraphics.DrawString("                       " + testprice.ToString("C"), drawfont, Blackbrush, 420, 190);
            FormGraphics.DrawString("Total without tax      " + price.ToString("C"), drawfont, Blackbrush, 420, 250);
            FormGraphics.DrawString("Tax                    " + taxAmount.ToString("C"), drawfont, Blackbrush, 420, 270);
            FormGraphics.DrawString("Total Cost             " + totalWithTax.ToString("C"), drawfont, Blackbrush, 420, 290);
            FormGraphics.DrawString("Tendered               " + amountPaid.ToString("C"), drawfont, Blackbrush, 420, 330);
            FormGraphics.DrawString("Change                 " + changeDue.ToString("C"), drawfont, Blackbrush, 420, 350);
            FormGraphics.DrawString("have a nice day", drawfont, Blackbrush, 480, 450);

        }
            private void resetButton_Click(object sender, EventArgs e)
        {
            Graphics FormGraphics = this.CreateGraphics();
            Pen Secondpen = new Pen(Color.Maroon, 10);
            SolidBrush titlebrush = new SolidBrush(Color.Maroon);

            FormGraphics.FillRectangle(titlebrush, 395, 45, 310, 510);

            costOutput.Text = " ";
            taxOutput.Text = " ";
            costWithTaxOutput.Text = " "; 
            changeOutput.Text = " ";
            payBox.Text = " ";
            gradeInput.Text = " ";
            amountInput.Text = " ";

            tests = 0;
            sheets = 0;
            testprice = 0;
            sheetprice = 0;
            price = 0;
            taxAmount = 0;
            totalWithTax = 0;
            amountPaid = 0;
            changeDue = 0;
        }
    }
}