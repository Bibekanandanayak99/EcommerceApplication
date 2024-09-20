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
    public partial class DeleteUser : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cnf= ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                fetchProfile();
            }
        }

        protected void fetchProfile()
        {
            String email = Session["EmailID"].ToString();
            String q1 = "exec getData '" + email + "'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(q1, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
               String email= e.CommandArgument.ToString().Trim();
               String q2 = "exec DeleteData '" + email + "'";
                SqlCommand cmd = new SqlCommand(q2, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('accound deted successfully.');window.location.href='Login.aspx';</script>");

            }
        }
    }
}