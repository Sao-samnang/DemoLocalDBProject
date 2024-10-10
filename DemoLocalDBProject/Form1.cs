using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DemoLocalDBProject
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        string ID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string SQLCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Coding\\C# Programming\\Learn With Teacher\\DemoLocalDBProject\\DemoLocalDBProject\\Database1.mdf\";Integrated Security=True";
            try
            {
                conn = new SqlConnection(SQLCon);
                conn.Open();
            }catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtid.Text==""&& txtname.Text == "" && txtgender.Text == "")
            {
                MessageBox.Show("Please input data.!");
            }
            else
            {
                string sql="Insert Into tbl_student(ID,Name,gender,DOB) values('" + txtid.Text + "'," +"'" + txtname.Text + "','" + txtgender.Text + "','" + txtdob.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("One record added!");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string sql = "select *from tbl_student";
            SqlCommand comd= new SqlCommand(sql, conn);
            SqlDataAdapter sqlAd= new SqlDataAdapter(comd);
            //---- data table
            DataTable tbl=new DataTable();
            sqlAd.Fill(tbl);
            dataGrideStu.DataSource=tbl;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from tbl_student where id='" + txtid.Text + "'";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            sqlCom.ExecuteNonQuery();
            MessageBox.Show("One record delete");
        }

        private void dataGrideStu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Enabled = false;
            txtid.Text = dataGrideStu.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGrideStu.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgender.Text = dataGrideStu.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdob.Text = dataGrideStu.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update tbl_student set name='" + txtname.Text + "', gender='"+txtgender.Text+"', DOB='"+txtdob.Text+"' where id='"+txtid.Text+"'";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            sqlCom.ExecuteNonQuery();
            MessageBox.Show("One record updated..!");
        }
    }
}
