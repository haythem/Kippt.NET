# Kippt.NET #

----------


**Kippt.NET** is a C# Library for consuming [kippt.com](https://kippt.com "Kippt") apis.

# Features #

----------
- Multi-target Library : .NET 4.0, Silverlight, Windows Phone, Windows RT, Mono
- No Dependencies
- Supports All Api Endpoints
- Synchronus & Asynchronus Support
- Availaible On Nuget

![Kippt.NET On NuGet](http://haythem.github.com/Kippt.NET/img/nuget.png)

# Getting Started #

----------
`var client = new KipptClient("Username", "ApiToken");  
var list = new KipptList();  
list.Title = "Kippt.NET";`

## Synchronously ##

`list = list.Create(client);`

## Asynchronously ##

`client.Completed += (s, e) => { var list = (KipptList)e.Result; };  
list.CreateAsync(client);`

# ChangeLog #

----------

## v1.0 ##
- Initial release

## v1.5 ##
- Support for Windows Phone 7.5
- Support for WinRT
- Support for Silverlight 5
- Support for Mono
- Support for asynchronus programming (event based)
- Added KipptNotification end point
- Optimized HTTP authentication logic
- Search clips with filters : since, list
- Fixed events logic
- Optimized KipptEventArgs
- Better exception handling

## v1.6.x ##
- Updated api endpoints
- Fixed large data deserialization
- Added synchronus and asynchronus helpers for account, users, lists, clips and notifications
- Liking, commenting and favoriting clips

# Read More #

----------
For more detailed documentation, you can visit the [documentation](http://haythem.github.com/Kippt.NET/) page.