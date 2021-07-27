'Settlementservice' project is for proiding settlement for the Property.

It can handle 4 settlements simultaniously.

If multiple reuqests comes with same booking time, it will through conflict error.

ASP.NET Core WEB API project selected for implementing this functionality

Used dependency injection for injecting service object and InmemoryCache.

Used XUnity Framework to cover all the test scenarios.

Once we run the project, test the functionality by POST method for "https://localhost:44389/Settlement"
