using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace modul3_kel60
{
    public partial class ListItems : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-ACA\\SQLEXPRESS ;Initial Catalog = mod3_perc2_kel60; Integrated Security = True";
            con.Open();
            if (!Page.IsPostBack)
            {
                DataShow();
            }
        }
        public void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "Select * from Buku";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
            con.Close();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Insert Into Buku(ID_Buku, Judul, Genre, Rilis)values('" + txtIdBuku.Text + "', '" + txtJudul.Text.ToString() + "', '" + txtGenre.Text.ToString() + "','" + txtRilis.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Update Buku set Judul='" + txtJudul.Text.ToString() + "',  Genre = '" + txtGenre.Text.ToString() + "', Rilis = '" + txtRilis.Text + "' WHERE ID_Buku = '" + txtIdBuku.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Delete from Buku where ID_Buku='" + txtIdBuku.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtGenre.Text = null;
            txtIdBuku.Text = null;
            txtJudul.Text = null;
            txtRilis.Text = null;
        }
    }
}
