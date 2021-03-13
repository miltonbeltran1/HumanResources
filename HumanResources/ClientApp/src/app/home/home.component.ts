import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './model/Employee';
import {  HomeService } from './service/home.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {  
  
  isErrorMessage: boolean;
  employees: Employee[];
  filter: number;
  constructor(private dataService: HomeService) { 
  }

  cleanData(){
    this.isErrorMessage = false;
    this.employees = [];
  }
  getEmployees(){
    this.cleanData();
    if(this.filter == undefined){
      this.dataService.getAllEmployees().subscribe(result =>{
        if(result !== null){
          this.employees = result;
        }else{
          this.isErrorMessage = true;
        }
      },err => {console.error(err), this.isErrorMessage = true;});
    }else
    {
      this.dataService.getEmployee(this.filter).subscribe(result =>{
        if(result !== null){
          this.employees.push(result);
        }else{
          this.isErrorMessage = true;
        }
      },err => {console.error(err), this.isErrorMessage = true;});
    }
}
}
