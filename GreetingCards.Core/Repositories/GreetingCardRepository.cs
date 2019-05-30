using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GreetingCards.Core.Interfaces;
using GreetingCards.Core.Models;

namespace GreetingCards.Core.Services
{
    public class GreetingCardRepository : IGreetingCardRepository
    {
        private IEnumerable<GreetingCardTemplate> _allCards;

        public GreetingCardRepository()
        {
            _allCards = new List<GreetingCardTemplate>
            {
                new GreetingCardTemplate(1, "Birthday", new Bitmap("./Images/birthday.bmp"), 2.99m, "Birthday Cards"),
                new GreetingCardTemplate(2, "Wedding", new Bitmap("./Images/wedding.bmp"), 3.99m ,"Wedding Cards"),
                new GreetingCardTemplate(3, "New House", new Bitmap("./Images/house.bmp"), 4.99m, "Moving House Cards")
            };
        }

        public IEnumerable<GreetingCardTemplate> AllGreetingCardTemplates()
        {
            return _allCards;
        }

        public GreetingCardTemplate GetGreetingCard(int cardId)
        {
            return _allCards.First(c => c.Id == cardId);
        }
    }
}
