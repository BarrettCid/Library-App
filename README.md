Instructions to run the project:
Backend:
  Make sure nuget packages are installed. Running the application will apply the migrations, add the roles, seed the data and open swagger. Set to run on 44392 for the port. Can be changed in launchSettings.json if port is being used.

Frontend:
  Run npm install to download needed packages.
  If you changed the port in the backend area. Look for the file src/app/shared/constants/server-constants.ts and update the port in the constants file to accomidate for the change.
  ng serve to run the application. Defaults to port 4200.
