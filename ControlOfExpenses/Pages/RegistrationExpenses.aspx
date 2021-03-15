<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrationExpenses.aspx.cs" Inherits="ControlOfExpenses.Pages.RegistrationExpenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container"style="border: solid;  padding: 30px 30px 0px 30px; border-color: #F1F1F1">
        <div class="row">
            <form>
                <fieldset>
                    <legend class="scheduler-border">Registrar nova despesa</legend>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="disabledSelect" class="form-label">Data:</label>
                            <asp:TextBox ID="txt_EXPENDITURE_DATE" type="date" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label for="disabledSelect" class="form-label">Valor Unitário:</label>
                            <asp:TextBox ID="txt_UNITARY_VALUE" type="number" step="0.01" min="0" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label for="disabledSelect" class="form-label">Quantidade:</label>
                            <asp:TextBox ID="txt_AMOUNT" type="number" step="0" min="0" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-8">
                            <label for="disabledTextInput" class="form-label">Classificação:</label>
                            <select id="selectclassification" runat="server" class="form-control">
                                <option value="" selected disabled>-- Selecione um Classificação --</option>
                            </select>
                        </div>

                        <div class="form-group col-md-4">
                            <label for="disabledSelect" class="form-label">Forma de Pagamento:</label>
                            <select id="selectformPayment" runat="server" class="form-control">
                                <option value="" selected disabled>Selecione..</option>
                            </select>
                        </div>
                    </div>



                    <div class="form-group">
                        <label for="disabledSelect" class="form-label">Pessoa:</label>
                        <asp:TextBox class="form-control" ID="txt_PERSON_NAME" type="text" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-outline mb-3">
                        <label for="disabledSelect" class="form-label">Comentário:</label>
                        <asp:TextBox ID="TextBox1" runat="server" Rows="20" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <div class="form-check">
                            <asp:CheckBox ID="txt_REPLAY" AutoPostBack="True" Text="Reembolsar Despesa?" class="form-check-input"
                                TextAlign="Right" runat="server" />
                        </div>
                    </div>
                    <br /><br />
                    <div class="mb-3">
                        <asp:Button ID="INSERT" runat="server" Text="Cadastrar" OnClick="cadastro_Click"  class="btn btn-success" />
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" class="btn btn-light"/>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
