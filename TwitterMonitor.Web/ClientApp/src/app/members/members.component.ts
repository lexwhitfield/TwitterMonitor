import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberService } from '../services/member.service';
import { PartyService } from '../services/party.service';
import { Member } from '../models/Member';
import { Party } from '../models/Party';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit {

  members: [];
  pageOfMembers: Array<Member>;

  nameFilter?: string;
  partyFilter?: number;
  constituencyFilter?: string;

  constituencyId?: number;
  electionId?: number;

  parties$: Observable<Party[]>;

  constructor(
    private memberService: MemberService,
    private partyService: PartyService,
    private avRoute: ActivatedRoute) { }

  ngOnInit() {
    const electionIdParam = 'electionId';
    const constituencyIdParam = 'constituencyId';
    if (this.avRoute.snapshot.queryParams[electionIdParam]) {
      this.electionId = this.avRoute.snapshot.queryParams[electionIdParam];
    }

    if (this.avRoute.snapshot.queryParams[constituencyIdParam]) {
      this.constituencyId = this.avRoute.snapshot.queryParams[constituencyIdParam];
    }

    this.loadMembers();

    this.parties$ = this.partyService.getParties(undefined, true, undefined);
  }

  loadMembers() {
    this.memberService.getMembers(this.nameFilter, this.partyFilter, this.constituencyFilter, this.electionId, this.constituencyId)
      .subscribe(m => {
        this.members = m as [];
      });
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
