<%@ Page Title="" Language="C#" MasterPageFile="~/Fxls.Master" AutoEventWireup="true" CodeBehind="IsListesi.aspx.cs" Inherits="FxIsYonetim.IsListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="İş Listesi" 
        Width="100%">
        <asp:GridView ID="grvIs" runat="server" Width="100%" 
        AutoGenerateColumns="False" EmptyDataText="İş Bulunamadı" 
         >
            <Columns>
                <asp:TemplateField HeaderText="No" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField=" MusteriId" HeaderText="Müşteri" />
                <asp:BoundField DataField="TurId" HeaderText="İş Türü" />
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
