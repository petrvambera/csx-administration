namespace csx_administration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "CarId_Id", "dbo.Cars");
            DropIndex("dbo.Drivers", new[] { "CarId_Id" });
            RenameColumn(table: "dbo.Drivers", name: "CarId_Id", newName: "CarId");
            AddColumn("dbo.Cars", "IsFree", c => c.Boolean(nullable: true));
            AddColumn("dbo.Cars", "CurrentDriver", c => c.Int(nullable: true));
            AlterColumn("dbo.Cars", "CarMark", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "CarModel", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "DriverName", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "DriverSurname", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "CarId", c => c.Int(nullable: true));
            CreateIndex("dbo.Drivers", "CarId");
            AddForeignKey("dbo.Drivers", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropIndex("dbo.Drivers", new[] { "CarId" });
            AlterColumn("dbo.Drivers", "CarId", c => c.Int());
            AlterColumn("dbo.Drivers", "DriverSurname", c => c.String());
            AlterColumn("dbo.Drivers", "DriverName", c => c.String());
            AlterColumn("dbo.Cars", "CarModel", c => c.String());
            AlterColumn("dbo.Cars", "CarMark", c => c.String());
            DropColumn("dbo.Cars", "CurrentDriver");
            DropColumn("dbo.Cars", "IsFree");
            RenameColumn(table: "dbo.Drivers", name: "CarId", newName: "CarId_Id");
            CreateIndex("dbo.Drivers", "CarId_Id");
            AddForeignKey("dbo.Drivers", "CarId_Id", "dbo.Cars", "Id");
        }
    }
}
