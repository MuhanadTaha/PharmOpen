<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VillageList.aspx.cs" Inherits="PharmOpen.VillageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <a runat="server" href="~/AddVillage.aspx" class="btn btn-success d-block w-25" id="btnAddVillage">إضافة قرية</a>
    <br />
    <!-- GridView لعرض البيانات -->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="village_id" CssClass="table table-bordered"
        Width="100%" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit">

        <Columns>
            <asp:BoundField DataField="village_id" HeaderText="Village ID" SortExpression="village_id" ReadOnly="True" Visible="false" />
            <asp:TemplateField HeaderText="اسم القرية">
                <ItemTemplate>
                    <%# Eval("village_name") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditVillageName" runat="server" Text='<%# Bind("village_name") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="اسم المدينة">
                <ItemTemplate>
                    <%# Eval("city_name") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditCityName" runat="server" Text='<%# Bind("city_name") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="City ID" Visible="false">
                <ItemTemplate>
                    <%# Eval("city_id") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditCityId" ReadOnly="true" runat="server" Text='<%# Bind("city_id") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" EditText="Edit" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
        </Columns>
    </asp:GridView>

</asp:Content>
