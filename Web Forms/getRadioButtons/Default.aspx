<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Obtener todos los radioButtons de un Groupname</title>
</head>
<body>
    <form id="form1" runat="server">
    
    
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Grupo1" Text ="RadioButton1" />
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Grupo1" Text ="RadioButton2"/>
        <br />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Grupo1" Text ="RadioButton3"/>
        <br />
        <br />
        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Grupo2" Text ="RadioButton4"/>
        <br />
        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="Grupo2" Text ="RadioButton5"/>
        <br />
        <asp:RadioButton ID="RadioButton6" runat="server" GroupName="Grupo2" Text ="RadioButton6"/>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Empezar" />
    
    
    </form>
</body>
</html>
