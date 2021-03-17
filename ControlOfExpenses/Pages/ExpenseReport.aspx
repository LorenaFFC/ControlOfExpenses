<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" Inherits="ControlOfExpenses.Pages.ExpenseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-light bg-light">
        <div class="container-fluid">
           
            Mês: <asp:TextBox  class="form-control col-md-2" type="number" step="0" min="1" max="12" ID="month" runat="server" />
            Ano: <asp:TextBox class="form-control col-md-2" type="number"  step="0" min="2020" ID="year" runat="server" />
           
            Reembolso: <asp:DropDownList class="form-control col-md-1" runat="server" AutoPostBack="true" ID="REPLAY">
                            <asp:ListItem  Text="Sim" />
                            <asp:ListItem   Text="Não" />
                        </asp:DropDownList>
            Status: <asp:DropDownList class="form-control col-md-2" runat="server" AutoPostBack="true" ID="STATUS">
                        <asp:ListItem Text="Aprovada" />
                        <asp:ListItem Text="Reprovada" />
                        <asp:ListItem Text="Revisão" />
                    </asp:DropDownList>
            <asp:Button class="btn btn-outline-success" runat="server" Text="Aplicar" OnClick="Unnamed1_Click" />
            <asp:Button class="btn btn-outline-secondary" runat="server" Text="Limpar" OnClick="Unnamed2_Click" />
            <br />
            <br />
                </div>
      
    </nav>
    <h3>Despesas </h3>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed" 
        DataKeyNames="ID"
        ShowHeaderWhenEmpty="true"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowEditing="GridView1_RowEditing"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnPageIndexChanging="OnPageIndexChanging"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="TRUE" PageSize="3" GridLines="None" HorizontalAlign="Justify" >
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        <Columns>
            <asp:TemplateField HeaderText="Classificação">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CLASSIFICATION") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtClassificationFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("EXPENDITURE_DATE") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtExpenditure_date" Type="date" Text='<%# Eval("EXPENDITURE_DATE") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtExpenditure_dateFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Unitatio">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("UNITARY_VALUE") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtvalueUnitary" type="number" step="0.01" min="0" Text='<%# Eval("UNITARY_VALUE") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtvalueUnitaryFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantidade">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("AMOUNT") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtamount" Text='<%# Eval("AMOUNT") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtamountFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Total">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("TOTAL_VALUE") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtvalueTotalFoooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Forma de Pgto">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FORM_PAYMENT") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList
                        AutoPostBack="True"
                        ID="txtformadePagamto"
                        runat="server">
                        <asp:ListItem Value="Cartão de Crédito" ID="txtformadePagamto1" runat="server"> Cartão de Crédito </asp:ListItem>
                        <asp:ListItem Value="Cartão de Débito" ID="txtformadePagamto2" runat="server"> Cartão de Débito </asp:ListItem>
                        <asp:ListItem Value="Dinheiro" ID="txtformadePagamto3" runat="server"> Dinheiro </asp:ListItem>
                        <asp:ListItem Value="Cheque" ID="txtformadePagamto4" runat="server"> Cheque </asp:ListItem>
                        <asp:ListItem Value="Pix" ID="txtformadePagamto5" runat="server"> Pix </asp:ListItem>
                        <asp:ListItem Value="PicPay" ID="txtformadePagamto6" runat="server"> PicPay </asp:ListItem>
                    </asp:DropDownList>

                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtformadePagamtoFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reembolso">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("REPLAY") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtReembolsoFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("STATUS") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList
                        AutoPostBack="True"
                        ID="txtStatus"
                        runat="server">
                        <asp:ListItem Selected="True" Value="Aguardando Aprovação"> Aguardando Aprovação </asp:ListItem>
                        <asp:ListItem Value="Aprovada"> Aprovada </asp:ListItem>
                        <asp:ListItem Value="Reprovada"> Reprovada </asp:ListItem>
                        <asp:ListItem Value="Revisão"> Revisão </asp:ListItem>
                    </asp:DropDownList>

                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtStatusFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Images/approved.png" runat="server" RowIndex='<%# GridView1.DataKeys[Container.DisplayIndex].Value %>' ToolTip="Aprovar" Width="20px" Height="20px" OnClick="button_approved" />
                    <asp:ImageButton ImageUrl="~/Images/deny.png" runat="server" RowIndex='<%# GridView1.DataKeys[Container.DisplayIndex].Value %>' ToolTip="Reprovar" Width="20px" Height="20px" OnClick="button_deny" />
                    <asp:ImageButton ImageUrl="~/Images/time.png" runat="server" RowIndex='<%# GridView1.DataKeys[Container.DisplayIndex].Value %>' ToolTip="Revisão" Width="20px" Height="20px" OnClick="button_revision" />

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                </EditItemTemplate>

            </asp:TemplateField>

        </Columns>
    </asp:GridView>




      
</asp:Content>
