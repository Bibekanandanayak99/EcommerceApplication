<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="EcommerceApplication.DeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Delete Account
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server"  OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>

            <div class="card" style="width: 18rem;">
              <img class="card-img-top" src='<%#Eval("UserPhoto") %>' alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title"><%#Eval("UserNmae") %></h5>
              </div>
              <ul class="list-group list-group-flush">
                <li class="list-group-item"><b>EmaiID: </b><%#Eval("UserEmail") %></li>
                <li class="list-group-item"><b>Contact: </b><%#Eval("UserNumber") %></li>
                <li class="list-group-item"><b>Role: </b><%#Eval("UserRole") %></li>
              </ul>
              <div class="card-body">

              </div>
                <asp:Button ID="DeleteAccount" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%#Eval("UserEmail") %>' CommandName="Delete" />
            </div>

        </ItemTemplate>
    </asp:DataList>
</asp:Content>
