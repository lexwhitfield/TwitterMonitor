import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Area } from '../models/Area';
import { KeyValue } from '../models/KeyValue';

@Injectable({
    providedIn: 'root'
})
export class AreaService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/area/';
    }

    getAreas(name?: string, areaTypeId?: number): Observable<Area[]> {
        let params = new HttpParams();
        if (name !== undefined)
            params = params.set('name', name);
        if (areaTypeId !== undefined)
            params = params.set('areaTypeId', String(areaTypeId));

        return this.http.get<Area[]>(this.myAppUrl + this.myApiUrl, { params: params })
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getArea(areaId: number): Observable<Area> {
        return this.http.get<Area>(this.myAppUrl + this.myApiUrl + areaId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    importAreas() {
        this.http.get(this.myAppUrl + this.myApiUrl + "importareas")
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getAreaTypes(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getareatypes")
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    errorHandler(error) {
        let errorMessage = '';

        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }

        console.log(errorMessage);
        return throwError(errorMessage);
    }
}
