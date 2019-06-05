namespace Ex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lon = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        Rudder = c.Double(nullable: false),
                        Throttle = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlightDatas");
        }
    }
}
