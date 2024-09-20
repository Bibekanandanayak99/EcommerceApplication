using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceApplication
{
    public partial class ProductList : System.Web.UI.Page
    {

        SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cnf = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            _connection = new SqlConnection(cnf);
            _connection.Open();

            if (!IsPostBack)
            {
                getData();
            }

        }

        protected void getData()
        {
            String q1 = "Select * From AddProducts";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(q1, _connection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label l1 = (Label)GridView1.Rows[e.RowIndex].FindControl("ID"); 
            String ProductID = l1.Text;

            String q2 = $"delete from AddProducts where ProductID= @ID";
            SqlCommand cmd2 = new SqlCommand(q2, _connection);
            cmd2.Parameters.AddWithValue("@ID", ProductID);

            cmd2.ExecuteNonQuery();
            getData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("EditIndex: " + e.NewEditIndex);
            GridView1.EditIndex = e.NewEditIndex;
            getData(); 
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label le = (Label)GridView1.Rows[e.RowIndex].FindControl("ID");
            String ProductID = le.Text;

            TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("ProductNameTextBox");
            String ProductName = Name.Text;

            TextBox Details = (TextBox)GridView1.Rows[e.RowIndex].FindControl("DescriptionTextBox");
            String DetailsProduct = Details.Text;

            TextBox Price = (TextBox)GridView1.Rows[e.RowIndex].FindControl("PriceTextBox");
            String PriceProduct = Price.Text;

            TextBox Category = (TextBox)GridView1.Rows[e.RowIndex].FindControl("CategoryTextBox");
            String CategoryProduct = Category.Text;

            System.Diagnostics.Debug.WriteLine("ProductID: " + ProductID);
            System.Diagnostics.Debug.WriteLine("ProductName: " + ProductName);
            System.Diagnostics.Debug.WriteLine("DetailsProduct: " + DetailsProduct);
            System.Diagnostics.Debug.WriteLine("PriceProduct: " + PriceProduct);
            System.Diagnostics.Debug.WriteLine("CategoryProduct: " + CategoryProduct);


            String query = "UPDATE AddProducts SET ProductName = @ProductName, ProductDescription = @ProductDescription, ProductPrice = @ProductPrice, ProductCategory = @ProductCategory WHERE ProductID = @ProductID";
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@ProductDescription", DetailsProduct);
            cmd.Parameters.AddWithValue("@ProductPrice", PriceProduct);
            cmd.Parameters.AddWithValue("@ProductCategory", CategoryProduct);
            cmd.ExecuteNonQuery();

            GridView1.EditIndex = -1;

            getData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            GridView1.EditIndex = -1;
            getData();
        }


    }
}