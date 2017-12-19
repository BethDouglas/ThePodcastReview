namespace ThePodcastReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhoKnows : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Review", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "UserName", c => c.String(nullable: false));
        }
    }
}
