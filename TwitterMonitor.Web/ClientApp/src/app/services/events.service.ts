import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Event } from '../models/Event';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

    myAppUrl: string;
    myApiUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json;'
        })
    };

    constructor(private http: HttpClient) {
        this.myAppUrl = environment.appUrl;
        this.myApiUrl = 'api/events/';
    }

    getEvents(id?: number, title?: string, happened?: Date): Observable<Event[]> {
        return this.http.get<Event[]>(this.myAppUrl + this.myApiUrl)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    getEvent(eventId: number): Observable<Event> {
        return this.http.get<Event>(this.myAppUrl + this.myApiUrl + eventId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    saveEvent(event): Observable<Event> {
        var jsonEvent = JSON.stringify(event);
        return this.http.post<Event>(this.myAppUrl + this.myApiUrl, jsonEvent, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    updateEvent(eventId: number, event): Observable<Event> {
        return this.http.put<Event>(this.myAppUrl + this.myApiUrl + eventId, JSON.stringify(event), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    deleteEvent(eventId: number): Observable<boolean> {
        return this.http.delete<boolean>(this.myAppUrl + this.myApiUrl + eventId)
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
