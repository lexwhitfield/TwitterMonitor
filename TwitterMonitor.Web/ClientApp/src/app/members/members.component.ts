import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberService } from '../services/member.service';
import { PartyService } from '../services/party.service';
import { Member } from '../models/Member';
import { Party } from '../models/Party';

@Component({
    selector: 'app-members',
    templateUrl: './members.component.html',
    styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit {

    //members$: Observable<Member[]>;
    members: [];
    pageOfMembers: Array<Member>;

    //idFilter?: number;
    nameFilter?: string;
    partyFilter?: number;
    constituencyFilter?: string;
    //twitterNameFilter?: string;

    parties$: Observable<Party[]>;

    constructor(
        private memberService: MemberService,
        private partyService: PartyService) { }

    ngOnInit() {
        this.loadMembers();

        this.parties$ = this.partyService.getParties();
    }

    loadMembers() {
        console.log('Getting members...')
        this.memberService.getMembers(this.nameFilter, this.partyFilter, this.constituencyFilter)
            .subscribe(m => {
                this.members = m as [];
                console.log("members retrieved");
            })
    }

    delete(memberId) {
        const ans = confirm('Do you want to delete member with id: ' + memberId);

        if (ans) {
            this.memberService.deleteMember(memberId).subscribe((data) => {
                this.loadMembers();
            });
        }
    }

    onChangePage(pageOfItems: Array<Member>) {
        this.pageOfMembers = pageOfItems;
    }

    getPartyStyle(i: number, member: Member): any {
        
        var bgColor = member.latestPartyBgColour;
        var txtColor = member.latestPartyTextColour;

        return {
            'background-color': '#FF0000',
            'color': 'blue'
        };
    }

}
