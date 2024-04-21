import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { NavigationItemsWrapper, NavigationRoute } from './navigation-item';
import { NavigationStart, Router } from '@angular/router';
export { NavigationItemsWrapper, NavigationRoute } from './navigation-item';

@Component({
  selector: 'app-header-navigator',
  templateUrl: './header-navigator.component.html',
  styleUrl: './header-navigator.component.scss',
})
export class HeaderNavigatorComponent implements OnInit {
  links: NavigationRoute[] = [];
  menu: string = '';
  submenu: string = '';
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.initMenuLinks();
    this.navigationMenuActiveHighlight();
  }

  initMenuLinks(): void {
    const navigationMenuItemsTemp =
      NavigationItemsWrapper.getNavigationMenuItems();

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
}
