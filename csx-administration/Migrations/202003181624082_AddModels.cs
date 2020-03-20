namespace csx_administration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarMark = c.String(),
                        CarModel = c.String(),
                        YearOfManufacture = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                        DriverSurname = c.String(),
                        DriverEmail = c.String(),
                        DriverPhoneNumber = c.String(),
                        CarId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId_Id)
                .Index(t => t.CarId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "CarId_Id", "dbo.Cars");
            DropIndex("dbo.Drivers", new[] { "CarId_Id" });
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
