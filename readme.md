- # BLOG SAMPLE PROJECT - .NET 6 WEB\*

# TOOLS:

1. Visual Studio 2022
2. MS SQL Management Studio (Latest)
3. MS SQL Local DB should be installed with VS 22

# Project Structure:

1. BlogSample.Business
   All the business logic, helpers are reside in this project

2. BlogSample.Data
   The database project which holds entity (table) & database context. We have used Entity Framework Core & Code first migration. All migration files reside inside this project as well.

3. BlogSample.Localization
   All language wise resources managed here which help us to store / get words, messages etc.. language wise. At the moment english is primary langauge but in order to achieve scalability we have just added this multilingual feature.

4. BlogSample.Web
   Main project, web or you can say presentation layer which holds views, model & controllers. Keep this project as startup project in order to run the app.

5. BlogSample.AutoPosts
   This project is console app as .NET core won't support windows service so we have built this console app for automatic blog posting from given specific URL. For more, visit this https://www.c-sharpcorner.com/UploadFile/manas1/console-application-using-windows-scheduler/

## Run project

Right click on BlogSample.Web project then select Set as a Startup Project and then after click on IIS Express button on the top menu or you can use F5 shortcut key.

## Change Connection String

If you need to change the connection string, so you must change the below project file's contents.

1. BlogSample.Autopost / appsettings.json

2. BlogSample.Web / appsettings.Development.json
   / appsettings.json
   / Programe.cs

## Create a new table

1. Create a tableName.cs in BlogSample.Data
2. Mention table name into EFUnitOfWork.cs
3. Goto the top bar menu and select Tools > Nuget Package Manager > Package Manager Console
4. Use the command to add a migration message
   -> Add-Migration "Enter change text"
5. Use the command to update/create a table in the database
   -> Update-Database
