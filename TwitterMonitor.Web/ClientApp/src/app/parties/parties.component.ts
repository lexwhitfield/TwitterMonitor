import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PartyService } from '../services/party.service';
import { Party } from '../models/Party';

@Component({
    selector: 'app-parties',
    templateUrl: './parties.component.html',
    styleUrls: ['./parties.component.scss']
})
export class PartiesComponent implements OnInit {

    parties: [];
    pageOfParties: Array<Party>;

    nameFilter?: string;
    withMembersFilter?: boolean;
    withActiveMembersFilter?: boolean;

    constructor(private partyService: PartyService) { }

    ngOnInit() {
        this.loadParties();
    }

    loadParties() {
        this.partyService.getParties(this.nameFilter, this.withMembersFilter, this.withActiveMembersFilter)
            .subscribe(p => {
                this.parties = p as [];
            });
    }

    delete(partyId) {
        const ans = confirm('Do you want to delete party with id: ' + partyId);

        if (ans) {
            this.partyService.deleteParty(partyId).subscribe((data) => {
                this.loadParties();
            });
        }
    }

    onChangePage(pageOfItems: Array<Party>) {
        this.pageOfParties = pageOfItems;
    }

}
