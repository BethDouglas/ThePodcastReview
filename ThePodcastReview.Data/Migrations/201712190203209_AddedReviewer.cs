namespace ThePodcastReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Review", "Episode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "Episode", c => c.String(maxLength: 200));
            DropColumn("dbo.Review", "UserName");
        }
    }
}
