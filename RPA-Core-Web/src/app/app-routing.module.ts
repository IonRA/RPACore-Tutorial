import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminInterfaceComponent} from './admin-interface/admin-interface.component';
import {LoginComponent} from './login/login.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {RegisterComponent} from './register/register.component';
import {UserRoleEditComponent} from './admin-interface/user-role-edit.component';
import {AuthGuardService as AuthGuard} from '../service/AuthGuardService';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    data: {title: 'RPA Core'}
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {title: 'Login'}
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {title: 'Register'}
  },
  {
    path: 'admin',
    component: AdminInterfaceComponent,
    data: {title: 'Admin Interface'},
    canActivate: [AuthGuard]
  },
  {
    path: 'admin/edit-role/:roleName',
    component: UserRoleEditComponent,
    data: {title: 'Edit Roles Interface'},
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
