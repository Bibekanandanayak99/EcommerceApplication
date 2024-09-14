using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceApplication
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {


            String cnf = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            connection = new SqlConnection(cnf);
            connection.Open();

            if(Session["EmailID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            String q1 = "Select UserNmae from BhoomikaAccounts where UserEmail = @Email ";
            SqlCommand cmd = new SqlCommand(q1, connection);
            cmd.Parameters.AddWithValue("@Email", Session["EmailID"]);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                Label1.Text = r["UserNmae"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Your need to login agai!.');window.location.herf='Login.aspx'</script>");

            }

            if (!IsPostBack)
            {
                fetchData();
            }


        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");


        }

        public void fetchData()
        {
            String q5 = "exec  getData @Email=@Email";
            SqlCommand sqlCommand = new SqlCommand(q5, connection);
            sqlCommand.Parameters.AddWithValue("@Email", Session["EmailID"]);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Save Changes")
            {
                String Userid = e.CommandArgument.ToString();
                TextBox txtName = (TextBox)e.Item.FindControl("TextBoxName");
                TextBox txtEmail = (TextBox)e.Item.FindControl("TextBoxEmail");
                TextBox txtPhone = (TextBox)e.Item.FindControl("TextBoxPhone");
                FileUpload fileUpload = (FileUpload)e.Item.FindControl("FileUploadProfilePic");


                string updatedName = txtName.Text;
                string updatedEmail = txtEmail.Text;
                string updatedPhone = txtPhone.Text;
                string updatedPhotoPath = "";

                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    updatedPhotoPath = "Profile/" + fileName;
                    fileUpload.SaveAs(Server.MapPath("~/Profile/") + fileName);
                }


                string updateQuery;
                if (string.IsNullOrEmpty(updatedPhotoPath))
                {
                    updateQuery = "UPDATE BhoomikaAccounts SET UserNmae = @Name, UserEmail = @Email, UserNumber = @Phone WHERE id = @UserID";
                }
                else
                {
                    updateQuery = "UPDATE BhoomikaAccounts SET UserNmae = @Name, UserEmail = @Email, UserNumber = @Phone, UserPhoto = @Photo WHERE id = @UserID";
                }
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Name", updatedName);
                cmd.Parameters.AddWithValue("@Email", updatedEmail);
                cmd.Parameters.AddWithValue("@Phone", updatedPhone);
                cmd.Parameters.AddWithValue("@Photo", updatedPhotoPath);
                cmd.Parameters.AddWithValue("@UserID", Userid);

                cmd.ExecuteNonQuery();

                fetchData();
            }
        }
    }
}