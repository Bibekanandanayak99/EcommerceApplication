using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceApplication
{
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cnf = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            connection = new SqlConnection(cnf);
            connection.Open();  


        }

        protected void SaveProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                String ProductPhoto = "Product/" + Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("Product/") + Path.GetFileName(FileUpload1.FileName));

                String ProductName = ProductNameTextBox.Text;
                Decimal price;

                if (!Decimal.TryParse(Price.Text, out price))
                {
                    Response.Write("<script>alert('Invalid price format. Please enter a valid number.')</script>");
                    return;
                }

                String ProductDetails = Description.Text;
                String Category = CategoryDropDown.SelectedValue;

                Response.Write($"<script>console.log('Product Name: {ProductName}');</script>");
                Response.Write($"<script>console.log('Category: {Category}');</script>");
                Response.Write($"<script>console.log('Product Details: {ProductDetails}');</script>");
                Response.Write($"<script>console.log('Price: {price}');</script>");
                Response.Write($"<script>console.log('Product Photo: {ProductPhoto}');</script>");

                String q1 = "insert into AddProducts (ProductName, ProductCategory, ProductDescription, ProductPrice, ProductPhoto) " +
                            "values (@Name, @Category, @Description, @Price, @Photo)";
                SqlCommand cmd2 = new SqlCommand(q1, connection);

                cmd2.Parameters.AddWithValue("@Name", ProductName);
                cmd2.Parameters.AddWithValue("@Category", Category);
                cmd2.Parameters.AddWithValue("@Description", ProductDetails);
                cmd2.Parameters.AddWithValue("@Price", price);
                cmd2.Parameters.AddWithValue("@Photo", ProductPhoto);

                cmd2.ExecuteNonQuery();
                Response.Write("<script>alert('Product added successfully.')</script>");
            }
            catch (SqlException ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
            }
        }
    }
}