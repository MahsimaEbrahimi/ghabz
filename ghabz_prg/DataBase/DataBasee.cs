using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Data;


namespace ghabz_prg.DataBase.DataBasee
{



    class DataBasee
    {
        private string connectionString = "data source=MSI;initial catalog=GHABZDB99;integrated security=SSPI;AttachDBFilename=|DataDirectory|\\GHABZDB99.mdf";


        public bool add_user(Person p)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(connectionString);
            cmd.Parameters.Clear();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "insert into Tbluser(Name,CodeM,UserName,Password,AddUser,Deluser,Upuser,Lkontor,Addkontor,Delkontor,Upkontor,LMoshtarak,AddMoshtarak,DelMoshtarak,UpMoshtarak,LTarefeh,AddTarefeh,DellTarefeh,UpTarefeh,LGhabz,AddGhabz,DelGhabz,UpGhabz,Lpardakht,Addpardakht,Delpardakht,Uppardakht,BK,RS,SMS)values(@Name,@CodeM,@UserName,@Password,@AddUser,@Deluser,@Upuser,@Lkontor,@Addkontor,@Delkontor,@Upkontor,@LMoshtarak,@AddMoshtarak,@DelMoshtarak,@UpMoshtarak,@LTarefeh,@AddTarefeh,@DellTarefeh,@UpTarefeh,@LGhabz,@AddGhabz,@DelGhabz,@UpGhabz,@Lpardakht,@Addpardakht,@Delpardakht,@Uppardakht,@BK,@RS,@SMS)";
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@CodeM", p.CodeM);
                cmd.Parameters.AddWithValue("@UserName", p.UserName);
                cmd.Parameters.AddWithValue("@password", p.Password);

                cmd.Parameters.AddWithValue("@AddUser", p.AddUser);
                cmd.Parameters.AddWithValue("@Deluser", p.Deluser);
                cmd.Parameters.AddWithValue("@Upuser", p.Upuser);

                cmd.Parameters.AddWithValue("@Lkontor", p.Lkontor);
                cmd.Parameters.AddWithValue("@Addkontor", p.Addkontor);
                cmd.Parameters.AddWithValue("@Delkontor", p.Delkontor);
                cmd.Parameters.AddWithValue("@Upkontor", p.Upkontor);

                cmd.Parameters.AddWithValue("@LMoshtarak", p.LMoshtarak);
                cmd.Parameters.AddWithValue("@AddMoshtarak", p.AddMoshtarak);
                cmd.Parameters.AddWithValue("@DelMoshtarak", p.DelMoshtarak);
                cmd.Parameters.AddWithValue("@UpMoshtarak", p.UpMoshtarak);

                cmd.Parameters.AddWithValue("@LTarefeh", p.LTarefeh);
                cmd.Parameters.AddWithValue("@AddTarefeh", p.AddTarefeh);
                cmd.Parameters.AddWithValue("@DellTarefeh", p.DellTarefeh);
                cmd.Parameters.AddWithValue("@UpTarefeh", p.UpTarefeh);

                cmd.Parameters.AddWithValue("@LGhabz", p.LGhabz);
                cmd.Parameters.AddWithValue("@AddGhabz", p.AddGhabz);
                cmd.Parameters.AddWithValue("@DelGhabz", p.DelGhabz);
                cmd.Parameters.AddWithValue("@UpGhabz", p.UpGhabz);

                cmd.Parameters.AddWithValue("@Lpardakht", p.Lpardakht);
                cmd.Parameters.AddWithValue("@Addpardakht", p.Addpardakht);
                cmd.Parameters.AddWithValue("@Delpardakht", p.Delpardakht);
                cmd.Parameters.AddWithValue("@Uppardakht", p.Uppardakht);

                cmd.Parameters.AddWithValue("@BK", p.BK);
                cmd.Parameters.AddWithValue("@RS", p.RS);
                cmd.Parameters.AddWithValue("@SMS", p.SMS);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("ثبت انجام شد");
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        //show contents on data grid view
        public DataSet put_in_gridview()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "Select Name,CodeM,UserName,Password from Tbluser";
                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.Fill(ds, "Tbluser");
                return ds;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //delete user by clicking delete buttom
        public void delete(Person p)
        {
            SqlConnection con = new SqlConnection(connectionString);
            if (p.CodeM == "")
            {
                MessageBox.Show("کد ملی وارد نشده است");
                return;
            }
            string query = "Delete from Tbluser where CodeM = @CODE and Name=@NAME and UserName=@USERNAME and password=@PASSWOED";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CODE", p.CodeM);
            cmd.Parameters.AddWithValue("@NAME", p.Name);
            cmd.Parameters.AddWithValue("@USERNAME", p.UserName);
            cmd.Parameters.AddWithValue("@PASSWOED", p.Password);

            con.Open();
            var result = cmd.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show("حذف انجام شد");
                put_in_gridview();
            }
            else
            {
                MessageBox.Show("!کاربر یافت نشد");
            }
            con.Close();

        }

        //
        public DataSet Find_user(string CodeM)
        {
            string query = "Select * From Tbluser Where CodeM = " + CodeM;
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter Adapter = new SqlDataAdapter(query, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            return data;



        }
    }
}
