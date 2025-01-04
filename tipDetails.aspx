<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tipDetails.aspx.cs" Inherits="PharmOpen.tipDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <h2>تفاصيل النصيحة</h2>

        <!-- عرض تفاصيل الإعلان -->
        <div class="card">
            <img id="imgtipImage" runat="server" class="card-img-top" alt="Tip Image" style="width: 100%; height: 500px;">
            <div class="card-body">
                <h5 id="lblTipTitle" runat="server" class="card-title"></h5>
                <br />
                <p id="lblTipContent" runat="server" class="card-text"></p>
            </div>
        </div>

    </div>
</asp:Content>
