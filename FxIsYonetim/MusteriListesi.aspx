<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="MusteriListesi.aspx.cs" Inherits="FxIsYonetim.MusteriListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Müşteri Listesi" 
        Width="100%">
        <asp:GridView ID="grvMusteri" runat="server" Width="100%" 
        AutoGenerateColumns="False" EmptyDataText="Müşteri Bulunamadı" 
         >
            <Columns>
                <asp:TemplateField HeaderText="No" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fotoğraf">
                    <ItemTemplate>
                        <asp:Image ID="imgFirmaLogo" runat="server" ImageUrl=<%#Eval("Logo") %> 
                            Height="69px" Width="60px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Unvan" HeaderText="Firma" />
                <asp:TemplateField HeaderText="İşlem">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDuzenle" runat="server" Text="Düzenle" 
                        OnClick="lnkDuzenle_Click" CommandArgument='<%#Eval("Id") %>'>Düzenle</asp:LinkButton>
                     
                    &nbsp;<asp:LinkButton ID="lnkSil" runat="server" Text="Sil" 
                        OnClick="lnkSil_Click" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
