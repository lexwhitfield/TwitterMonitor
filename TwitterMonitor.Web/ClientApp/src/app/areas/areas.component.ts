import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AreaService } from '../services/area.service';
import { Area } from '../models/Area';
import { KeyValue } from '../models/KeyValue';

@Component({
    selector: 'app-areas',
    templateUrl: './areas.component.html',
    styleUrls: ['./areas.component.scss']
})
export class AreasComponent implements OnInit {

    areas: Area[];
    pageOfAreas: Array<Area>;

    nameFilter?: string;
    areaTypeFilter?: number;

    areaTypes$: Observable<KeyValue[]>

    constructor(private areaService: AreaService) { }

    ngOnInit() {
        this.loadAreas();

        this.areaTypes$ = this.areaService.getAreaTypes();
    }

    loadAreas() {
        this.areaService.getAreas(this.nameFilter, this.areaTypeFilter)
            .subscribe(a => { this.areas = a as [] });
    }

    import() {
        this.areaService.importAreas();
    }

    onChangePage(pageOfItems: Array<Area>) {
        this.pageOfAreas = pageOfItems;
    }

}
