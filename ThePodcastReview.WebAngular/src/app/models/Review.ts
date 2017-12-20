export interface Review {
    ReviewId?: number;
    OwnerId?: number;
    PodcastTitle: string;
    Rating: number;
    ContentTrimmed: string;
    CreatedUtc?: Date;
    ModifiedUtc?: Date;
}