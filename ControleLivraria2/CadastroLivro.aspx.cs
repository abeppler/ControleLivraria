using ControleLivraria2.Controller;
using ControleLivraria2.Helpers;
using ControleLivraria2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleLivraria2
{
    public partial class CadastroLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGridLivros();
            }
        }

        private void CarregarGridLivros()
        {
            ILivroController livroCtrl = ControllerFactory.ObterLivroController();
            grdLivros.DataSource = livroCtrl.ObterTodos();
            grdLivros.DataBind();
            updGridLivros.Update();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Livro livro = ObterLivroFormulario();

            ILivroController livroCtrl = ControllerFactory.ObterLivroController();
            livroCtrl.Cadastrar(livro);

            CarregarGridLivros();
        }

        private Livro ObterLivroFormulario()
        {
            return new Livro()
            {
                Id = string.IsNullOrWhiteSpace(txtId.Text) ? 0 : txtId.Text.ToInt32().Value
                ,
                Nome = txtNome.Text
                ,
                Editora = txtEditora.Text
                ,
                QtdeExemplares = txtQtdeExemplares.Text.ToInt32().Value
            };
        }

        private void AtribuirLivroSelecionado()
        {
            int idxId = grdLivros.GetColumnIndexByName("Id");
            txtId.Text = Server.HtmlDecode(grdLivros.SelectedRow.Cells[idxId].Text);

            int idxNome = grdLivros.GetColumnIndexByName("Nome");
            txtNome.Text = Server.HtmlDecode(grdLivros.SelectedRow.Cells[idxNome].Text);

            int idxEditora = grdLivros.GetColumnIndexByName("Editora");
            txtEditora.Text = Server.HtmlDecode(grdLivros.SelectedRow.Cells[idxEditora].Text);

            int idxQtdeExemplares = grdLivros.GetColumnIndexByName("QtdeExemplares");
            txtQtdeExemplares.Text = Server.HtmlDecode(grdLivros.SelectedRow.Cells[idxQtdeExemplares].Text);

            updDadosLivro.Update();            
        }

        private void ExibirMensagemErro(Exception ex)
        {
            lblModalTitle.Text = "Erro";
            lblModalBody.Text = ex.Message;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void grdLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AtribuirLivroSelecionado();
            }
            catch (Exception ex)
            {
                ExibirMensagemErro(ex);
            }            
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirSelecionados();
                this.Limpar();
                CarregarGridLivros();
            }
            catch (Exception ex)
            {
                ExibirMensagemErro(ex);
            }            
        }

        private void ExcluirSelecionados()
        {
            foreach (var linha in grdLivros.GetCheckedRows("chkExcluir"))
            {
                int idxId = grdLivros.GetColumnIndexByName("Id");
                int idLivro = Server.HtmlDecode(linha.Cells[idxId].Text).ToInt32().Value;

                ILivroController livroCtrl = ControllerFactory.ObterLivroController();
                livroCtrl.Remover(idLivro);
            }
        }
    }
}