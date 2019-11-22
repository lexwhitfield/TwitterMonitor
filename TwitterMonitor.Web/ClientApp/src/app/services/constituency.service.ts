import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Constituency } from '../models/Constituency';
import { KeyValue } from '../models/KeyValue';

@Injectable({
    providedIn: 'root'
})
export class ConstituencyService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/constituencies/';
    }

    getConstituencies(name?: string, authorityId?: number, regionId?: number, countryId?: number): Observable<Constituency[]> {
        let params = new HttpParams();
        if (name !== undefined)
            params = params.set('name', name);
        if (authorityId !== undefined)
            params = params.set('authorityId', String(authorityId));
        if (regionId !== undefined)
            params = params.set('regionId', String(regionId));
        if (countryId !== undefined)
            params = params.set('countryId', String(countryId));

        return this.http.get<Constituency[]>(this.myAppUrl + this.myApiUrl, { params: params })
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getConstituency(constituencyId: number): Observable<Constituency> {
        return this.http.get<Constituency>(this.myAppUrl + this.myApiUrl + constituencyId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    saveConstituency(constituency): Observable<Constituency> {
        return this.http.post<Constituency>(this.myAppUrl + this.myApiUrl, JSON.stringify(constituency), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    updateConstituency(constituencyId: number, constituency): Observable<Constituency> {
        return this.http.put<Constituency>(this.myAppUrl + this.myApiUrl + constituencyId, JSON.stringify(constituency), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    deleteConstituency(constituencyId: number): Observable<Constituency> {
        return this.http.delete<Constituency>(this.myAppUrl + this.myApiUrl + constituencyId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getAuthorities(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getauthorities")
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getRegions(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getregions")
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getCountries(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getcountries")
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
