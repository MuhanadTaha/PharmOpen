<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Register.aspx.cs" Inherits="PharmOpen.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin: 20px 0px">
        <h1>Sign Up</h1>
        <hr />
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage="First Name is required." ToolTip="First Name  required." CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>



            <div class="col-md-6">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Last Name is required." ToolTip="Last Name  required." CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtDOB" runat="server" type="date" CssClass="form-control" placeholder="Date of Birth"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOB"
                    ErrorMessage="DOB is required." ToolTip="DOB  required." CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtMobile" type="number" runat="server"  CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewtxtMobile" runat="server" ControlToValidate="txtMobile"
                    ErrorMessage="Mobile is required." ToolTip="Mobile is required." CssClass="text-danger">
                </asp:RequiredFieldValidator>


                <asp:RegularExpressionValidator ID="RegExp1" runat="server"
                    ErrorMessage="Mobile length must be 10 digits"
                    ControlToValidate="txtMobile"
                    class="text-danger"
                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{10,10}$" />
            </div>
        </div>

        <div class="row">

            <div class="col-md-6">
                <asp:TextBox ID="txtEmail" type="email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required." ToolTip="Email Name  required." CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                  
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 ">
                <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is required." ToolTip=" required." CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 ">
                <div class="col-md-6">
                    <asp:TextBox ID="txtCPassword" runat="server" type="password" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCPassword"
                        ErrorMessage="Confirm Password is required." ToolTip=" required." CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToValidate="txtCPassword"
                        ControlToCompare="txtPassword"
                        Operator="Equal"
                        ErrorMessage="Password and Confirm Password must match."
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-md-6 ">
                <asp:Button ID="btnSubmit" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </div>
</asp:Content>
