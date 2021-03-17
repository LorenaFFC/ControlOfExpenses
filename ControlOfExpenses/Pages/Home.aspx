<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ControlOfExpenses.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form>
        <fieldset>
            <legend class="scheduler-border" style="padding: 10px 20px">Informações</legend>
            <div class="form-row" style="padding: 10px 20px">
                <div class="form-group col-md-8">
                    <label for="disabledSelect" class="form-label">Nome Pessoa:</label>
                    <asp:TextBox ID="txt_NomePessoa" type="text" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row" style="padding: 10px 20px">
                <div class="form-group col-md-4">
                    <label for="disabledSelect" class="form-label">Data Inicial:</label>
                    <asp:TextBox ID="DT_INICIAL" type="date" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="disabledSelect" class="form-label">Data Final:</label>
                    <asp:TextBox ID="DT_FINAL" type="date" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div style="padding: 10px 20px">
                <asp:Button ID="Button1" runat="server" Text="Gerar Relatório" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
        </fieldset>
    </form>
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

</asp:Content>
