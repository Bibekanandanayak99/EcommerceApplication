using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Proxies;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace EcommerceApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cnf = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

        }


        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            String Name = TextBox3.Text;
            String Email = TextBox4.Text;
            String mobileNo = TextBox11.Text;
            String NewPassword = TextBox5.Text;
            String confirmPassword = TextBox6.Text;
            FileUpload1.SaveAs(Server.MapPath("Profile/") + Path.GetFileName(FileUpload1.FileName));
            String profile = "Profile/" + Path.GetFileName(FileUpload1.FileName);
            String status = "Active";
            String Role = "User";
            Session["UserID"] = Email;

            String q6 = " exec ExistUser '" + Email + "' ";
            SqlCommand cmd = new SqlCommand(q6, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Response.Write("<script>alert('This EmailID is already in our Database please login.')</script>");
            }
            else
            {
                if (NewPassword.Equals(confirmPassword))
                {

                    String q1 = "exec newAccount '" + Name + "', '" + Email + "','" + mobileNo + "', '" + confirmPassword + "', '" + profile + "' , '" + Role + "','" + status + "' ";
                    SqlCommand cmd2 = new SqlCommand(q1, conn);
                    cmd2.ExecuteNonQuery();
                    clear();


                    Response.Write("<script>alert('Regristration successfull')</script>");

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("badalnayak10@gmail.com");
                    mail.To.Add(Email);
                    mail.Subject = "Registration Successful - Welcome to Bhoomika";
                    mail.Body = $@"
                <div style='font-family: Mukta, sans-serif;'>
                    <nav class='navbar navbar-expand-lg navbar-dark bg-dark' style='padding: 10px; background-color: #333;'>
                        <a class='navbar-brand' href='#' style='font-size: 1.8rem; color: #ffdf00; text-decoration: none;'>
                            भूमिka
                            <span class='tagline' style='font-size: 1.2rem; color: #ffdf00;'>creates a woman</span>
                        </a>
                    </nav>

                    <div style='padding: 20px;'>
                        <h2 style='color: #d4af37;'>Welcome to Bhoomika!</h2>
                        <p style='font-size: 1.1rem;'>Thank you, <strong>{Name}</strong>, for registering with Bhoomika.</p>
                        <p>We are excited to have you as part of our community. Your registered email is: <strong>{Email}</strong></p>
                        <p>You can now explore our services and be part of our mission to empower women.</p>
                    </div>
                </div>

                <style>
                    @keyframes glow {{
                    from {{
                            text-shadow: 0 0 10px #ffdf00, 0 0 20px #ffdf00;
                        }}
                        to {{
                            text-shadow: 0 0 20px #f5d76e, 0 0 30px #ffdf00;
                        }}
                    }}

                    .navbar-brand {{
                        font - size: 1.8rem;
                        animation: glow 1.5s infinite alternate;
                    }}
                </style>";

                    mail.IsBodyHtml = true;


                    SmtpClient mailClient = new SmtpClient("smtp.gmail.com");
                    mailClient.Port = 587;
                    mailClient.Credentials = new NetworkCredential("badalnayak10@gmail.com", "fqpwvymsfurbkqxg");
                    mailClient.EnableSsl = true;

                    try
                    {
                        mailClient.Send(mail);
                        Response.Write("<script>alert('A confirmation mail is sent to your Registered Email.')</script>");

                    }
                    catch (Exception ex)
                    {

                        Response.Write($"<script>alert('Error sending email: {ex.Message}')</script>");



                    }

                }

                else
                {
                    Response.Write("<script>alert('Regristration failded, Tray again.')</script>");

                }

            }


            

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String Email = TextBox1.Text;
            String Password = TextBox2.Text;


            String q2 = "exec LoginAccount '" + Email + "', '" + Password + "'";
            SqlCommand cmd = new SqlCommand(q2, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["UserEmail"].Equals(Email) && reader["UserPassword"].Equals(Password) && reader["UserRole"].Equals("Admin"))
                    {
                        Session["Name"] = reader["UserNmae"].ToString();
                        Session["EmailID"] = reader["UserEmail"].ToString();
                        if (reader["UserStatus"].Equals("Active"))
                        {
                            Response.Redirect("AddProduct.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Incorrect EmailID or Password.')</script>");

                        }

                    }

                    if (reader["UserEmail"].Equals(Email) && reader["UserPassword"].Equals(Password) && reader["UserRole"].Equals("User"))
                    {
                        Session["Name"] = reader["UserNmae"].ToString();
                        Session["EmailID"] = reader["UserEmail"].ToString();
                        if (reader["UserStatus"].Equals("Active"))
                        {
                            Response.Redirect("UserAllProducts.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Your Account is Temporary blocked');</script>");


                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect EmailID or Password.');</script>");
                    }
                }
            }
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            String Email = TextBox7.Text;
            String Otp = GenerateOTP();
            Session["OTP"] = Otp;
            sendOTP(Email, Otp);


            Session["Email"] = Email;

        }


        protected String GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        public void sendOTP(String tomail, String otp)
        {
            String q3 = "SELECT UserNmae FROM BhoomikaAccounts WHERE UserEmail = @Email";
            SqlCommand cmd = new SqlCommand(q3, conn);
            cmd.Parameters.AddWithValue("@Email", tomail);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); // Read the first record
                String Name = reader["UserNmae"].ToString().Trim(); // Correct column name

                reader.Close(); // Close reader before sending email

                // Send OTP email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("badalnayak10@gmail.com");
                mailMessage.To.Add(tomail);
                mailMessage.Subject = "OTP for Verification";
                mailMessage.Body = $@"
            <div style='font-family: Mukta, sans-serif;'>
                <nav class='navbar navbar-expand-lg navbar-dark bg-dark' style='padding: 10px; background-color: #333;'>
                    <a class='navbar-brand' href='#' style='font-size: 1.8rem; color: #ffdf00; text-decoration: none;'>
                        भूमिka
                        <span class='tagline' style='font-size: 1.2rem; color: #ffdf00;'>creates a woman</span>
                    </a>
                </nav>

                <div style='padding: 20px;'>
                    <h2 style='color: #d4af37;'>Welcome to Bhoomika!</h2>
                    <p style='font-size: 1.1rem;'>Thank you, <strong>{Name}</strong>, for registering with Bhoomika.</p>
                    <p>We are excited to have you as part of our community. Your registered email is: <strong>{tomail}</strong></p>
                    <p>Your One Time Password (OTP) for verification is: <strong>{otp}</strong></p>
                </div>
            </div>

            <style>
                @keyframes glow {{
                from {{ 
                        text-shadow: 0 0 10px #ffdf00, 0 0 20px #ffdf00;
                    }}
                    to {{
                        text-shadow: 0 0 20px #f5d76e, 0 0 30px #ffdf00;
                    }}
                }}

                .navbar-brand {{
                    font-size: 1.8rem;
                    animation: glow 1.5s infinite alternate;
                }}
            </style>";

                mailMessage.IsBodyHtml = true;

                SmtpClient mailClient = new SmtpClient("smtp.gmail.com");
                mailClient.Port = 587;
                mailClient.Credentials = new NetworkCredential("badalnayak10@gmail.com", "fqpwvymsfurbkqxg");
                mailClient.EnableSsl = true;

                try
                {
                    mailClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error sending email: {ex.Message}')</script>");
                }
            }
            else
            {
                reader.Close();
                Response.Write("<script>alert('No user found with the provided email.')</script>");
            }
        }

        protected void VerifyOTP(object sender, EventArgs e)
        {
            String Uotp = TextBox8.Text;
            String Eotp = Session["OTP"].ToString();
            if (Uotp != null)
            {

                if (Uotp.Equals(Eotp))
                {

                    Response.Write("<script>alert('OTP verification successfull.')</script>");
                    
                }
                else
                {
                    Response.Write("<script>alert('Incorrect OTP.')</script>");
                }
            }

        }

        protected void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox9.Text = string.Empty;
        }

        protected void ForgetPassword_Click(object sender, EventArgs e)
        {
            String NewPassword = TextBox9.Text;
            String ConfirmPassword = TextBox10.Text;

            if (!string.IsNullOrEmpty(NewPassword) && NewPassword.Equals(ConfirmPassword))
            {
                String usermail = Session["Email"].ToString();
                bool updateSuccessful =  UpdateUserPassword(usermail, NewPassword);

                if (updateSuccessful)
                {
                    Response.Write("<script>alert('Password updated successfully.')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Error updating password.')</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Passwords do not match or are empty.')</script>");
            }
        }
        protected bool UpdateUserPassword(string userEmail, string newPassword)
        {

            String q4 = "exec ResetPassword '" + userEmail + "', '" + newPassword + "'";
            return true;

        }
    }
}