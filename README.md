# LamaMania
Launch Authenticate Manage Access (Gestion de serveurs maniaplanet)

## LamaPlugin library
The LamaPlugin library is the heart of LamaMania application, it contains all the tools to create and manage plugins, manage XmlRpc connections, GBX methods/callbacks, manialink creation, color code management, etc.

## Create new plugin
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

### InGamePlugin



