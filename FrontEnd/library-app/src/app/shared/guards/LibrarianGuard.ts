import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { SessionService } from '../services/session/session.service';
import { AuthService } from '../services/auth/auth.service';
import { LIBRARIAN } from '../constants/role-constants';
import { Observable, concatMap, of } from 'rxjs';
import { SnackBarService } from '../services/snackbar/snackbar.service';

export const LibrarianGuard: CanActivateFn = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ): Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree => {
    const session = inject(SessionService);
    const auth = inject(AuthService);
    const snackbar = inject(SnackBarService);
    const router = inject(Router);

    if (session.getToken() == undefined) {
        return inject(Router).createUrlTree(["/", "login"]);
    } else {
        auth.hasRole(LIBRARIAN).subscribe({
            next: (val) => {
                if(val) {
                    return true;
                } else {
                    router.navigate(['home']);
                    return false;
                }
            } 
        });
        return true;
    }
};
