using FriendLetter.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendLetter.Controllers
{
  //adding : Controller to our HomeController class, we tell our program that HomeController should inherit or extend functionality from ASP.NET Core's built-in Controller class that we import with our using statement.
  public class HomeController : Controller
  {

/*route decorator [Route("/hello")]: Instead of needing to visit /home/hello to activate our Hello() route, we now only have to visit /hello
When a client like a web browser makes a request to our server, it must include the URL it's requesting. In the example above, the URL contains a /home/hello path.
Our server looks at the HomeController because it matches the first /home portion of the URL path.
In order to find the more specific /home/hello data, our server looks for a Hello() method in the HomeController.
The server provides our client with a response. In this case, our Hello() method returns the string "Hello friend!".
Our client receives the response and renders the resources in the browser. We see "Hello friend!" appear on the page.
*/
    // [Route("/hello")]
    public string Hello() { return "Hello frie!"; }

    [Route("/goodbye")]
    public string Goodbye() { return "Goodbye friend."; }

    [Route("/")]
    public ActionResult Letter()
    {
      //new instance of the type LetterVariable and saves it to the variable myLetterVariable
      LetterVariable myLetterVariable = new LetterVariable();
      //access the the myLetterVariable.Recipient property and give it a value
      myLetterVariable.Recipient = "Lina";
      myLetterVariable.Sender = "Jasmine";
      //pass the myLetterVariable into the view //ensures our corresponding Letter.cshtml view now has access to our LetterVariable object.
      return View(myLetterVariable);
    }
    [Route("/form")]
    //The return type of our Letter() method is now an ActionResult, not a string
    public ActionResult Form() { return View(); }
    [Route("/postcard")]
    public ActionResult Postcard(string recipient, string sender)
    {
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = recipient;
      myLetterVariable.Sender = sender;
      //returns another method called View(). This is a built-in method from the Microsoft.AspNetCore.Mvc namespace. When our route is invoked, it will return a view.
      return View(myLetterVariable);
    }
  }
}