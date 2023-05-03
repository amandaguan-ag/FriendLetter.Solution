using Microsoft.AspNetCore.Builder;//access tools to create and configure a web application host
using Microsoft.Extensions.DependencyInjection;//access tools to create services within our web app that get added to our web application via dependency injection.

namespace FriendLetter
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);//first step in creating a host is to create a builder object so that we can configure exactly how we want our web application host to be built

      builder.Services.AddControllersWithViews();//customize our host builder by enabling the Model-View-Controller (MVC) framework as a service
      //The services get added to the builder.Services property by invoking the AddControllersWithViews() method
      //note here is that services get added to our web application host through dependency injection
      //A dependency is simply a class that is used within another class. Or in other words, one class is dependent on the existence of another.
      //problems with setting up dependencies. ASP.NET Core recognizes these problems and provides a solution to them called dependency injection where the framework handles creating new dependencies and injecting them where they are needed throughout the web app.
      WebApplication app = builder.Build();//create the actual host
      //builder.Build() creates and returns our web app host, which we save in the variable app. As we can see, app is of the type WebApplication
      
      // app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();

      //configure host further using middleware to adjust how we handle requests made to our web app
      //methods called on app are called middleware
      app.UseRouting();//specifies that we want our host to match the website URL to routes that we create within our app

      //we want our URLs to first list the name of the controller, then the name of the action, and then the id of the current object
      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();//runs the host
    }
  }
}