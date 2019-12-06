import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstituencyService } from '../services/constituency.service';
import { PartyService } from '../services/party.service';
import { AreaService } from '../services/area.service';
import { Constituency } from '../models/Constituency';
import { KeyValue } from '../models/KeyValue';
import { Party } from '../models/Party';

@Component({
    selector: 'app-constituencies',
    templateUrl: './constituencies.component.html',
    styleUrls: ['./constituencies.component.scss']
})
export class ConstituenciesComponent implements OnInit {

    constituencies: Constituency[];
    pageOfConstituencies: Array<Constituency>;

    nameFilter?: string;
    areaFilter?: number;
    partyFilter?: number;
    typeFilter?: number;
    currentFilter?: boolean;

    parties$: Observable<Party[]>;
    areas$: Observable<KeyValue[]>;
    constituencyTypes$: Observable<KeyValue[]>;

    constructor(
        private constituencyService: ConstituencyService,
        private partyService: PartyService,
        private areaService: AreaService
    ) { }

    ngOnInit() {
        this.loadConstituencies();

        this.parties$ = this.partyService.getParties();
        this.areas$ = this.areaService.getAreas();
        this.constituencyTypes$ = this.constituencyService.getConstituencyTypes();
    }

    loadConstituencies() {
        this.constituencyService.getConstituencies(this.nameFilter, this.typeFilter, this.areaFilter, this.partyFilter, this.currentFilter)
            .subscribe(c => { this.constituencies = c as [] });
    }

    delete(constituencyId) {
        const ans = confirm('Do you want to delete constituency with id: ' + constituencyId);

        if (ans) {
            this.constituencyService.deleteConstituency(constituencyId).subscribe((data) => {
                this.loadConstituencies();
            });
        }
    }

    onChangePage(pageOfItems: Array<Constituency>) {
        this.pageOfConstituencies = pageOfItems;
    }

}
