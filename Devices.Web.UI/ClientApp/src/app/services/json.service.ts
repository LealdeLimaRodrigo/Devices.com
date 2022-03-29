import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs';
import { Device } from '../view_models/device';

@Injectable({
    providedIn: 'root'
})
export class JsonService {

    private jsonURL = 'assets/resources/json/devices.json';
    private jsonURL2 = 'assets/resources/json/device.json';
    private jsonURL3 = 'assets/resources/json/related_devices.json';

    constructor(private http: HttpClient) {}
    
    getDevices() : Observable<Device[]>{
        return this.http.get(this.jsonURL).pipe(
            map((response:any) => {return response;}),
            catchError(this.handleError)
        );
    }

    getDeviceById(id: number) : Observable<Device> {
        return this.http.get(this.jsonURL2).pipe(
            map((response:any) => {return response;}),
            catchError(this.handleError)
        );
    }
    
    getRelatedDevices() : Observable<Device[]>{
        return this.http.get(this.jsonURL3).pipe(
            map((response:any) => {return response;}),
            catchError(this.handleError)
        );
    }

    private handleError(error: HttpErrorResponse) {        
        if(error.status == 400){
            return throwError(() => new Error(
                'Bad Request: \n ' + error.error));
        }else if(error.status == 404){
            return throwError(() => new Error(
                'Register not found.'));
        }
        return throwError(() => new Error(
            'Something happened. Please, check the message below: \n' + error.message));            
    }

}