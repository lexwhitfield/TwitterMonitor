export class Member {
    id?: number;
    dodsId?: number;
    pimsId?: number;
    clerksId?: number;

    titleId?: number;
    titleName?: string;
    forename: string;
    surname: string;

    genderId?: number;
    genderName?: string;

    dateOfBirth?: Date;
    dateOfDeath?: Date;

    twitterUserName: string;
    twitterId?: number;

    latestHouseId?: number;
    latestHouseName?: string;

    latestConstituencyId?: number;
    latestConstituencyName?: string;

    latestElectionId?: number;
    latestElectionName?: string;

    latestPartyId?: number;
    latestPartyName?: string;
    latestPartyBgColour?: string;
    latestPartyTextColour?: string;

    numberOfGovernmentPosts?: number;
    numberOfOppositionPosts?: number;
    numberOfParliamentaryPosts?: number;
    numberOfCommittees?: number;
}
