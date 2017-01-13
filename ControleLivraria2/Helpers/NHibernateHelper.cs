using ControleLivraria2.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleLivraria2.Helpers
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Livraria;Integrated Security=True")
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Livro>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false,false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}