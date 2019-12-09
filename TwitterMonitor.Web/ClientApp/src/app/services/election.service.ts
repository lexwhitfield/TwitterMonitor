import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Election } from '../models/Election';
import { KeyValue } from '../models/KeyValue';

@Injectable({
    providedIn: 'root'
})
export class ElectionService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/elections/';
    }

    getElections(electionTypeId?: number): Observable<Election[]> {
        let params = new HttpParams();
        if (electionTypeId !== undefined)
            params = params.set('electionTypeId', String(electionTypeId));

        return this.http.get<Election[]>(this.myAppUrl + this.myApiUrl, { params: params })
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getElectionTypes(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getelectiontypes")
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
