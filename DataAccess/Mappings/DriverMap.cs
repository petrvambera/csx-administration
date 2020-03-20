using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DataAccess.Model;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class DriverMap : ClassMap<Driver>
{
        public DriverMap()
        {
            Table("Drivers");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.DriverName).Not.Nullable().CustomSqlType("nvarchar(50)");
            Map(x => x.DriverSurname).Not.Nullable().CustomSqlType("nvarchar(50)");
            Map(x => x.DriverEmail).Not.Nullable().CustomSqlType("nvarchar(50)");
            Map(x => x.DriverPhoneNumber).Not.Nullable().CustomSqlType("nvarchar(50)");
            References(x => x.CarId).Column("CarId");

        }

    }
}
