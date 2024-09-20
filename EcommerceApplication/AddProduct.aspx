<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="EcommerceApplication.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>Add Product</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                         <div class="form-group">
                            <label for="Category">Category</label>
                            <asp:DropDownList ID="CategoryDropDown" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Electronics">Electronics</asp:ListItem>
                                <asp:ListItem Value="Clothing">Clothing</asp:ListItem>
                                <asp:ListItem Value="Books">Books</asp:ListItem>
                                <asp:ListItem Value="Accessories">Accessories</asp:ListItem>
                            </asp:DropDownList>
                       </div>

                       <div class="form-group">
                          <label for="ProductName">Product Photo</label>
                          <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                      </div>
      

                     <div class="form-group">
                        <label for="ProductName">Product Name</label>
                        <asp:TextBox ID="ProductNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label for="ProductName">Product Description</label>
                        <asp:TextBox ID="Description" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label for="ProductName">Product Price</label>
                        <asp:TextBox ID="Price" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>


                    <asp:Button ID="SaveProductButtonton" runat="server" Text="Save Product" CssClass="btn btn-primary" OnClick="SaveProductButton_Click" />

</asp:Content>
