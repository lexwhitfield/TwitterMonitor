import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstituencyService } from '../services/constituency.service';
import { Constituency } from '../models/Constituency';
import { KeyValue } from '../models/KeyValue';

@Component({
    selector: 'app-constituencies',
    templateUrl: './constituencies.component.html',
    styleUrls: ['./constituencies.component.scss']
})
export class ConstituenciesComponent implements OnInit {

    constituencies: Constituency[];
    pageOfConstituencies: Array<Constituency>;

    nameFilter?: string;
    authorityFilter?: number;
    regionFilter?: number;
    countryFilter?: number;

    authorities$: Observable<KeyValue[]>;
    regions$: Observable<KeyValue[]>;
    countries$: Observable<KeyValue[]>;

    constructor(private constituencyService: ConstituencyService) { }

    ngOnInit() {
        this.loadConstituencies();
    }

    loadConstituencies() {
        this.constituencyService.getConstituencies()
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
