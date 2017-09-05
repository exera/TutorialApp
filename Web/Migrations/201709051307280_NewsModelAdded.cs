namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageId = c.Int(nullable: false),
                        Image_Url = c.String(),
                        Image_Alt = c.String(),
                        Date = c.DateTime(nullable: false),
                        Tags = c.String(),
                        Category = c.String(),
                        Slug = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
        }
    }
}
