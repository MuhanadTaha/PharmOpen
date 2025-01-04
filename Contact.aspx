<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PharmOpen.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your contact page.</h3>
        <address>
            Bethlahim<br />
            almahd church<br />
            <abbr title="Phone">Phone:</abbr>
            0599 11 22 33
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">PharmOpen@gmail.com.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Haifa@gmail.com</a>,  <a href="mailto:Marketing@example.com">Tasneem@gmail.com</a> 
        </address>
    </main>
</asp:Content>
