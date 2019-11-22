import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../models/Member';

@Injectable({
    providedIn: 'root'
})
export class MemberService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json;'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/members/';
    }

    getMembers(id?: number, name?: string, partyId?: number, constituencyName?: string, twitterName?: string): Observable<Member[]> {
        let params = new HttpParams();
        if (id !== undefined)
            params = params.set('id', String(id))
        if (name !== undefined)
            params = params.set('name', name);
        if (partyId !== undefined)
            params = params.set('partyId', String(partyId));
        if (constituencyName !== undefined)
            params = params.set('constituency', String(constituencyName));
        if (twitterName !== undefined)
            params = params.set('twitterName', twitterName);

        return this.http.get<Member[]>(this.myAppUrl + this.myApiUrl, { params: params })
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getMember(memberId: number): Observable<Member> {
        return this.http.get<Member>(this.myAppUrl + this.myApiUrl + memberId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    saveMember(member): Observable<Member> {
        var jsonMember = JSON.stringify(member);
        return this.http.post<Member>(this.myAppUrl + this.myApiUrl, jsonMember, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    updateMember(memberId: number, member): Observable<Member> {
        return this.http.put<Member>(this.myAppUrl + this.myApiUrl + memberId, JSON.stringify(member), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    deleteMember(memberId: number): Observable<Member> {
        return this.http.delete<Member>(this.myAppUrl + this.myApiUrl + memberId)
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
