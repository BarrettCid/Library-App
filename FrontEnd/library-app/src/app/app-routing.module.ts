import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './views/welcome/welcome.component';
import { LoginComponent } from './views/login/login.component';
import { BookComponent } from './views/book/book.component';
import { HomeComponent } from './views/home/home.component';
import { RegisterComponent } from './views/register/register.component';
import { BookSearchComponent } from './views/book-search/book-search.component';
import { ManageBookComponent } from './views/manage-book/manage-book.component';
import { SessionGuard } from './shared/guards/SessionGuard';
import { LibrarianGuard } from './shared/guards/LibrarianGuard';
import { LIBRARIAN } from './shared/constants/role-constants';

export const routes: Routes = [
  { path: '', redirectTo: '/welcome', pathMatch: 'full' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'home', component: HomeComponent, canMatch: [SessionGuard] },
  { path: 'book/:bookId', component: BookComponent, canMatch: [SessionGuard] },
  { path: 'book-search', component: BookSearchComponent, canMatch: [SessionGuard] },
  { path: 'manage-book/:bookId', component: ManageBookComponent, canMatch: [SessionGuard, LibrarianGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
