import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TwitterUser } from '../models/TwitterUser';

@Injectable({
    providedIn: 'root'
})
export class TweetService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/tweetusers/';
    }

    getTweetUser(userId: number): Observable<TwitterUser> {
        return this.http.get<TwitterUser>(this.myAppUrl + this.myApiUrl + userId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    updateTweetUser(userId: number): Observable<TwitterUser> {
        return this.http.post<TwitterUser>(this.myAppUrl + this.myApiUrl, userId)
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
