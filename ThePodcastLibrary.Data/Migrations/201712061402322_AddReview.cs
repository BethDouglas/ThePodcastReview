namespace ThePodcastLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PodcastTitle = c.String(nullable: false, maxLength: 200),
                        Episode = c.String(maxLength: 200),
                        Rating = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 2000),
                        FavEpisodes = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Review");
        }
    }
}
