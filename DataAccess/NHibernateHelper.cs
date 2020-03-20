using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace DataAccess
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = null;

        public static ISession Session
        {
            get
            {
                if (factory == null)
                {
                    factory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection")))
                        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Car>())
                        .BuildSessionFactory();

                }
                return factory.OpenSession(); 
            }
        }
    }
}
