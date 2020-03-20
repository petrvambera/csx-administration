using DataAccess.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csx_administration.Tests.DbSchema
{
    [TestClass]
    public class DbSchema
    {
        [TestMethod]
        public void GenerateSchema()
        {
            var configuration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(LocalDb)MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-csx-administration-20200307052043.mdf;Initial Catalog=aspnet-csx-administration-20200307052043;Integrated Security=True"))
                                                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Car>()).BuildConfiguration();

            new SchemaExport(configuration).Execute(false, true, false);
              
        }
    }
}
