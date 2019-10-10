# Cleverbit Software - Articles

This project was built using Angular 7.

## Development Setup

Follow steps in `README.md` from `Web_Api_DotNetCore_2` folder.

Run the `CleverbitSoftware.WebApi` from `Web_Api_DotNetCore_2` folder. Make sure the API runs on `https://localhost:44331`, it should be in sync with `apiUrl` of `environment.ts`. 

Run `npm i`. The app will install dependencies.

Run `npm start`. Navigate to `http://localhost:4200/`. Make sure to run locally exactly on this url, Google sign in will only work for this url.

## Build

Run `npm build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `npm test` to execute the unit tests via [Karma](https://karma-runner.github.io).




