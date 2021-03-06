# DotGather
.Gather is a .Net wrapper arounf the GatherContent API, simplifying interfacing with the api, and providing easy to access and manage objects.

## Documentation
A full API for the .Gather project is [here](http://dotgatherdocumentation.azurewebsites.net/dotgatherapi ".Gather API")

## Getting Started
This API makes project start-up a breeze. Follow a few simple steps and you will be able to be connected to your GatherContent Accounts in no time!

* In your App.config file find the AppSettings Key "ApiUser" and replace the default value with your GatherContent user's email address
* In your App.config file find the AppSettings Key "ApiKey" and replace the default value with your GatherContent user's API key. Instruction for obtaining your API key can be found [here](https://gathercontent.com/developers/authentication/).

### Connecting to the service and getting my user
```c#
// Service object is created and instantiated with values set in app.config
var service = new GatherContentService();

// Get the current user "me".
var me = service.GetMe();

// Write out user's email address
Console.WriteLine(me.Email);
```


## Authors
Abe Taylor, Cory Dixon, Stelios Hadjichristodoulou, Will Sharp
