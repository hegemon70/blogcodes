<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Suma de dos nmeros en ASP.NET --MVP--
    </h2>
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btSum" Text="Sumar" runat="server" OnClick="btSumClick" />
            </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="lbResultado" runat="server"></asp:Label>
        </td>
        </tr>
    </table>
</asp:Content>
