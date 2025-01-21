<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PharmaciesList.aspx.cs" Inherits="PharmOpen.PharmaciesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <a runat="server" href="~/AddPharmacy.aspx" class="btn btn-success d-block w-25" id="btnPharmacies">إضافة صيدلية</a></li>
    <br />
    <!-- GridView لعرض بيانات الصيدليات -->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="pharmacy_id" CssClass="table table-bordered"
        Width="100%" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit">

        <Columns>
            <asp:BoundField DataField="pharmacy_id" HeaderText="Pharmacy ID" SortExpression="pharmacy_id" ReadOnly="True" Visible="false" />

            <asp:TemplateField HeaderText="اسم الصيدلية">
                <ItemTemplate>
                    <%# Eval("pharmacy_name") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditPharmacyName" runat="server" Text='<%# Bind("pharmacy_name") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="اسم القرية">
                <ItemTemplate>
                    <%# Eval("village_name") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlVillage" runat="server">
                        <asp:ListItem Text="Select Village" Value="" />

                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="اسم المدينة">
                <ItemTemplate>
                    <%# Eval("city_name") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCity" runat="server">
                        <asp:ListItem Text="Select City" Value="" />
                    </asp:DropDownList>
                    <!-- إضافة Label لعرض city_id -->
                    <asp:Label ID="city_id" runat="server" Text='<%# Eval("city_id") %>' Visible="false"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="أضافه">
                <ItemTemplate>
                    <%# Eval("email") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("email") %>' disabled="true" />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="رقم المستخدم">
                <ItemTemplate>
                    <%# Eval("user_id") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditUserId" runat="server" Text='<%# Bind("user_id") %>' ReadOnly="true" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" EditText="Edit" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
        </Columns>
    </asp:GridView>

     <asp:Label ID="lblError" runat="server" Text="" Visible="true"  ForeColor="Red"></asp:Label>
   

</asp:Content>
