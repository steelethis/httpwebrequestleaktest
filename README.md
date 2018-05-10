# What is this?
This project is a set of applications that show off a memory leak that can occur within .NET applications that use an API.

In order to use this, you would want to run one of the test applications, as well as the Delay API.

The Delay API is just a boilerplate .net core web application that will wait 20 seconds when you use the GET endpoint for a value.

The test clients are designed to time out after 10 seconds, however when using WebRequest directly the timeout is ignored and the request will hang around in memory causing a horrendous memory leak over time.

HttpClient does not have this issue and will handle these requests as they come in as fast as it can, without a memory leak.

The test clients will also use threading to send requests as fast as they can at the API. This is so that you can see the issue much faster than you normally would.
