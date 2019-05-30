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

            using (var graphics = Graphics.FromImage(instanceImage))
            using (var font = new Font("Arial", 10))
            {
                var recipientLocation = CalculateLocation(xMiddle, graphics.MeasureString(recipient, font), 30);
                var messageLocation = CalculateLocation(xMiddle, graphics.MeasureString(message, font), yMiddle);
                var senderLocation = CalculateLocation(xMiddle, graphics.MeasureString(sender, font), instanceImage.Height - 30);

                graphics.DrawString(recipient, font, Brushes.Black, recipientLocation);
                graphics.DrawString(message, font, Brushes.Black, messageLocation);
                graphics.DrawString(sender, font, Brushes.Black, senderLocation);
            }

            return instanceImage;
        }

        private PointF CalculateLocation(int xMiddle, SizeF textSize, int yPosition)
        {
            var textMiddle = textSize.Width / 2;

            var xPosition = xMiddle - textMiddle;

            return new PointF(xPosition, yPosition);
        }
    }
}