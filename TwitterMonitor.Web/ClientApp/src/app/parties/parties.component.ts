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

    parties$: Observable<Party[]>;

    constructor(private partyService: PartyService) { }

    ngOnInit() {
        this.loadParties();
    }

    loadParties() {
        this.parties$ = this.partyService.getParties();
    }

    delete(partyId) {
        const ans = confirm('Do you want to delete party with id: ' + partyId);

        if (ans) {
            this.partyService.deleteParty(partyId).subscribe((data) => {
                this.loadParties();
            });
        }
    }

}
