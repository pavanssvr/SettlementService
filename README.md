'Settlementservice' project is for providing settlement for the Property.

It can handle 4 settlements simultaneously.

If multiple requests come with same booking time, application will through conflict exception.

ASP.NET Core WEB API project selected for implementing this functionality.

Dependency injection used for injecting service object and InMemoryCache.

XUnity Framework used for covering all the test scenarios.

Once we run the project, the functionality can be veified by WEB API  POST for "https://localhost:44389/Settlement"

Sample payload for the PST method  in json format: {"bookingTime":"10:34", "name:"wilsonsmith"}
