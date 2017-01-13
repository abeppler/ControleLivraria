using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleLivraria2.Model
{
    public class Livro
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Editora { get; set; }
        public virtual int QtdeExemplares { get; set; }
    }
}