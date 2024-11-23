interface NavigationRoute extends NavigationLink {
  moduleName: string;
  roles: string[];
  submenu: NavigationRoute[];
}

interface NavigationLink {
  path: string;
  title: string;
}

const publicNavigationItems: NavigationRoute[] = [
  {
    moduleName: 'home',
    path: '',
    title: 'home_title',
    roles: [],
    submenu: [],
  },
  {
    moduleName: 'departments',
    path: 'departments',
    title: 'departments_title',
    roles: [],
    submenu: [],
  },
  {
    moduleName: 'doctors',
    path: 'doctors',
    title: 'doctors_title',
    roles: [],
    submenu: [],
  },
  {
    moduleName: 'appointment',
    path: 'appointment',
    title: 'appointment_title',
    roles: [],
    submenu: [],
  },
  // {
  //   moduleName: 'blog',
  //   path: 'blog',
  //   title: 'Blog',
  //   roles: [],
  //   submenu: [],
  // },
  {
    moduleName: 'contact',
    path: 'contact',
    title: 'contact_title',
    roles: [],
    submenu: [],
  },
];

const privateNavigationItems: NavigationRoute[] = [
  {
    moduleName: 'appointments',
    path: 'appointments',
    title: 'appointment_title',
    roles: [],
    submenu: [],
  },
  {
    moduleName: 'specialities',
    path: 'specialities',
    title: 'specialities_name',
    roles: [],
    submenu: [],
  },
  {
    moduleName: 'medics',
    path: 'medics',
    title: 'doctors_title',
    roles: [],
    submenu: [],
  },
];

class NavigationItemsWrapper {
  public static getNavigationMenuItems(
    naviationItems: NavigationRoute[]
  ): Array<NavigationRoute> {
    const result = [] as Array<NavigationRoute>;

    naviationItems.forEach((navigationMenuItem) => {
      const navRoute = {} as NavigationRoute;
      navRoute.path = navigationMenuItem.path;
      navRoute.title = navigationMenuItem.title;
      navRoute.moduleName = navigationMenuItem.moduleName;
      navRoute.roles = navigationMenuItem.roles;

      const submenu = [] as Array<NavigationRoute>;
      navigationMenuItem.submenu.forEach((sub) =>
        submenu.push(Object.assign({}, sub))
      );
      navRoute.submenu = submenu;

      result.push(navRoute);
    });

    return result;
  }
}

export {
  NavigationItemsWrapper,
  NavigationRoute,
  NavigationLink,
  publicNavigationItems,
  privateNavigationItems,
};
