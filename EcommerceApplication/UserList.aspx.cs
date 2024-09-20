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
    public partial class UserList : System.Web.UI.Page
    {

        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cnf = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                fetchUsers();
            }
        }

        public void fetchUsers()
        {
            String Role = "User";
            String q1 = "exec FetchData '"+Role+"' ";
            SqlDataAdapter adapter = new SqlDataAdapter(q1, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String id = e.CommandArgument.ToString();
            String q = "select * from BhoomikaAccounts where id= '" + id + "' ";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            String status = reader["UserStatus"].ToString();

            String q2;
            if (status.Equals("Active"))
            {
                q2 = "exec BlockUser @Status = 'Blocked', @ID= '" + id + "'";
            }
            else
            {
                q2 = "exec BlockUser @Status = 'Active', @ID= '" + id + "'";
            }

            SqlCommand cmd2 = new SqlCommand(q2, conn);
            cmd2.ExecuteNonQuery();
            fetchUsers();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = (Button)e.Row.FindControl("Button1");
                if (btn != null)
                {
                    String Status = DataBinder.Eval(e.Row.DataItem, "UserStatus").ToString();

                    if (Status.Equals("Active"))
                    {
                        btn.Text = "Block";

                    }
                    else
                    {
                        btn.Text = "Unblock";
                    }
                }

            }
        }

        
    }
}