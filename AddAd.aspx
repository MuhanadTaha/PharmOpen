
<%@ Page Title=" إضافة إعلان" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAd.aspx.cs" Inherits="PharmOpen.AddAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2 class="text-center mb-4">إضافة إعلان جديد</h2>
    
    <!-- نموذج إضافة إعلان -->
    <div class="container" style="background-color: #f9f9f9; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
        <div dir="rtl">
            <!-- حقل عنوان الإعلان -->
            <div class="row mb-4">
                <label for="txtAdTitle" class="col-sm-3 col-form-label" style="font-weight: bold;">عنوان الإعلان:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAdTitle" runat="server" CssClass="form-control" placeholder="أدخل عنوان الإعلان" style="border-radius: 5px; border: 1px solid #ddd; height: 50px;" />
                </div>
            </div>
            
            <!-- حقل محتوى الإعلان -->
            <div class="row mb-4">
                <label for="txtAdContent" class="col-sm-3 col-form-label" style="font-weight: bold;">محتوى الإعلان:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAdContent" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="أدخل محتوى الإعلان" 
                                 style="border-radius: 5px; border: 1px solid #ddd; min-height: 300px; width: 100%; font-size: 16px; padding: 10px;" />
                </div>
            </div>

            <!-- حقل صورة الإعلان -->
            <div class="row mb-4">
                <label for="fileAdImage" class="col-sm-3 col-form-label" style="font-weight: bold;">صورة الإعلان:</label>
                <div class="col-sm-9">
                    <asp:FileUpload ID="fileAdImage" runat="server" CssClass="form-control-file" style="border-radius: 5px; border: 1px solid #ddd;" />
                </div>
            </div>

            <!-- زر إضافة الإعلان -->
            <div class="row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="btnAddAd" runat="server" CssClass="btn btn-success w-100" Text="إضافة الإعلان" OnClick="btnAddAd_Click" style="border-radius: 5px; padding: 12px 0; font-weight: bold;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
