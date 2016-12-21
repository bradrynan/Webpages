namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Webpages",
                c => new
                    {
                        WebPageID = c.Int(nullable: false, identity: true),
                        URLAddress = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.WebPageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Webpages");
        }
    }
}
