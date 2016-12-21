namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201612201 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LearningPlans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LearningType = c.String(),
                        Description = c.String(),
                        LearningPlanParentID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LearningPlans", t => t.LearningPlanParentID_ID)
                .Index(t => t.LearningPlanParentID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LearningPlans", "LearningPlanParentID_ID", "dbo.LearningPlans");
            DropIndex("dbo.LearningPlans", new[] { "LearningPlanParentID_ID" });
            DropTable("dbo.LearningPlans");
        }
    }
}
