import { Inject, Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, delay, map } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Employee } from '../model/Employee';


@Injectable({
    providedIn: 'root'
})
export class HomeService {

    public forecasts: Employee[];
    constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    getDataFromResponse(response){
        if(response.success)
        {
            return response.data;
        }
        else
        {
            console.log("Error");
            console.log(response.messagge);
            return response.messagge;
        }
    }

    getAllEmployees() : Observable<Employee[]>{
           return this.http.get(this.baseUrl + 'Catalog/api/v1_0/Employee/GetAll/').pipe(
            map(response => {
                return  this.getDataFromResponse(response);
                }
              ),
                catchError(this.handleError)
            ); 
        }

        getEmployee(filter) : Observable<Employee>{
             return this.http.get(this.baseUrl + 'Catalog/api/v1_0/Employee/Get?filter='+filter).pipe(
              map(response => {
                  return  this.getDataFromResponse(response);
                  }
                ),
                  catchError(this.handleError)
              ); 
          }

    handleError(err: HttpErrorResponse) {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
    
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
    
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
      }
}