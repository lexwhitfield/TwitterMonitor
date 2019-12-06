export class Party {
    id?: number;
    name: string;
    abbr: string;
    initials: string;
    bgColour: string;
    textColour: string;
    isCommons: boolean;
    isLords: boolean;
    oldDisId?: number;
    hoLMainParty: boolean;
    hoLOrder?: number;
    hoLIsSpiritualSide: boolean;
    totalMemberCount: number;
    activeMemberCount: number;
}
