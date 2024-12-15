import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import {
  NavigationItemsWrapper,
  NavigationRoute,
  privateNavigationItems,
  publicNavigationItems,
} from './navigation-item';
import { NavigationStart, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
export { NavigationItemsWrapper, NavigationRoute } from './navigation-item';

@Component({
  selector: 'app-header-navigator',
  templateUrl: './header-navigator.component.html',
  styleUrl: './header-navigator.component.scss',
})
export class HeaderNavigatorComponent implements OnInit, OnDestroy {
  links: NavigationRoute[] = [];
  menu: string = '';
  submenu: string = '';
  private ngUnsubscribe = new Subject();
  constructor(private authService: AuthService, private router: Router) {}

  ngOnDestroy(): void {
    this.ngUnsubscribe.complete();
  }

  ngOnInit(): void {
    this.initMenuLinks();
    this.navigationMenuActiveHighlight();
  }

  initMenuLinks(): void {
    this.authService.currentUser
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((user) => {
        let navigationMenuItemsTemp: NavigationRoute[] = [];
        if (user) {
          navigationMenuItemsTemp = privateNavigationItems;
        } else navigationMenuItemsTemp = publicNavigationItems;

        navigationMenuItemsTemp.forEach((el: NavigationRoute) => {
          el.submenu = el.submenu.filter(
            (subElement: NavigationRoute) =>
              subElement.roles.length === 0 ||
              this.authService.hasAccess(subElement.roles)
          );
        });
        this.links = navigationMenuItemsTemp
          .filter(
            (e: NavigationRoute) =>
              e.roles.length === 0 || this.authService.hasAccess(e.roles)
          )
          .map((ele: NavigationRoute) => ({ ...ele }));
      });
  }

  navigationMenuActiveHighlight(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        const splittedUrl = event.url.split('/');
        const module =
          splittedUrl.slice(-(splittedUrl.length - 1))[0] ?? 'home';
        this.menu = module.length > 0 ? module : 'home';
        this.submenu = splittedUrl.slice(-(splittedUrl.length - 1))[0];
      }
    });
  }

  hasSubmenu(route: NavigationRoute): boolean {
    return route.submenu.length > 0;
  }
}
