<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="YeniIs.aspx.cs" Inherits="FxIsYonetim.YeniIs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
        }
        .style5
        {
            width: 202px;
        }
        .style7
        {
        }
        .style8
        {
        }
        .style9
        {
            width: 124px;
        }
        .style10
        {
            width: 131px;
        }
        .style11
        {
            color: #000000;
        }
        #frm1
        {
            margin-top: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Yeni İş" Width="100%">
        <table class="style1">
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label3" runat="server" Text="Müşteri"></asp:Label>
                </td>
                <td class="style5">
                    <asp:DropDownList ID="ddlMusteri" runat="server" Width="125px">
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <asp:Label ID="Label9" runat="server" Text="İş Türü"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlIsTuru" runat="server" OnSelectedIndexChanged="ddlIsTuru_SelectedIndexChanged" Width="125px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label4" runat="server" Text="İlk Görüşme"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtIlkGorusmeTar" runat="server"></asp:TextBox>
                </td>
                <td class="style7" colspan="2">
                    
                    <asp:Panel ID="Panel2" runat="server" Width="256px" style="margin-right: 0px">
                    
                    </asp:Panel>
      
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label5" runat="server" Text="Tahmini Fiyat"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtTahminiFiyat" runat="server"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Label ID="Label10" runat="server" Text="Son Görüşme"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSonGorusmeTar" runat="server" Width="125px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label6" runat="server" Text="Fiyat"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtFiyat" runat="server"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Label ID="Label11" runat="server" Text="İş Durumu"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlIsDurumu" runat="server" Width="125px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label7" runat="server" Text="Kapora"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtKapora" runat="server"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Label ID="Label12" runat="server" Text="İlgili Personel"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dllIlgiliPersonel" runat="server" Width="125px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label8" runat="server" Text="Not"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtNot" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style7" colspan="2">
                    <asp:Label ID="Label13" runat="server" Text="Ek/Resim"></asp:Label>
                    &nbsp; </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style7" colspan="2">
                    <asp:FileUpload ID="perRESIM" runat="server" />
                    &nbsp;<asp:Button ID="btnSEC" runat="server" CausesValidation="False" 
                        OnClick="btnSEC_Click" Text="Seç" />
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style8" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnKaydet" runat="server" OnClick="btnKAYDET_Click" 
                        Style="height: 26px" Text="Kaydet" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
