# dot-net-core-web-api
* Used .net core web api tutorial here for scaffolding: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code

### To Run
1. Open `JustBuildingsApi` folder in VS Code
1. `Ctrl`+`F5` to run app in VS Code
1. Api running, see swagger for API documentation `https://localhost:7070/swagger/index.html`

### Models
```csharp
public class Properties
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
```