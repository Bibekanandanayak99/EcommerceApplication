<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EcommerceApplication.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Product List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
        
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        
        <Columns>

            <asp:TemplateField HeaderText="Product ID">
                <ItemTemplate>
                    <asp:Label ID="ID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image" Height="50" Width="50" ImageUrl='<%# Eval("ProductPhoto") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:Label ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%#Bind("ProductName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:Label ID="Description" runat="server" Text='<%# Eval("ProductDescription") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%#Bind("ProductDescription") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Price" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%#Bind("ProductPrice") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="Category" runat="server" Text='<%# Eval("ProductCategory") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%#Bind("ProductCategory") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-danger" runat="server" CommandName="Delete" Text="Delete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary" />
                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>

    </asp:GridView>

</asp:Content>
