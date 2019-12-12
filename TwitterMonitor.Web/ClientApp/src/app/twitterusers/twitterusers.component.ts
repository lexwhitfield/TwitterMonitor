import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberService } from '../services/member.service';
import { PartyService } from '../services/party.service';
import { Member } from '../models/Member';
import { Party } from '../models/Party';

@Component({
    selector: 'app-twitterusers',
    templateUrl: './twitterusers.component.html',
    styleUrls: ['./twitterusers.component.scss']
})
export class TwitterusersComponent implements OnInit {

    members: [];
    pageOfMembers: Array<Member>;

    nameFilter?: string;
    partyFilter?: number;
    constituencyFilter?: string;

    parties$: Observable<Party[]>;

    constructor(
        private memberService: MemberService,
        private partyService: PartyService) { }

    ngOnInit() {
        this.loadMembers();

        this.parties$ = this.partyService.getParties(undefined, true, undefined);
    }

    loadMembers() {
        this.memberService.getMembersWithTwitter(this.nameFilter, this.partyFilter, this.constituencyFilter)
            .subscribe(m => {
                this.members = m as [];
            });
    }

    onChangePage(pageOfItems: Array<Member>) {
        this.pageOfMembers = pageOfItems;
    }

}
