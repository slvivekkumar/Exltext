import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { map, catchError, debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { UserDataService } from './user-data.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';



@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit , AfterViewInit{
  @ViewChild('mySearchInput') mySearchInput: ElementRef| undefined;

  @ViewChild('myStartDateInput') myStartDateInput: ElementRef| undefined;
  @ViewChild('myEndDateInput') myEndDateInput: ElementRef| undefined;

  Users: any;
  columns: any;
  columnsHeader: any;
  searchkeyword: any;
  searchstartdate: any;
   searchenddate: any;
  constructor(private _userDataService: UserDataService, private bsDatepickerConfig : BsDatepickerConfig ) { }

  ngOnInit(): void {
    
    this.columns = ["id","name", "jobTitle", "age", "empStartDate", "empEndDate"];
      this._userDataService.getUsers().subscribe(data=>{
      this.Users = data;

    })
    
    this.columnsHeader = ["Id","Name", "JobTitle", "Age", "Start Date", "End Date"];

   
  }

  ngAfterViewInit():void{

    const SearchBy =    fromEvent<any>(this.mySearchInput?.nativeElement,'keyup').pipe( 
      map(event=> event.target.value),
      debounceTime(500),
      distinctUntilChanged()
    );

    const SearchByStartDate =    fromEvent<any>(this.myStartDateInput?.nativeElement,'change').pipe( 
      map(event=> event.target.value),
      debounceTime(500),
      distinctUntilChanged()
    );

    const SearchByEndDate =    fromEvent<any>(this.myEndDateInput?.nativeElement,'change').pipe( 
      map(event=> event.target.value),
      debounceTime(500),
      distinctUntilChanged()
    );
    
    SearchBy.subscribe(res=>{
      this.searchkeyword=res;
      res=== undefined?  this._userDataService.getUsers().subscribe(data=>{
                          this.Users = data  }):
                          this._userDataService.getSearchUsers(res).subscribe(data=>{
                            this.Users = data;
        });
    });

    SearchByStartDate.subscribe(res=>{
      this.searchstartdate=res;
      console.log(res);
    });

    SearchByEndDate.subscribe(res=>{
      this.searchenddate=res;
      console.log(res);

    });


   

  }

}
