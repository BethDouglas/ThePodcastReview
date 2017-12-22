USE ThePodcastREview
GO

SELECT PodcastTitle, Rating   
    FROM dbo.Review  
GO

SELECT PodcastTitle, FavEpisodes
	FROM dbo.Review
GO

SELECT PodcastTitle, Rating
	FROM dbo.Review
	WHERE Rating >3
GO

SELECT 