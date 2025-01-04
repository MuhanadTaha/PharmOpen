<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPharmacy.aspx.cs" Inherits="PharmOpen.AddPharmacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center mb-4">إضافة صيدلية جديدة</h2>

    <!-- نموذج إضافة صيدلية -->
    <div class="container" style="max-width: 800px; padding: 30px; background-color: #f9f9f9; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
        <div>
            <div dir="rtl">
                <!-- حقل اسم الصيدلية -->
                <div class="row mb-4">
                    <label for="txtPharmacyName" class="col-sm-3 col-form-label" style="font-weight: bold;">اسم الصيدلية:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtPharmacyName" runat="server" CssClass="form-control" placeholder="أدخل اسم الصيدلية" Style="border-radius: 5px; border: 1px solid #ddd;" />
                    </div>
                </div>

                <!-- اختيار المدينة -->
                <div class="row mb-4">
                    <label for="ddlCity" class="col-sm-3 col-form-label" style="font-weight: bold;">المدينة:</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            <asp:ListItem Text="اختر المدينة" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- اختيار القرية -->
                <div class="row mb-4">
                    <label for="ddlVillage" class="col-sm-3 col-form-label" style="font-weight: bold;">القرية:</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-control">
                            <asp:ListItem Text="اختر القرية" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- حقل تاريخ المناوبة -->
                <div class="row mb-4">
                    <label for="txtShiftDate" class="col-sm-3 col-form-label" style="font-weight: bold;">تاريخ المناوبة:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtShiftDate" runat="server" CssClass="form-control" placeholder="اختر تاريخ المناوبة" Style="border-radius: 5px; border: 1px solid #ddd;" TextMode="Time" />
                    </div>
                </div>

                <!-- زر إضافة الصيدلية -->
                <div class="row">
                    <div class="col-sm-9 offset-sm-3">
                        <asp:Button ID="btnAddPharmacy" runat="server" CssClass="btn btn-success w-100" Text="إضافة الصيدلية" OnClick="btnAddPharmacy_Click" Style="border-radius: 5px; padding: 12px 0; font-weight: bold;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
