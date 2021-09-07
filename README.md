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

### InGamePlugin


