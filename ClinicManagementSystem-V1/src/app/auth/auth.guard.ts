// import { Injectable } from '@angular/core';
// import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
// import { Observable } from 'rxjs';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthGuard implements CanActivate {
//   canActivate(
//     route: ActivatedRouteSnapshot,
//     state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
//     return true;
//   }
  
// }

import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ServiceService } from '.././service.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router : Router,private userService : ServiceService){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean {
      if (localStorage.getItem('userToken') != null)
      {
      let roles = next.data["roles"] as Array<string>;
        if (roles) {
          var match = this.userService.roleMatch(roles);
          if (match) return true;
          else {
            this.router.navigate(['/forbidden']);
            return false;
          }
        }
        else
          return true;
      }
      this.router.navigate(['/login']);
      return false;
  }
}
