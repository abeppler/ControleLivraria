using ControleLivraria2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLivraria2.Controller
{
    public interface ILivroController
    {
        void Cadastrar(Livro livro);

        void Remover(Livro livro);

        /// <summary>
        /// Retorna todos os livros ordenados pelo nome de forma descrescente.
        /// </summary>
        /// <returns></returns>
        List<Livro> ObterTodos();
        void Remover(int idLivro);
    }
}
