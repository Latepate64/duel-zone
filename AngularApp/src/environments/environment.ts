// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  auth0: {
    domain: 'dev-otd2luzvi36lw2nh.us.auth0.com',
    clientId: 'vdD4hTh2bypsew1sr0ooLokAfbJ2MP80',
    authorizationParams: {
      redirect_uri: window.location.origin,
      audience: 'https://localhost:7034/',
      // scope: 'read:current_user',
    },
    httpInterceptor: {
      allowedList: [
        {
          uri: 'http://localhost:4200/*',
          tokenOptions: {
            authorizationParams: {
              audience: 'https://localhost:7034/',
              // scope: 'read:current_user'
            }
          }
        }
      ]
    },
  },
  api: {
    serverUrl: 'http://localhost:6060',
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
