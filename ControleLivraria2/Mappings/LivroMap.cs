using ControleLivraria2.Model;
using FluentNHibernate.Mapping;

namespace ControleLivraria2.Mappings
{
    public class LivroMap: ClassMap<Livro>
    {
        public LivroMap()
        {
            Id(x => x.Id);

            Map(x => x.Nome);
            Map(x => x.Editora);
            Map(x => x.QtdeExemplares);

            Table("Livros");
        }
    }
}