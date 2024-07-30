import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { map, Observable, of } from "rxjs";
import { SessionService } from "../services/session/session.service";
import { SnackBarService } from "../services/snackbar/snackbar.service";

export const SessionGuard: CanActivateFn = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ): Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree => {
    const session = inject(SessionService);
    const snackbar = inject(SnackBarService);

    if (session.getToken() == undefined) {
        return inject(Router).createUrlTree(["/", "login"]);
    } else {
        var timeString = session.getExpire();
        var tokenDate = new Date(timeString!);
        var currentDate = new Date();
        var tokenOffset = tokenDate.getTimezoneOffset();
        var currentOffset = tokenDate.getTimezoneOffset();
        tokenDate.setHours(tokenDate.getHours() + tokenOffset);
        currentDate.setHours(currentDate.getHours() + currentOffset);
        if(currentDate.getHours() - tokenDate.getHours() > 1) {
            session.clearSession();
            return inject(Router).createUrlTree(["/", "login"]);
        } else {
            return of(true);
        }
    }
};
  