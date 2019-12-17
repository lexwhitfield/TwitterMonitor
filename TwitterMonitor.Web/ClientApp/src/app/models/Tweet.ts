export class Tweet {
    id: number;
    fullText: string;
    createdAt: Date;
    isRetweet: boolean;
    hashtagCount: number;
    hashtags: string;
    userMentionCount: number;
    userMentions: string;
    urlCount: number;
}
