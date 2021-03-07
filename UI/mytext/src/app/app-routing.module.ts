import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateuserComponent } from './User/createuser.component';
import { UserListComponent } from './User/user-list.component';

const routes: Routes = [{path:'list',component: UserListComponent, pathMatch:"full"},
{path:'create',component: CreateuserComponent, pathMatch:"full"},
{path: '',  redirectTo: '/list', pathMatch: 'full'}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

  
}
