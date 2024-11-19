import { Component, ElementRef, HostListener } from '@angular/core';
import {
  NavigationItemsWrapper,
  NavigationRoute,
  privateNavigationItems,
  publicNavigationItems,
} from '../header-navigator/navigation-item';
import { AuthService } from '../../auth/auth.service';
import { NavigationStart, Router } from '@angular/router';
import { ContactInformation } from '../../contact/contact-form/contact-information.model';
import { ContactService } from '../../contact/service/contact.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  links: NavigationRoute[] = [];
  menu: string = '';
  submenu: string = '';

  constructor(
    private authService: AuthService,
    private router: Router,
    private http: ContactService
  ) {
    this.loadContactInformation();
  }
  contactInformation: ContactInformation | undefined;

  @HostListener('window:scroll', [])
  onWindowScroll() {
    const element = document.getElementById('header');
    if (element)
      window.pageYOffset > 50
        ? element.classList.add('header-scrolled')
        : element.classList.remove('header-scrolled');
  }
  ngOnInit(): void {
    this.initMenuLinks();
    this.navigationMenuActiveHighlight();
  }

  initMenuLinks(): void {
    this.authService.currentUser.subscribe((user) => {
      let navigationMenuItemsTemp: NavigationRoute[] = [];
      console.log('user', user);
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

  loadContactInformation() {
    this.http.getConactInformation().subscribe({
      next: (data: ContactInformation | undefined) =>
        (this.contactInformation = data),
      error: (error) =>
        console.error('Failed to load contact information', error),
    });
  }
}
