<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVillage.aspx.cs" Inherits="PharmOpen.AddVillage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center mb-4">إضافة قرية جديدة</h2>
    
    <!-- نموذج إضافة قرية -->
    <div class="container" style="background-color: #f9f9f9; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
        <div dir="rtl">
            <!-- حقل اسم القرية -->
            <div class="row mb-4">
                <label for="txtVillageName" class="col-sm-3 col-form-label" style="font-weight: bold;">اسم القرية:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtVillageName" runat="server" CssClass="form-control" requerd="true" placeholder="أدخل اسم القرية" style="border-radius: 5px; border: 1px solid #ddd; height: 50px;" />
                </div>
            </div>
            
            <!-- حقل المدينة -->
            <div class="row mb-4">
                <label for="ddlCity" class="col-sm-3 col-form-label" style="font-weight: bold;">المدينة:</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" style="border-radius: 5px; border: 1px solid #ddd; height: 50px;">
                        <asp:ListItem Text="اختر المدينة" Value="0" />
                       
                    </asp:DropDownList>
                </div>
            </div>

            <!-- زر إضافة القرية -->
            <div class="row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="btnAddVillage" runat="server" CssClass="btn btn-success w-100" Text="إضافة القرية" OnClick="btnAddVillage_Click" style="border-radius: 5px; padding: 12px 0; font-weight: bold;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
