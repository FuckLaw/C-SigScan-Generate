using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer_SigScan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            txb_generate.Text = "";
            string Mask = "";
            var ListPattern = txb_pattern.Text;
            for(int i = 0; i < ListPattern.Length;i+=3) {
                if(ListPattern[i].ToString() != "?")
                    Mask += "x";
                else
                    Mask += "?";
            }

            txb_generate.AppendText("\\x");

            for (int i = 0; i < ListPattern.Length; i++)
            {
                if (ListPattern[i].ToString() == " ")
                    txb_generate.AppendText("\\x");
                else 
                {
                    if(ListPattern[i].ToString() == "?")
                        txb_generate.AppendText("0");
                    else
                        txb_generate.AppendText(ListPattern[i].ToString());
                }
            }
            txb_generate.AppendText(", " + Mask);
        }
    }
}
