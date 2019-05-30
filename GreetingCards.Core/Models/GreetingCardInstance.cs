using System.Drawing;

namespace GreetingCards.Core.Models
{
    public class GreetingCardInstance
    {
        public Bitmap Image { get; }

        public GreetingCardTemplate Template { get; }

        public string Recipient { get; }

        public string Message { get; }

        public string Sender { get; }

        public GreetingCardInstance(Bitmap image, GreetingCardTemplate template, string recipient, string message, string sender)
        {
            Image = image;
            Template = template;
            Sender = sender;
            Recipient = recipient;
            Message = message;
        }
    }
}
