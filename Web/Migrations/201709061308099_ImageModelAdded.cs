namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Alt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.News", "ImageId");
            AddForeignKey("dbo.News", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            DropColumn("dbo.News", "Image_Url");
            DropColumn("dbo.News", "Image_Alt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Image_Alt", c => c.String());
            AddColumn("dbo.News", "Image_Url", c => c.String());
            DropForeignKey("dbo.News", "ImageId", "dbo.Images");
            DropIndex("dbo.News", new[] { "ImageId" });
            DropTable("dbo.Images");
        }
    }
}
