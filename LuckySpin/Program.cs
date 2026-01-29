var builder = WebApplication.CreateBuilder(args);

// Install Services using the builder.Services methods
  //  TODO: include the builder service "AddControllers" to enable MVC controllers
  builder.Services.AddControllersWithViews();
 

//Builds the app with the added services
var app = builder.Build();


// Configure the app's Middleware in the HTTP Request Pipeline
//   DONE: The following code "app.UseStaticFiles()" provides the ability to recognize static folders and files in the wwwroot directory
app.UseStaticFiles();

//   DONE: The following code "app.UseExceptionHandler" provides a default error page when not in development
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Spinner/Error");
}
//   TODO: include the app method "UseRouting" to recognize custom "Routes" in place of folders and files

app.UseRouting();

//Configure Routing with a general pattern and a default setting if the URL path is left out
 // FIXME:if your have time, add a range(1,9) method to constrain luck between 1 and 9

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{luck:range(1,9)}",
    defaults: new 
    {
        controller = "Spinner",
        action = "Index",
        luck = 6
    });

app.Run();

