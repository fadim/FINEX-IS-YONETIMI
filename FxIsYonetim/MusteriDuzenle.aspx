<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="MusteriDuzenle.aspx.cs" Inherits="FxIsYonetim.MusteriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style5
        {
            width: 160px;
            height: 29px;
        }
        .style6
        {
            height: 29px;
        }
        .style10
        {
            width: 111px;
            height: 29px;
        }
        .style22
        {
            width: 153px;
        }
        .style23
        {
            width: 111px;
        }
        .style25
        {
            width: 103px;
            height: 29px;
        }
        .style27
        {
            width: 99px;
        }
        .style28
        {
            width: 160px;
        }
        .style29
        {
            width: 103px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Müşteri Düzenleme" 
        Width="100%">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="style1" style="width: 100%">
            <tr>
                <td class="style23">
                    <asp:Image ID="ImgFirmaLogo" runat="server" Height="82px" 
                        Style="margin-left: 0px" Width="69%" />
                </td>
                <td class="style28">
                    &nbsp;</td>
                <td class="style29">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label4" runat="server" Text="Firma Ünvan"></asp:Label>
                    &nbsp; &nbsp;
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtmus_unvan" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtmus_unvan" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td class="style25">
                    <asp:Label ID="Label7" runat="server" Text="E-Posta"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style6">
                    <asp:TextBox ID="txtmus_ePosta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <asp:Label ID="Label5" runat="server" Text="Tel"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style28">
                    <asp:TextBox ID="txtmus_tel" runat="server"></asp:TextBox>
                </td>
                <td class="style29">
                    <asp:Label ID="Label8" runat="server" Text="Adres"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtmus_adres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <asp:Label ID="Label6" runat="server" Text="Cep"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style28">
                    <asp:TextBox ID="txtmus_cep" runat="server" ></asp:TextBox>
                </td>
                <td class="style29">
                    <asp:Label ID="Label9" runat="server" Text="Yetkili Adı"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtmus_yetkili" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    &nbsp;</td>
                <td class="style28">
                    &nbsp;</td>
                <td class="style29">
                    <asp:Label ID="Label3" runat="server" Text="Firma Logo"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="firmaLogo" runat="server" />
                    &nbsp;<asp:Button ID="txtSEC" runat="server" CausesValidation="False" 
                        onclick="btnSEC_Click" Text="Seç" Width="45px" />
                </td>
            </tr>
            <tr>
                <td class="style23">
                    &nbsp;</td>
                <td class="style28">
                    &nbsp;</td>
                <td class="style29">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnKAYDET" runat="server" onclick="btnKAYDET_Click" 
                        Text="Kaydet" Width="59px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
