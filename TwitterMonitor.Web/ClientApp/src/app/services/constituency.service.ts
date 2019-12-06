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

    getConstituencies(name?: string, typeId?: number, areaId?: number, partyId?:number, current?: boolean): Observable<Constituency[]> {
        let params = new HttpParams();
        if (name !== undefined)
            params = params.set('name', name);
        if (typeId !== undefined)
            params = params.set('constituencyTypeId', String(typeId));
        if (areaId !== undefined)
            params = params.set('areaId', String(areaId));
        if (partyId !== undefined)
            params = params.set('partyId', String(partyId));
        if (current !== undefined)
            params = params.set('current', String(current));

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

    getConstituencyTypes(): Observable<KeyValue[]> {
        return this.http.get<KeyValue[]>(this.myAppUrl + this.myApiUrl + "getconstituencytypes")
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
