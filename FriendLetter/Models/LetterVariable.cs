//place the LetterVariable class in a FriendLetter.Models namespace
namespace FriendLetter.Models
{
  public class LetterVariable
  {
    //auto-implemented propert
    public string Recipient { get; set; }
    //update our application to allow any Sender to create a letter to their friends
    public string Sender { get; set; }

  }
}