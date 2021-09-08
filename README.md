
# LamaMania

Launch Authenticate Manage Access (ManiaPlanet Dedicated Server Manager)

## Download

bla
bla
bla


# Dev' Infos

## LamaPlugin library

The LamaPlugin library is the heart of LamaMania application, it contains all the tools to create and manage plugins, manage XmlRpc connections, GBX methods/callbacks, manialink creation, color code management, etc.

## Create new plugin

### Basics

To create a new plugin, you need to create a new .NET Framework library project
and add a reference on LamaPlugin. Then it will be necessary to create a new class which inherits from one of these classes:
- HomeComponentPlugin
- InGamePlugin
- TabPlugin

In all plugin contructors, you have to fill this fields
```csharp
this.PluginName = "MyPluginName";
this.PluginDescription = "A little description";
this.Author = "Me";
this.PluginFolder = "";
```

And you can add requirements
```csharp
this.Requirements.Add(new Requirement(RequirementType.PLUGIN, "OtherPlugin"));
```

In all plugins there is a onLoad(config) method. In this method you can check some points, add callbacks listener and send requests to the server. This method returns a bool (true if ok, false if error)


```csharp
public override bool onLoad(LamaConfig lamaConfig)
{
    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMatch, cb_BeginMatch);   
    asyncRequest(getPlayerList, GBXMethods.GetPlayerList, 999, 0);
    return true;
}
```



### InterPlugins Communication

plugins are able to communicate with each other using methods onInterPluginCall(..) and sendInterPluginCall(..)

#### Get a request : 

```csharp
public override InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
{
    InterPluginResponse response = null;
    switch (args.CallName)
    {
        //GET++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        case "GetCallList":
            response = new InterPluginResponse(args.CallName, new Dictionary<string, object>
            {
                {"GetCallList","All" },
                {"GetUserLevel","Admin" },
                {"GetMasterAdmins","MasterAdmin" },
                {"GetAdmins","Admin" },
                {"GetModerators","Moderator" },
                {"GetGuests","All" },
                {"GetAll","MasterAdmin" },
                {"AddUser","MasterAdmin" },
                {"EditUser","MasterAdmin" },
                {"RemoveUser","MasterAdmin" },
                {"AddLevel","MasterAdmin" },
                {"EditLevel","MasterAdmin" },
                {"RemoveLevel","MasterAdmin" },
                {"SaveFile","MasterAdmin" },
                {"ReadConfig", "MasterAdmin" },
             });
             break;
    }
    return response;
}
```

#### Send a request : 

```csharp
                                        //  PluginName    CallName          Args
InterPluginResponse r = sendInterPluginCall("UserLevel", "GetUserLevel", new Dictionary<string, object>() {{ "login", login }});
string level = (string)r.Param[login];
```

## LamaApi

test



