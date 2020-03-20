using DataAccess.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("Cars");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.CarMark).CustomSqlType("nvarchar(50)").Not.Nullable();
            Map(x => x.CarModel).CustomSqlType("nvarchar(50)").Not.Nullable();
            Map(x => x.YearOfManufacture).CustomSqlType("int").Not.Nullable();
            Map(x => x.EnginePower).CustomSqlType("int").Not.Nullable();
            Map(x => x.IsFree).CustomSqlType("bit").Not.Nullable();
            References(x => x.CurrentDriver).Column("CurrentDriver");
        }
    }
}
