using ControleLivraria2.Helpers;
using ControleLivraria2.Model;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleLivraria2.Controller.Implement
{
    public class LivroController : ILivroController
    {
        public void Cadastrar(Livro livro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(livro);
                    transaction.Commit();
                }
            }
        }

        public void Remover(Livro livro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(livro);
                    transaction.Commit();
                }
            }
        }

        public void Remover(int idLivro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var livro = session.Query<Livro>().Where(x => x.Id == idLivro).FirstOrDefault();
                    session.Delete(livro);
                    transaction.Commit();
                }
            }
        }

        public List<Livro> ObterTodos()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {                
                return session.Query<Livro>()
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }
    }
}