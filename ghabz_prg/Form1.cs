using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace ghabz_prg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxAdv1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            lbldate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msktarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msktarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msktarikh3.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");


        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            frmuser frm = new frmuser();
            frm.ShowDialog();
        }
    }
}
