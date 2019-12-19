import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TwitterUser } from '../models/TwitterUser';
import { Tweet } from '../models/Tweet';

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

    getTweets(memberId: number): Observable<Tweet[]> {
        return this.http.get<Tweet[]>(this.myAppUrl + this.myApiUrl + "tweets/" + memberId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getLatestTweets(memberId: number) {
        var url = this.myAppUrl + this.myApiUrl + "getlatesttweets/" + memberId;
        this.http.get<boolean>(url)
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
