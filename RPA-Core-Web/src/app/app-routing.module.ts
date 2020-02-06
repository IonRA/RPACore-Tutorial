import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminInterfaceComponent} from './admin-interface/admin-interface.component';
import {LoginComponent} from './login/login.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {RegisterComponent} from './register/register.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    data: {title: 'RPA Core'}
  },
  {
    path: 'admin',
    component: AdminInterfaceComponent,
    data: {title: 'Admin Interface'}
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
