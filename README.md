# StudentsDBDemo

(https://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1)

1. New Project ("StudentsDB.WebAPI") -> Web -> ASP.NET Web Application -> Empty (+Web API).
2. Folder "Models" of the project -> Add class ("Student").
3. Build Solution.
4. Folder "Controllers" of the project -> Add controller -> Web API 2 Controller with actions, using Entity Framework -> Model class: Student, + Data context class: StudentsDBWebAPIContext, +Use async controller actions, Controller name: "StudentsController".
5. Package Manager Console -> "Enable-Migrations"; "Add-Migration Initial"; "Update-Database". Result: SQL Server Object Explorer -> (localdb)\MSSQLLocalDB -> Databases -> StudentsDBWebAPIContext-NNNNNNNNNNNNNN

6. New Project ("DBClient.WindowsForms") -> Windows -> Windows Forms Application
7. Package Manager Console -> Install-Package System.Net.Http.Formatting.Extension (DBClient.WindowsForms)
8. Package Manager Console -> Install-Package Newtonsoft.Json -Version 6.0.1 (-//-)

http://www.dotnetfunda.com/articles/show/2341/crud-operation-using-web-api-and-windows-application

9. Adding CRUD operations.

--
For start:
- Open in Visual Studio
- Tools -> NuGet Package Manager -> Package Manager Console -> Restore
- Start 'StudentsDB.WebAPI' project
- Start 'DBClient.WindowsForms'; login using domain or PC cridentials
- Press 'List students' button and wait for headers in dataGridView appear
- Program is ready to use. Enjoy!
