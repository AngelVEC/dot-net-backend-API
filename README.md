## Installation
- Clone the repository

- Install the .net package with the command
```
dotnet restore
```

Set up the secret manager
```
dotnet user-secrets init
dotnet user-secrets set postgres-username YOUR-USERNAME-HERE
dotnet user-secrets set postgres-password YOUR-PASSWORD-HERE
dotnet user-secrets set postgres-host YOUR-HOST-HERE
```
Make a migrations and update the database
- If you are using visual studio package manager
```
# to make a migrations
Add-Migration YOURMIGRATIONNAME

# to apply the migrations to the database
Update-Database

```
- If you prefer to use CLI like me
```
# to make a migrations
dotnet ef migrations add YOURMIGRATIONNAME

# to apply the migrations to the database
dotnet ef database update

```
If you have an error that said you don't have EF dependancies it happens because .net removed it from default installation
what you need to do is check your dot net version and install the EF that has same version as your .net
for Example

![image](https://github.com/user-attachments/assets/fc17da89-f503-4514-be0f-f02021d7fc45)

```
dotnet tool install --global dotnet-ef --version 8.*
```
