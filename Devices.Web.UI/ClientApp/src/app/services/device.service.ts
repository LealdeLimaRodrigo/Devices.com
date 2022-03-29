import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from "src/environments/environment";
import { Device } from "../view_models/device";

@Injectable({
    providedIn: 'root'
})
export class DeviceService {
    url = environment.apiUrl;
    constructor(private http: HttpClient){}

    getDevices() : Observable<Device[]>{
        return this.http.get(this.url).pipe(
            map((response:any) => {return response;}),
            catchError(this.handleError)
        );
    }

    getDeviceById(id: number) : Observable<Device> {
        return this.http.get(this.url + '/' + id).pipe(
            map((response:any) => {return response;}),
            catchError(this.handleError)
        );
    }
    
    getRelatedDevices() : Observable<Device[]>{
        return this.http.get(this.url).pipe(
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