<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="PersonelDuzenle.aspx.cs" Inherits="FxIsYonetim.PersonelDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 86px;
        }
        .style6
        {
            width: 356px;
        }
        .style7
        {
            width: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Personel Düzenleme" 
        Width="806px">
        <table class="style1">
            <tr>
                <td class="style4">
                    <asp:Image ID="imgPersonel" runat="server" Height="82px" 
                        Style="margin-left: 0px" Width="95%" />
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Adı"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_adi" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtper_adi" ErrorMessage="Personel Adını Giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style7">
                    <asp:Label ID="Label8" runat="server" Text="TC"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtper_tc" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtper_tc" ErrorMessage="TC No Giriniz"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="Soyadı"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_soyadi" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtper_soyadi" 
                        ErrorMessage="Personel Soyadını Giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style7">
                    <asp:Label ID="Label9" runat="server" Text="Doğum Tarihi"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtper_dogumTar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Tel"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_tel" runat="server"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="Label10" runat="server" Text="Memleket"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtper_memleket" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Cep"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_cep" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtper_cep" ErrorMessage="Cep tel giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style7">
                    <asp:Label ID="Label11" runat="server" Text="Şehir"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtper_sehir" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Text="E-Posta"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_ePosta" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtper_ePosta" ErrorMessage="E-Posta giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style7">
                    <asp:Label ID="Label12" runat="server" Text="Fotoğraf"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="perRESIM" runat="server" />
                    &nbsp;<asp:Button ID="btnSEC" runat="server" CausesValidation="False" 
                        OnClick="btnSEC_Click" Text="Seç" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnKaydet" runat="server" OnClick="btnKAYDET_Click" 
                        Style="height: 26px" Text="Kaydet" />
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
