export interface Review {
    ReviewId?: number;
    OwnerId?: number;
    PodcastTitle: string;
    Rating: number;
    CreatedUtc?: Date;
    ModifiedUtc?: Date;
}