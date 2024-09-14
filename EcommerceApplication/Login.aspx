<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EcommerceApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>भूमिka - Creates a Woman</title>
    <link rel="icon" type="image/x-icon" href="favicon.ico">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        body {
            font-family: 'Arial', sans-serif;
            background: linear-gradient(to right, #f5d76e, #f7ca18); /* Golden gradient */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
            width: 400px;
            text-align: center;
            position: relative;
        }

        h1 {
            font-size: 2.5rem;
            color:#FF0000; 
            margin-bottom: 10px;
            text-transform: uppercase;
            animation: glow 1.5s infinite alternate;
        }

        .tagline {
            font-size: 1.2rem;
            color: #FF0000;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            float: left;
            color: #333;
            font-weight: bold;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
        }

        .btn-primary, .btn-secondary {
            width: 100%;
            padding: 10px;
            background-color: #d4af37; 
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 1.2rem;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-primary:hover, .btn-secondary:hover {
            background-color: #f5d76e; 
        }

        .forgot-password {
            display: block;
            margin-top: 10px;
            font-size: 0.9rem;
            color: #d4af37;
            text-decoration: none;
            animation: glow 1.5s infinite alternate;
        }

        @keyframes glow {
            from {
                text-shadow: 0 0 10px #f5d76e, 0 0 20px #f7ca18, 0 0 30px #f5d76e;
            }
            to {
                text-shadow: 0 0 20px #f7ca18, 0 0 30px #d4af37, 0 0 40px #f7ca18;
            }
        }

        #loginForm, #registerForm {
            display: none;
        }
    </style>

    <script>
        function showLoginForm() {
            document.getElementById("loginForm").style.display = "block";
            document.getElementById("registerForm").style.display = "none";
        }

        function showRegisterForm() {
            document.getElementById("registerForm").style.display = "block";
            document.getElementById("loginForm").style.display = "none";
        }
    </script>

</head>
<body>
    <form id="mainForm" runat="server">
        <div class="login-container">
            <h1>भूमिka</h1>
            <div class="tagline">Creates a Woman</div>
            
            
            <div id="startButtons">
                <asp:Button ID="Button1" class="btn-primary" runat="server" Text="Login" OnClientClick="showLoginForm(); return false;" />
                <br /><br />
                <asp:Button ID="Button2" class="btn-secondary" runat="server" Text="Sign Up" OnClientClick="showRegisterForm(); return false;"  />
            </div>

            <!-- Login Form -->
            For Existing User.
            <div id="loginForm">
                <div class="form-group">
                    <label for="TextBox1">Email address</label>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Enter your Email" TextMode="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox2">Password</label>
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="LoginButton" class="btn-primary" runat="server" Text="Login" OnClick="LoginButton_Click" />
                <a href="#" data-toggle="modal" data-target="#exampleModal" class="forgot-password">Forget password?</a>
            </div>

            <!-- Register Form -->
            <div id="registerForm">
                <div class="form-group">
                    <label for="TextBox3">Full Name</label>
                    <asp:TextBox ID="TextBox3" class="form-control" runat="server" placeholder="Enter your Full Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox4">Email address</label>
                    <asp:TextBox ID="TextBox4" class="form-control" runat="server" placeholder="Enter your Email" TextMode="Email"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBox4">Mobile Number</label>
                    <asp:TextBox ID="TextBox11" class="form-control" runat="server" placeholder="Enter your Email" TextMode="Number"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBox5">Password</label>
                    <asp:TextBox ID="TextBox5" class="form-control" runat="server" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBox5">Confirm Password</label>
                    <asp:TextBox ID="TextBox6" class="form-control" runat="server" placeholder="Confirm your Password" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox5">Upload your Profile photo</label>
                    <asp:FileUpload class="form-control"  ID="FileUpload1" runat="server" />
\                </div>
                <asp:Button ID="SignUpButton" class="btn-secondary" runat="server" Text="Sign Up" OnClick="SignUpButton_Click" />
            </div>

        </div>
                   


<!-- Modal -->
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Reset password</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
      <div class="modal-body">
          <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <asp:TextBox ID="TextBox7" 
                         class="form-control" 
                         runat="server"  
                         placeholder="Enter the EmailID"
                         AutoPostBack="True"
                         OnTextChanged="TextBox7_TextChanged" TextMode="Email"></asp:TextBox>
        </div>
               


          <div class="form-group">
            <label for="exampleInputEmail1">Enter OTP</label>
              <asp:TextBox ID="TextBox8" class="form-control" runat="server" placeholder="Enter the OTP"></asp:TextBox>
          </div>

          <div class="form-group">
              <asp:Button ID="VerifyButton" runat="server" Text="Verify" OnClick="VerifyOTP" />
          </div>
               

          <div class="form-group">
             <label for="exampleInputEmail1">Enter New Password</label>
               <asp:TextBox ID="TextBox9" class="form-control" runat="server" placeholder="Enter NewPassword" TextMode="Password"></asp:TextBox>
          </div>

           <div class="form-group">
               <label for="exampleInputEmail1">Confirm Password</label>
                 <asp:TextBox ID="TextBox10" class="form-control" runat="server" placeholder="Conform password" TextMode="Password"></asp:TextBox>
           </div>
          </ContentTemplate>
  <Triggers>
        <asp:AsyncPostBackTrigger ControlID="TextBox7" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="VerifyButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ForgetPassword" EventName="Click" />

   </Triggers>
   </asp:UpdatePanel>
             
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          <asp:Button ID="ForgetPassword" class="btn btn-secondary"  runat="server" Text="Submit" OnClick="ForgetPassword_Click" />
      </div>
      
    </div>
  </div>
</div>
</form>
</body>
</html>




<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EcommerceApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>भूमिka - Creates a Woman</title>
    <link rel="icon" type="image/x-icon" href="favicon.ico">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        body {
            font-family: 'Arial', sans-serif;
            background: linear-gradient(to right, #f5d76e, #f7ca18); /* Golden gradient */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
            width: 400px;
            text-align: center;
            position: relative;
        }

        h1 {
            font-size: 2.5rem;
            color:#FF0000; 
            margin-bottom: 10px;
            text-transform: uppercase;
            animation: glow 1.5s infinite alternate;
        }

        .tagline {
            font-size: 1.2rem;
            color: #FF0000;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            float: left;
            color: #333;
            font-weight: bold;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
        }

        .btn-primary {
            width: 100%;
            padding: 10px;
            background-color: #d4af37; /* Golden button */
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 1.2rem;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-primary:hover {
            background-color: #f5d76e; /* Lighter golden hover effect */
        }

        .forgot-password {
            display: block;
            margin-top: 10px;
            font-size: 0.9rem;
            color: #d4af37;
            text-decoration: none;
            animation: glow 1.5s infinite alternate;
        }

        @keyframes glow {
            from {
                text-shadow: 0 0 10px #f5d76e, 0 0 20px #f7ca18, 0 0 30px #f5d76e;
            }
            to {
                text-shadow: 0 0 20px #f7ca18, 0 0 30px #d4af37, 0 0 40px #f7ca18;
            }
        }
    </style>

</head>
<body>
    <div class="login-container">
        <h1>भूमिka</h1>
        <div class="tagline">Creates a Woman</div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="TextBox1">Email address</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Enter your Email" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox2">Password</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" class="btn-primary" runat="server" Text="Login" />
            or
            <asp:Button ID="Button2" class="btn-secondary" runat="server" Text="Sign Up" />

            <a href="" class="forgot-password">Forget password?</a>
        </form>
    </div>
</body>
</html>--%>
