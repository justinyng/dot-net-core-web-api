# dot-net-core-web-api
* Learning .net core web api: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code

### To test
1. cd to `TodoApi` folder
1. `ctrl`+`F5` to run app in VS code
1. In separate terminal, use httprepl for testing and replace <INSERT_YOUR_PORT_NUMBER>: `httprepl https://localhost:<INSERT_YOUR_PORT_NUMBER>/api/todoitems`
1. Test post: `post -h Content-Type=application/json -c "{"name":"walk dog","isComplete":true}"`
1. Test get:
   ```
   get
   connect https://localhost:<INSERT_YOUR_PORT_NUMBER>/api/todoitems/1
   get
   ```