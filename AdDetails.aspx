<%@ Page Title="Advertisement Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdDetails.aspx.cs" Inherits="PharmOpen.AdDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <h2>تفاصيل الإعلان</h2>

        <!-- عرض تفاصيل الإعلان -->
        <div class="card">
            <img id="imgAdImage" runat="server" class="card-img-top" alt="Advertisement Image" style="width: 100%; height: 500px;">
            <div class="card-body">
                <h5 id="lblAdTitle" runat="server" class="card-title"></h5>
                <br />
                <p id="lblAdContent" runat="server" class="card-text"></p>
            </div>
        </div>

    </div>
</asp:Content>

