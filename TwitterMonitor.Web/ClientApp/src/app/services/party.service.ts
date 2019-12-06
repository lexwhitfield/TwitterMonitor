import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Party } from '../models/Party';

@Injectable({
    providedIn: 'root'
})
export class PartyService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/parties';
    }

    getParties(name?: string, withMembers?: boolean, withActiveMembers?: boolean): Observable<Party[]> {
        let params = new HttpParams();
        if (name !== undefined)
            params = params.set('name', name);
        if (withMembers !== undefined)
            params = params.set('withMembers', String(withMembers));
        if (withActiveMembers !== undefined)
            params = params.set('withActiveMembers', String(withActiveMembers));

        return this.http.get<Party[]>(this.myAppUrl + this.myApiUrl, { params: params })
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getParty(partyId: number): Observable<Party> {
        return this.http.get<Party>(this.myAppUrl + this.myApiUrl + partyId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    saveParty(party): Observable<Party> {
        return this.http.post<Party>(this.myAppUrl + this.myApiUrl, JSON.stringify(party), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    updateParty(partyId: number, party): Observable<Party> {
        return this.http.put<Party>(this.myAppUrl + this.myApiUrl + partyId, JSON.stringify(party), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    deleteParty(partyId: number): Observable<Party> {
        return this.http.delete<Party>(this.myAppUrl + this.myApiUrl + partyId)
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
