import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ElectionService } from '../services/election.service';
import { Election } from '../models/Election';
import { KeyValue } from '../models/KeyValue';

@Component({
    selector: 'app-elections',
    templateUrl: './elections.component.html',
    styleUrls: ['./elections.component.scss']
})
export class ElectionsComponent implements OnInit {

    elections: [];
    pageOfElections: Array<Election>;

    electionTypeFilter?: number;

    electionTypes$: Observable<KeyValue[]>;

    constructor(private electionService: ElectionService) { }

    ngOnInit() {
        this.loadElections();

        this.electionTypes$ = this.electionService.getElectionTypes();
    }

    loadElections() {
        this.electionService.getElections(this.electionTypeFilter)
            .subscribe(e => {
                this.elections = e as [];
            });
    }

    onChangePage(pageOfItems: Array<Election>) {
        this.pageOfElections = pageOfItems;
    }

}
