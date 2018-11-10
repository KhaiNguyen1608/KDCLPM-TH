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
            if (MessageBox.Show("Bạn muốn thoát chứ?", "Kết thúc", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
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



        public int DayslnMonth(short year, byte month)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }
            else
                if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else if (month == 2)
            {
                if (year % 400 == 0)
                    return 29;
                else if (year % 100 == 0)
                    return 28;
                else if (year % 4 == 0)
                    return 29;
                else return 28;
            }
            else
            return 0;
        }


        public bool IsValidDate(byte day, byte month, short year)
        {
            if (month >= 1 && month <= 12)
            {
                if (day >= 1)
                {
                    if (day <= DayslnMonth(year, month))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        //private bool IsValidDate(short year, byte day, byte month)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool CheckInputValidDate(string day)
        {
            int num = 0;

            if (!int.TryParse(day, out num))
                return false;
            else
                return true;
        }

        public static bool CheckInputValidMonth(string month)
        {
            int num = 0;

            if (!int.TryParse(month, out num))
                return false;
            else
                return true;
        }

        public static bool CheckInputValidYear(string year)
        {
            int num = 0;

            if (!int.TryParse(year, out num))
                return false;
            else
                return true;
        }

        public static bool CheckRangDate(string day)
        {
            if (int.Parse(day) < 1 || int.Parse(day) > 31)
                return false;
            else
                return true;
        }

        public static bool CheckRangMonth(string month)
        {
            if (int.Parse(month) < 1 || int.Parse(month) > 12)
                return false;
            else
                return true;
        }


        public static bool CheckRangYear(string year)
        {
            if (int.Parse(year) < 1000 || int.Parse(year) > 3000)
                return false;
            else
                return true;
        }

        private void Checkbtn_Click(object sender, EventArgs e)
        {
            string day = txtDay.Text.ToString();
            string month = txtMonth.Text.ToString();
            string year = txtYear.Text.ToString();
      
  

            if (!CheckInputValidDate(day))
            {
                MessageBox.Show("Input data for Day is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!CheckRangDate(day))
            {
                MessageBox.Show("Input data for Day is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (!CheckInputValidMonth(month))
            {
                MessageBox.Show("Input data for Month is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!CheckRangMonth(month))
            {
                MessageBox.Show("Input data for Month is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (!CheckInputValidYear(year))
            {
                MessageBox.Show("Input data for Year is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!CheckRangYear(year))
            {
                MessageBox.Show("Input data for Year is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (IsValidDate(byte.Parse(month), byte.Parse(day), short.Parse(year)))
            {
                MessageBox.Show("dd//mm/yy is correct datetime!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                MessageBox.Show("dd//mm/yy is incorrect datetime!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

           
            //int parsedValue;
            //string year = txtYear.Text.ToString();
            //string month = txtMonth.Text.ToString();
            //string day = txtDay.Text.ToString();

            //int y = int.Parse(txtYear.Text.ToString());
            //int m = int.Parse(txtMonth.Text.ToString());
            //int d = int.Parse(txtDay.Text.ToString());

            //if (String.IsNullOrEmpty(txtDay.Text.ToString()) || String.IsNullOrEmpty(txtMonth.Text.ToString()) || String.IsNullOrEmpty(txtYear.Text.ToString()))
            //    MessageBox.Show("Fill full information");
            //else if (!int.TryParse(txtDay.Text, out parsedValue) && int.TryParse(txtMonth.Text, out parsedValue) && int.TryParse(txtYear.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
            //else
            //{
            //    if ((d < 1 || d > 31) || (m > 12 || m < 1) || (y < 1900))
            //    {
            //        MessageBox.Show("Failed");
            //        return;
            //    }
            //    else
            //    {
            //        if ((m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) && (d <= 31 && d > 0))
            //        {
            //            MessageBox.Show("Success");
            //            return;
            //        }
            //        else if ((m == 4 || m == 6 || m == 9 || m == 11 && (d <= 30 && d > 0)))
            //        {
            //            MessageBox.Show("Success");
            //            return;
            //        }
            //        else if (m == 2) 
            //        {
            //            if ((((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0)) && (d < 30 && d > 0)) 
            //            {
            //                MessageBox.Show("Successful");
            //                return;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Failed");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Successful");
            //            return;
            //        }
            //    }

            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}