using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            { 
           // try
           // {
                decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                int years = Convert.ToInt32(txtYears.Text);

                int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                decimal futureValue = this.CalculateFutureValue(
                    monthlyInvestment, monthlyInterestRate, months);
                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
           // }
           // catch (FormatException)
           // {

            //    MessageBox.Show("please enter a valid number", "Error");
           // }
           // catch (OverflowException ex)
            //{
              //  MessageBox.Show(ex.Message + "\n\n" +
              //      ex.GetType().ToString() + "\n\n" +
              //      ex.StackTrace, "Exception");
           // }
        }
        }
            


        private decimal CalculateFutureValue(decimal monthlyInvestment, 
            decimal monthlyInterestRate, int months)
        {
            //throw new Exception("unknown error");

            decimal futureValue = 0m;
                for (int i = 0; i < months; i++)
                {
                    futureValue = (futureValue + monthlyInvestment)
                                * (1 + monthlyInterestRate);
                }
                return futureValue;
            
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.",
                    "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }


        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(
                    name + " must be a decimal value.",
                    "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
    decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " +
                    min.ToString() + " and " + max.ToString() +
                    ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsValidData()
        {
            // Validate the Monthly Investment text box
            if (!IsPresent(txtMonthlyInvestment, "Monthly Investment"))
                return false;
            if (!IsDecimal(txtMonthlyInvestment, "Monthly Investment"))
                return false;
            if (!IsWithinRange(txtMonthlyInvestment,
                    "Monthly Investment", 1, 1000))
                return false;

            // Validate the Interest Rate text box
            if (!IsPresent(txtInterestRate, "Interest Rate"))
                return false;
            if (!IsDecimal(txtInterestRate, "Interest Rate"))
                return false;
            if (!IsWithinRange(txtInterestRate, "Interest Rate", 1, 20))
                return false;

            // Validate the number of yers text box
            if (!IsPresent(txtYears, "Interest Rate"))
                return false;
            if (!IsDecimal(txtYears, "Interest Rate"))
                return false;
            if (!IsWithinRange(txtYears, "Interest Rate", 1, 20))
                return false;
            return true;
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}