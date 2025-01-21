<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipsList.aspx.cs" Inherits="PharmOpen.TipsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <a runat="server" href="~/AddTips.aspx" class="btn btn-success d-block w-25" id="btnAds">إضافة نصيحة</a></li>
    <br />
    <!-- GridView لعرض البيانات -->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="tip_id" CssClass="table table-bordered"
        Width="100%" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit">

        <Columns>
            <asp:BoundField DataField="tip_id" HeaderText="tip ID" SortExpression="tip_id" ReadOnly="True" Visible="false" />


            <asp:TemplateField HeaderText="عنوان النصيحة">
                <ItemTemplate>
                    <%# Eval("tip_title") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditAdTitle" runat="server" Text='<%# Bind("tip_title") %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="محتوى النصيحة">
                <ItemTemplate>
                    <%# Eval("tip_content") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditAdContent" runat="server" Text='<%# Bind("tip_content") %>' TextMode="MultiLine" Rows="5" Columns="30" />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="الصورة">
                <ItemTemplate>

                    <asp:Image ID="imgAdImage" runat="server"
                        ImageUrl='<%# Eval("tip_image")%>'
                        Width="200px" />
                </ItemTemplate>
                <EditItemTemplate>

                    <asp:FileUpload ID="fileUploadAdImage" runat="server" />

                    <asp:Label ID="lblCurrentImage" runat="server" Text='<%# Eval("tip_image") %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="أضافه">
                <ItemTemplate>
                    <%# Eval("email") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditUserEmail" runat="server" disabled="true" Text='<%# Bind("email") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="رقم المستخدم">
                <ItemTemplate>
                    <%# Eval("user_id") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditUserId" runat="server" ReadOnly="true" Text='<%# Bind("user_id") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" EditText="Edit" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
        </Columns>
    </asp:GridView>

</asp:Content>

