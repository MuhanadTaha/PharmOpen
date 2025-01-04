<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subscription.aspx.cs" Inherits="PharmOpen.Subscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- إضافة رابط ملف CSS الخاص بـ Bootstrap -->
   

    <div class="container mt-5" dir="rtl">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>تسجيل الاشتراك في الإعلانات</h3>
                    </div>
                    <div class="card-body">
                        <div >
                            <!-- حقل رقم الجوال -->
                            <div class="form-group">
                                <label for="txtMobile">رقم الجوال:</label>
                                <asp:TextBox ID="txtMobile" type="number" runat="server" CssClass="form-control" placeholder="أدخل رقم الجوال"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvMobile" 
                                    runat="server" 
                                    ControlToValidate="txtMobile" 
                                    ErrorMessage="رقم الجوال مطلوب" 
                                    ForeColor="Red" 
                                    Display="Dynamic" 
                                    CssClass="text-danger" />
                            </div>
                            <br />
                            <!-- حقل البريد الإلكتروني -->
                            <div class="form-group">
                                <label for="txtEmail">البريد الإلكتروني:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="أدخل البريد الإلكتروني"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvEmail" 
                                    runat="server" 
                                    ControlToValidate="txtEmail" 
                                    ErrorMessage="البريد الإلكتروني مطلوب" 
                                    ForeColor="Red" 
                                    Display="Dynamic" 
                                    CssClass="text-danger" />
                                <asp:RegularExpressionValidator 
                                    ID="revEmail" 
                                    runat="server" 
                                    ControlToValidate="txtEmail" 
                                    ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" 
                                    ErrorMessage="البريد الإلكتروني غير صحيح" 
                                    ForeColor="Red" 
                                    Display="Dynamic" 
                                    CssClass="text-danger" />
                            </div>
                            <br />
                            <!-- زر التسجيل -->
                            <div class="form-group text-center">
                                <asp:Button Text="تسجيل الاشتراك" runat="server" OnClick="SaveSubscription" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
