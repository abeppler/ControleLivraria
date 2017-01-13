<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroLivro.aspx.cs" Inherits="ControleLivraria2.CadastroLivro" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/bootstrap.min.css") %>" />
    <script src="<%: ResolveUrl("~/Scripts/jquery-1.9.1.min.js") %>" type='text/javascript'></script>
    <script src="<%: ResolveUrl("~/Scripts/bootstrap.min.js") %>" type='text/javascript'></script>

    <script>
        function NovoLivro() {
            $("#txtId").val("");
            $("#txtNome").val("");
            $("#txtEditora").val("");
            $("#txtQtdeExemplares").val("");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Cadastro de Livros</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading">Operações</div>
                <div class="panel-body">
                    <div class="btn-group">
                        <button id="btnNovo" class="btn btn-default" onclick="NovoLivro();">Novo </button>
                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-default" Text="Salvar" OnClick="btnSalvar_Click" />
                        <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-default" Text="Excluir" OnClick="btnExcluir_Click" />
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">Dados do Livro</div>
                <asp:UpdatePanel ID="updDadosLivro" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label col-sm-2">Id:</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtId" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Nome:</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Editora:</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEditora" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Qtde. Exemplares:</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtQtdeExemplares" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">Livros Cadastrados</div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="updGridLivros" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:GridView ID="grdLivros" runat="server" CssClass="table table-responsive table-striped"
                                GridLines="None" AutoGenerateColumns="False" UseAccessibleHeader="true"
                                OnSelectedIndexChanged="grdLivros_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkExcluir" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" SelectText="Editar" ShowSelectButton="True">
                                        <HeaderStyle Width="5%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                                    <asp:BoundField DataField="Nome" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="Editora" HeaderText="Editora"></asp:BoundField>
                                    <asp:BoundField DataField="QtdeExemplares" HeaderText="Qtde. Exemplares"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>
</body>
</html>
