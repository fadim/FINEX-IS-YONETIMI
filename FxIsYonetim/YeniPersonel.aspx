<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true"
    CodeBehind="YeniPersonel.aspx.cs" Inherits="FxIsYonetim.Personel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 150px;
        }<a href="YeniPersonel.aspx">YeniPersonel.aspx</a>
        .style31
        {
            width: 54px;
            height: 29px;
        }
        .style32
        {
            width: 306px;
            height: 29px;
        }
        .style34
        {
            width: 150px;
            height: 29px;
        }
        .style48
        {
            width: 54px;
            height: 31px;
        }
        .style49
        {
            width: 306px;
            height: 31px;
        }
        .style51
        {
            width: 150px;
            height: 31px;
        }
        .style56
        {
            width: 54px;
            height: 19px;
        }
        .style57
        {
            width: 306px;
            height: 19px;
        }
        .style58
        {
            width: 107px;
            height: 19px;
        }
        .style60
        {
            width: 107px;
            height: 31px;
        }
        .style61
        {
            width: 107px;
            height: 29px;
        }
        .style63
        {
            width: 54px;
        }
        .style65
        {
            width: 107px;
        }
        .style66
        {
            width: 306px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Yeni Personel">
        <table class="style1" style="width: 100%">
            <tr>
                <td class="style63">
                    &nbsp;</td>
                <td class="style66">
                    &nbsp;
                </td>
                <td class="style65">
                    &nbsp;
                </td>
                <td class="style6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style48">
                    <asp:Label ID="Label3" runat="server" Text="Adı"></asp:Label>
                </td>
                <td class="style49">
                    <asp:TextBox ID="txtper_adi" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtper_adi"
                        ErrorMessage="Personel Adını Giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style60">
                    <asp:Label ID="Label8" runat="server" Text="TC"></asp:Label>
                </td>
                <td class="style51">
                    <asp:TextBox ID="txtper_tc" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtper_tc"
                        ErrorMessage="TC No Giriniz"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style31">
                    <asp:Label ID="Label4" runat="server" Text="Soyadı"></asp:Label>
                </td>
                <td class="style32">
                    <asp:TextBox ID="txtper_soyadi" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtper_soyadi"
                        ErrorMessage="Personel Soyadını Giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style61">
                    <asp:Label ID="Label9" runat="server" Text="Doğum Tarihi"></asp:Label>
                </td>
                <td class="style34">
                    <asp:TextBox ID="txtper_dogumTar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style63">
                    <asp:Label ID="Label5" runat="server" Text="Tel"></asp:Label>
                </td>
                <td class="style66">
                    <asp:TextBox ID="txtper_tel" runat="server"></asp:TextBox>
                </td>
                <td class="style65">
                    <asp:Label ID="Label10" runat="server" Text="Memleket"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_memleket" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style63">
                    <asp:Label ID="Label6" runat="server" Text="Cep"></asp:Label>
                </td>
                <td class="style66">
                    <asp:TextBox ID="txtper_cep" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtper_cep"
                        ErrorMessage="Cep tel giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style65">
                    <asp:Label ID="Label11" runat="server" Text="Şehir"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtper_sehir" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style63">
                    <asp:Label ID="Label7" runat="server" Text="E-Posta"></asp:Label>
                </td>
                <td class="style66">
                    <asp:TextBox ID="txtper_ePosta" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtper_ePosta"
                        ErrorMessage="E-Posta giriniz"></asp:RequiredFieldValidator>
                </td>
                <td class="style65">
                    <asp:Label ID="Label12" runat="server" Text="Fotoğraf"></asp:Label>
                    </td>
                <td class="style6">
                    <asp:Image ID="txtper_foto" runat="server" Width="1%" />
                    <asp:FileUpload ID="perRESIM" runat="server" />
                    <asp:Button ID="btnSEC" runat="server" CausesValidation="False" 
                        OnClick="btnSEC_Click" Text="Seç" />
                </td>
            </tr>
            <tr>
                <td class="style63">
                    &nbsp;</td>
                <td class="style66">
                    &nbsp;</td>
                <td class="style65">
                    <asp:Image ID="imgPersonel" runat="server" Height="82px" ImageUrl="95%" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style56">
                </td>
                <td class="style57">
                </td>
                <td class="style58">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnKaydet" runat="server" OnClick="btnKAYDET_Click" 
                        Style="height: 26px" Text="Kaydet" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
