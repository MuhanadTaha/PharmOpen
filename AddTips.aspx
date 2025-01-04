
<%@ Page Title=" إضافة نصيحة" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTips.aspx.cs" Inherits="PharmOpen.AddTips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2 class="text-center mb-4">إضافة نصيحة جديدة</h2>
    
    <!-- نموذج إضافة إعلان -->
    <div class="container" style="background-color: #f9f9f9; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
        <div dir="rtl">
            <!-- حقل عنوان الإعلان -->
            <div class="row mb-4">
                <label for="txtTipTitle" class="col-sm-3 col-form-label" style="font-weight: bold;">عنوان النصيحة:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtTipTitle" runat="server" CssClass="form-control" placeholder="أدخل عنوان النصيحة" style="border-radius: 5px; border: 1px solid #ddd; height: 50px;" />
                </div>
            </div>
            
            <!-- حقل محتوى الإعلان -->
            <div class="row mb-4">
                <label for="txtTipContent" class="col-sm-3 col-form-label" style="font-weight: bold;">محتوى النصيحة:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtTipContent" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="أدخل محتوى النصيحة" 
                                 style="border-radius: 5px; border: 1px solid #ddd; min-height: 300px; width: 100%; font-size: 16px; padding: 10px;" />
                </div>
            </div>

            <!-- حقل صورة الإعلان -->
            <div class="row mb-4">
                <label for="fileTipImage" class="col-sm-3 col-form-label" style="font-weight: bold;">صورة النصيحة:</label>
                <div class="col-sm-9">
                    <asp:FileUpload ID="fileTipImage" runat="server" CssClass="form-control-file" style="border-radius: 5px; border: 1px solid #ddd;" />
                </div>
            </div>

            <!-- زر إضافة الإعلان -->
            <div class="row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="btnAddTip" runat="server" CssClass="btn btn-success w-100" Text="إضافة النصيحة" OnClick="btnAddTip_Click" style="border-radius: 5px; padding: 12px 0; font-weight: bold;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
