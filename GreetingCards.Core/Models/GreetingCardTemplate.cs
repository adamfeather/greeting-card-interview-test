using System;
using System.Drawing;

namespace GreetingCards.Core.Models
{
    public class GreetingCardTemplate
    {
        public int Id { get; }

        public string CardName { get; }

        public Bitmap CardImage { get; }

        public decimal Price { get; }

        public string Category { get; }

        public GreetingCardTemplate(int id, string cardName, Bitmap cardImage, decimal price, string category)
        {
            Id = id;
            CardName = cardName;
            CardImage = cardImage;
            Price = price;
            Category = category;
        }

        public GreetingCardInstance CreateInstance(string recipient, string message, string sender)
        {
            Bitmap instanceImage = CreateInstanceImage(recipient, message, sender);

            return new GreetingCardInstance(instanceImage, this, recipient, message, sender);
        }

        private Bitmap CreateInstanceImage(string recipient, string message, string sender)
        {
            var instanceImage = new Bitmap(CardImage);

            var xMiddle = instanceImage.Width / 2;
            var yMiddle = instanceImage.Height / 2;

            var senderLocation = new PointF(xMiddle, 30);
            var messageLocation = new PointF(xMiddle, yMiddle);
            var recipientLocation = new PointF(xMiddle, instanceImage.Height - 30);

            using (var graphics = Graphics.FromImage(instanceImage))
            using (var arialFont = new Font("Arial", 10))
            {
                graphics.DrawString(recipient, arialFont, Brushes.Blue, recipientLocation);
                graphics.DrawString(sender, arialFont, Brushes.Red, messageLocation);
                graphics.DrawString(message, arialFont, Brushes.Green, senderLocation);
            }

            return instanceImage;
        }
    }
}