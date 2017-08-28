namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentModelAddressFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CityId", c => c.Int());
            AddColumn("dbo.Students", "DistrictId", c => c.Int());
            AddColumn("dbo.Students", "AddressLine1", c => c.String());
            CreateIndex("dbo.Students", "CityId");
            CreateIndex("dbo.Students", "DistrictId");
            AddForeignKey("dbo.Students", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Students", "DistrictId", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Students", "CityId", "dbo.Cities");
            DropIndex("dbo.Students", new[] { "DistrictId" });
            DropIndex("dbo.Students", new[] { "CityId" });
            DropColumn("dbo.Students", "AddressLine1");
            DropColumn("dbo.Students", "DistrictId");
            DropColumn("dbo.Students", "CityId");
        }
    }
}
