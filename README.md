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
## Synchronously ##
`using (var client = new KipptClient("HaythemTlili", "SomeToken"))
{
	// Get user's lists
	var lists = KipptList.GetLists(client);

	// Print lists titles
	foreach (var list in lists.Lists)
	{
		Console.WriteLine(list.Title);
	}
}`

## Asynchronously ##
`using (var client = new KipptClient("HaythemTlili", "SomeToken"))
{
	client.Completed += (s, e) =>
	{
		if (e.Error == null)
		{
			var lists = (KipptListCollection)e.Result;
	
			// Print lists titles
			foreach (var list in lists.Lists)
			{
				Console.WriteLine(list.Title);
			}
		}
	}

	// Get user's lists
	KipptList.GetListsAsync(client);
}`

# ChangeLog #

----------
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

# Read More #

----------
For more detailed documentation, you can visit the [documentation](http://haythem.github.com/Kippt.NET/) page.