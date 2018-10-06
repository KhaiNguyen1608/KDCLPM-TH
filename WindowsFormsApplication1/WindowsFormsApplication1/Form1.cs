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
            this.FormClosing += Form1_Closing;
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /*private void Form1_Closing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                // Assume that X has been clicked and act accordingly.
                // Confirm user wants to close
                switch (MessageBox.Show(this, "Are you sure?", "Do you still want ... ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }*/
        /*private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (textBox1.Text != strMyOriginalText)
            {
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }*/
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
        }
        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        private void Checkbtn_Click(object sender, EventArgs e)
        {
            int parsedValue;
            string year = txtYear.Text.ToString();
            string month = txtMonth.Text.ToString();
            string day = txtDay.Text.ToString();

            int y = int.Parse(txtYear.Text.ToString());
            int m = int.Parse(txtMonth.Text.ToString());
            int d = int.Parse(txtDay.Text.ToString());

            if (String.IsNullOrEmpty(txtDay.Text.ToString()) || String.IsNullOrEmpty(txtMonth.Text.ToString()) || String.IsNullOrEmpty(txtYear.Text.ToString()))
                MessageBox.Show("Fill full information");
            else if (!int.TryParse(txtDay.Text, out parsedValue) && int.TryParse(txtMonth.Text, out parsedValue) && int.TryParse(txtYear.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            else
            {
                if ((d < 1 || d > 31) || (m > 12 || m < 1) || (y < 1900))
                {
                    MessageBox.Show("Failed");
                    return;
                }
                else
                {
                    if ((m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) && (d <= 31 && d > 0))
                    {
                        MessageBox.Show("Success");
                        return;
                    }
                    else if ((m == 4 || m == 6 || m == 9 || m == 11 && (d <= 30 && d > 0)))
                    {
                        MessageBox.Show("Success");
                        return;
                    }
                    else if (m == 2) 
                    {
                        if ((((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0)) && (d < 30 && d > 0)) 
                        {
                            MessageBox.Show("Successful");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Successful");
                        return;
                    }
                }

            }
        }
    }
}