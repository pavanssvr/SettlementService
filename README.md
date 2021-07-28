'Settlementservice' project is for providing settlement for the Property.

It can handle 4 settlements simultaneously.

If multiple requqests comes with same booking time, application will through conflict exception.

ASP.NET Core WEB API project selected for implementing this functionality.

Used Dependency injection for injecting service object and InMemoryCache.

Used XUnity Framework to cover all the test scenarios.

Once we run the project, test the functionality by WEB API  POST for "https://localhost:44389/Settlement"
