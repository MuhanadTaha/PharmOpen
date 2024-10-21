<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PharmOpen._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <%= Session["Email"] %>
    </section>
    <main>
        <center>
            <asp:DataList ID="dlCateg" RepeatDirection="Horizontal" RepeatColumns="10" runat="server">
                <ItemTemplate>
                    <div class="pr-1" runat="server">
                        <center>
                            <a class="btn btn-primary" href="Default.aspx?Category_ID=<%# Eval("Id")%>">
                                <%#Eval("Name") %>  
                            </a>
                        </center>
                    </div>
                </ItemTemplate>
            </asp:DataList>


             <br />

    <asp:DataList ID="ddlProducts" RepeatDirection="Horizontal" RepeatColumns="4" runat="server" OnItemCommand="dlReplies_ItemCommand">
        <ItemTemplate>
            <div style="border-radius: 5px; padding: 10px; margin: 10px; border: solid 1px" runat="server">
                <center>
                    <table style="width: 250px">
                        <tr>
                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("CategoryId") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lblIdProduct" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>' Visible="false"></asp:Label>



                            <asp:Image ID="imgCategories" runat="server" Style="width: 230px; height: 180px; object-fit: cover; border: solid 1px #bbbbbb" ImageUrl='<%# "~/Image/ImageProducts/" + Eval("Image") %>' />
                            <br />
                            <br />
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>' Style="font-weight: bold;"></asp:Label>
                            NLS
                   
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description").ToString().Length > 30 ? Eval("Description").ToString().Substring(0, 30) : Eval("Description") %>' Style="font-weight: bold;"></asp:Label>

                            <%--<asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Description") %>' Style="font-weight: bold;"></asp:Label>--%>
                            <br />
                            <br />
                            <asp:TextBox value="1" min="1" max="90"  placeholder="Enter a Quantity" ID="txtCount" type="number" CssClass="form-control text-center" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="btnBuy" CommandName="Add" runat="server" Text="Buy" CssClass="btn btn-primary btn-sm"></asp:Button>
                            <br />
                            <br />
                            <asp:Label ID="lblAlert" runat="server" Text="" CssClass="alert alert-success" Visible="false" Style="font-weight: bold;"></asp:Label>

                        </tr>
                    </table>
                </center>
            </div>
        </ItemTemplate>
    </asp:DataList>
        </center>
    </main>

</asp:Content>
