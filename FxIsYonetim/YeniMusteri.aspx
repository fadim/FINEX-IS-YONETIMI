<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="YeniMusteri.aspx.cs" Inherits="FxIsYonetim.YeniMusteri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 295px;
            height: 29px;
        }
        .style6
        {
            height: 29px;
        }
        .style7
        {
            width: 295px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Yeni Müşteri" Width="100%">
        <table class="style1">
            <tr>
                <td class="style7">
                    <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="Label3" runat="server" Text="Firma Logo"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:FileUpload ID="firmaLogo" runat="server" />
                    &nbsp;<asp:Button ID="txtSEC" runat="server" Text="Seç" Width="45px" 
                        onclick="btnSEC_Click" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="Label4" runat="server" Text="Firma Ünvan"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_unvan" runat="server"></asp:TextBox>
                    &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtmus_unvan" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td class="style6">
                    <asp:Label ID="Label7" runat="server" Text="E-Posta"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_ePosta" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="Label5" runat="server" Text="Tel"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_tel" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Adres"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_adres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="Label6" runat="server" Text="Cep"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_cep" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Yetkili Adı"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtmus_yetkili" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnKAYDET" runat="server" Text="Kaydet" 
                        onclick="btnKAYDET_Click" />
                </td>
            </tr>
        </table>
     
    </asp:Panel>
</asp:Content>
