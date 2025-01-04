<%@ Page Title="الصفحة الرئيسية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PharmOpen.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <h2>المناوبات في محافظة الخليل</h2>
        <br />
        <!-- عرض المناوبات -->
        <h3></h3>
        <asp:GridView ID="gvShifts" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered">
        </asp:GridView>

        <br />
        <h3>النصائح</h3>
        <div class="row">
            <asp:Repeater ID="rptTips" runat="server">
                <ItemTemplate>
                    <!-- عرض الإعلان -->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="<%# Eval("tip_image") %>" class="card-img-top" alt="نصائح" style="width: 100%; height: 200px;">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <a href="tipDetails.aspx?tip_id=<%# Eval("tip_id") %>">
                                        <%# Eval("tip_title") %>
                                    </a>
                                </h5>
                                <p class="card-text"><%# Eval("tip_content").ToString().Substring(0, Math.Min(Eval("tip_content").ToString().Length, 60)) %>...</p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <br />
        <h3 >الإعلانات</h3>    <!-- زر الاشتراك لفتح النافذة المنبثقة -->
       
        <div class="row">
            <asp:Repeater ID="rptAds" runat="server">
                <ItemTemplate>
                    <!-- عرض الإعلان -->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="<%# Eval("ad_image") %>" class="card-img-top" alt="إعلان" style="width: 100%; height: 200px;">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <a href="AdDetails.aspx?ad_id=<%# Eval("ad_id") %>">
                                        <%# Eval("ad_title") %>
                                    </a>
                                </h5>
                                <p class="card-text"><%# Eval("ad_content").ToString().Substring(0, Math.Min(Eval("ad_content").ToString().Length, 60)) %>...</p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <br />
         <a class="btn btn-danger d-block" href="/Subscription.aspx">
            اشترك الآن
        </a>
    </div>
</asp:Content>
