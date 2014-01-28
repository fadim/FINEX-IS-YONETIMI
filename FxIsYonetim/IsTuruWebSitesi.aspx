<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsTuruWebSitesi.aspx.cs" Inherits="FxIsYonetim.IsTuruWebSitesi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 120px;
        }
        .style3
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="İş Türü Web Sitesi" Width="35%">
            <table class="style1">
                <tr>
                    <td class="style3" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label1" runat="server" Text="Alan Adı"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAlanAdi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label2" runat="server" Text="Hosting"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHosting" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label3" runat="server" Text="Yayın Tarihi"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtYayinTar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label4" runat="server" Text="Yayın Süresi"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtYayinSur" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
