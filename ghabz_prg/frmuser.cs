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
using System.Data.SqlClient;

namespace ghabz_prg
{
    public partial class frmuser : Form
    {
        DataBase.DataBasee.DataBasee database = new DataBase.DataBasee.DataBasee();

        public frmuser()
        {
            InitializeComponent();
        }

        public void display()
        {
            
            dataGridView1.DataSource = database.put_in_gridview();
            dataGridView1.DataMember = "Tbluser";
            dataGridView1.Columns[0].HeaderText = "نام و نام خانوادگی";
            dataGridView1.Columns[1].HeaderText = "کد ملی";
            dataGridView1.Columns[2].HeaderText = "نام کاربری";
            dataGridView1.Columns[3].HeaderText = "کلمه عبور";
        }
        private void frmuser_Load(object sender, EventArgs e)
        {
            display();
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkall.Checked)
            {
                foreach (CheckBox c in panel1.Controls)
                {
                    c.Checked = true;
                }
            }
            if (chkall.Checked != true)
            {
                foreach (CheckBox c in panel1.Controls)
                {
                    c.Checked = false;
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            Person p = new Person();
            p.Name = txtname.Text;
            p.CodeM = txtcodemelli.Text;
            p.UserName = txtusername.Text;
            p.Password = txtpassword.Text;
            p.AddUser = chkadduser.Checked;
            p.Deluser = chkdeluser.Checked;
            p.Upuser = chkupdateuser.Checked;
            p.Lkontor = chklistcontor.Checked;
            p.Addkontor = chkaddkontor.Checked;
            p.Delkontor = chkdelkontor.Checked;
            p.Upkontor = chkupdatekontor.Checked;
            p.LMoshtarak = chklistmoshtarak.Checked;
            p.AddMoshtarak = chkaddmoshtarak.Checked;
            p.DelMoshtarak = chkdelmoshtarak.Checked;
            p.UpMoshtarak = chkupdatemoshtarak.Checked;
            p.LTarefeh = chklisttarefeh.Checked;
            p.AddTarefeh = chkaddtarefeh.Checked;
            p.DellTarefeh = chkdeltarefeh.Checked;
            p.UpTarefeh = chkupdatetarefeh.Checked;
            p.LGhabz = chklistghabz.Checked;
            p.AddGhabz = chkaddghabz.Checked;
            p.DelGhabz = chkdelghabz.Checked;
            p.UpGhabz = chkupdateghabz.Checked;
            p.Lpardakht = chklistPR.Checked;
            p.Addpardakht = chkaddPR.Checked;
            p.Delpardakht = chkdelPR.Checked;
            p.Uppardakht = chkUpdatePR.Checked;
            p.BK = chkUpdate.Checked;
            p.RS = chkRs.Checked;
            p.SMS = chkSMS.Checked;
            database.add_user(p);

            display();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = txtname.Text;
            p.UserName = txtusername.Text;
            p.Password = txtpassword.Text;
            p.CodeM = txtcodemelli.Text;
            database.delete(p);
            display();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtname.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtcodemelli.Text = dataGridView1.CurrentRow.Cells["CodeM"].Value.ToString();
            txtpassword.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
            txtusername.Text = dataGridView1.CurrentRow.Cells["UserName"].Value.ToString();
        }
    }
}
