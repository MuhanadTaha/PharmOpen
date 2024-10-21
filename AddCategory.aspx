<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="PharmOpen.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container cont">
        <section class="col-md-6 pt-2 pb-2">
            <div class="row">
                <div class="col-md-3">
                    <strong>
                        <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label></strong>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Add Category" class="btn btn-primary" />

        </section>
    </div>
</asp:Content>
