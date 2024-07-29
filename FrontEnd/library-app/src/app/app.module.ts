import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedMaterialModule } from './shared/SharedMaterialModule';
import { HeaderComponent } from "./views/header/header.component";
import { WelcomeComponent } from './views/welcome/welcome.component';
import { routes } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { provideAnimations } from '@angular/platform-browser/animations';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './views/login/login.component';
import { BookComponent } from './views/book/book.component';
import { provideHttpClient } from '@angular/common/http';
import { ReviewComponent } from './views/review/review.component';
import { RegisterComponent } from './views/register/register.component';
import { HomeComponent } from './views/home/home.component';
import { BookSearchComponent } from './views/book-search/book-search.component';
import { ManageBookComponent } from './views/manage-book/manage-book.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    HeaderComponent,
    LoginComponent,
    BookComponent,
    ReviewComponent,
    RegisterComponent,
    HomeComponent,
    BookSearchComponent,
    ManageBookComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
    SharedMaterialModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
],
  providers: [provideAnimations(), provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
