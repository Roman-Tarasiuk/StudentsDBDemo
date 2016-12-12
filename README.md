# StudentsDBDemo

(https://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1)

1. New Project ("StudentsDB.WebAPI") -> Web -> ASP.NET Web Application -> Empty (+Web API) .
2. Folder "Models" of the project -> Add class ("Student")
3. Build Solution
4. Folder "Controllers" of the project -> Add controller -> Web API 2 Controller with actions, using Entity Framework -> Model class: Student, + Data context class: StudentsDBWebAPIContext, +Use async controller actions, Controller name: "StudentsController"
5. Package Manager Console -> "Enable-Migrations"; "Add-Migration Initial"; "Update-Database". Result: SQL Server Object Explorer -> (localdb)\MSSQLLocalDB -> Databases -> StudentsDBWebAPIContext-20160525112305


Install-Package System.Net.Http.Formatting.Extension
Install-Package Newtonsoft.Json -Version 6.0.1
