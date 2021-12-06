using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;


namespace BookStore
{
    public partial class Book : Form
    {
        DBSqlUtils conn;
        SqlConnection sqlConnections;
        SqlCommand sqlCommand;
        bool isNew;
        string con = @"Data Source=LAPTOP-751CRMG1;Initial Catalog=OverdoseBook;User ID=Vinh;Password=1";
        SqlDataAdapter dataAdapter=new SqlDataAdapter();
        DataTable tbBook =new DataTable();
        public Book()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void DisplayBook()
        {
            /*myDataServices = new DBSqlUtils();
            string query = "select db.bookid,booktitle,ba.authorid,g.genreid,p.publisherid,language,image,amount from book db join bookauthor ba on db.bookid = ba.bookid join author a on ba.authorid = a.authorid join publisher p on p.publisherid = db.publisherid join genrebook bg on bg.bookid = db.bookid join genre g on g.genreid = bg.genreid";
            DataTable TableBook = myDataServices.RunQuery(query);
            dataGridView4.DataSource = TableBook;
            myDataServices = new DBSqlUtils();*/

            /*sqlCommand = sqlConnections.CreateCommand();
            *//*sqlCommand.CommandText = "select db.bookid,booktitle,ba.authorid,g.genreid,p.publisherid,language,amount from book db join bookauthor ba on db.bookid = ba.bookid join author a on ba.authorid = a.authorid join publisher p on p.publisherid = db.publisherid join genrebook bg on bg.bookid = db.bookid join genre g on g.genreid = bg.genreid";*//*
            sqlCommand.CommandText = "select db.bookid,booktitle,p.publishername,language,amount from book db join bookauthor ba on db.bookid = ba.bookid join author a on ba.authorid = a.authorid join publisher p on p.publisherid = db.publisherid join genrebook bg on bg.bookid = db.bookid join genre g on g.genreid = bg.genreid";
            dataAdapter.SelectCommand = sqlCommand;
            tbBook.Clear();
            dataAdapter.Fill(tbBook);
            dataGridView4.DataSource = tbBook;
            conn = new DBSqlUtils();*/
            conn = new DBSqlUtils();

            string query = "select * from book";
            DataTable TableBook = conn.RunQuery(query);
            dataGridView4.DataSource = TableBook;

        }
        private void DisplayAuthor()
        {
            conn = new DBSqlUtils();
            string query = "select * from author";
            DataTable TableBook = conn.RunQuery(query);
            dataGridView1.DataSource = TableBook;
        }
        private void DisplayGenre()
        {
            conn = new DBSqlUtils();
            string query = "select * from genre";
            DataTable TableBook = conn.RunQuery(query);
            dataGridView2.DataSource = TableBook;
        }
        private void DisplayPublisher()
        {
            conn = new DBSqlUtils();
            string query = "select * from publisher";
            DataTable TableBook = conn.RunQuery(query);
            dataGridView3.DataSource = TableBook;
        }
        private void SetControls(bool edit)
        {
            btnSave.Enabled = edit;
            btnEdit.Enabled = edit;
            btnSave.Enabled = !edit;
            btnCancel.Enabled = !edit;
        }
        private void Enabled(bool edit)
        {
            btnSave.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnCancel.Enabled = !edit;
        }
        private void Enabled12(bool edit)
        {
            txtID.Enabled = !edit;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập Họ đệm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Focus();
                return;
            }
            /*if (txtAuthor.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuthor.Focus();
                return;
            }
            if (txtGenre.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuthor.Focus();
                return;
            }*/
            if (txtPublisher.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPublisher.Focus();
                return;
            }
            if (txtLanguagre.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLanguagre.Focus();
                return;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            if (isNew)
            {
                sqlCommand = sqlConnections.CreateCommand();
                sqlCommand.CommandText = "insert into book(booktitle,publisherid,language,amount,dayadded) values(N'" + txtTitle.Text+ "','" + txtPublisher.Text + "',N'" + txtLanguagre.Text + "','" + txtAmount.Text + "','" + dateTimePicker1.Text + "')";
                sqlCommand.ExecuteNonQuery();
                DisplayBook();
            }
            else
            {
                sqlCommand = sqlConnections.CreateCommand();
                sqlCommand.CommandText = "update book set booktitle='"+txtTitle.Text+"',publisherid='"+txtPublisher.Text+"',language='"+txtLanguagre.Text+"','"+txtAmount.Text+"','"+dateTimePicker1.Text+"'where bookid='"+txtID.Text+"'";
                sqlCommand.ExecuteNonQuery();
                DisplayBook();
            }
            DisplayBook();
            SetControls(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Book_Load(object sender, EventArgs e)
        {
            Enabled(true);
            sqlConnections = new SqlConnection(con);
            sqlConnections.Open();
            DisplayBook();
            DisplayAuthor();
            DisplayGenre();
            DisplayPublisher();
        }
        private void clearall()
        {
            txtID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtPublisher.Clear();
            txtAmount.Clear();
            txtLanguagre.Clear();
            
        }
        private void New_Click(object sender, EventArgs e)
        {
            isNew = true;
            SetControls(false);
            clearall();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Enabled12(true);
            int i;
            i = dataGridView4.CurrentRow.Index;
            txtID.Text= dataGridView4.Rows[i].Cells[0].Value.ToString();
            txtTitle.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            txtPublisher.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            txtLanguagre.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
            txtAmount.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
            Enabled(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            sqlCommand = sqlConnections.CreateCommand();
            sqlCommand.CommandText = "delete from book where bookid='" + txtID.Text + "'";
            /*sqlCommand.CommandText = "delete from bookauthor where authorid='" + txtAuthor.Text + "' AND bookid='" + txtID.Text + "'";
            sqlCommand.CommandText = "delete from genrebook where genreid='" + txtGenre.Text + "' AND bookid='" + txtID.Text + "'";*/
            sqlCommand.ExecuteNonQuery();
            clearall();
            DisplayBook();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtAuthor.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView2.CurrentRow.Index;
            txtGenre.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
        }
    }
}
