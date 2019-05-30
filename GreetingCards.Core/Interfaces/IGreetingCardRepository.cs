using GreetingCards.Core.Models;
using System;
using System.Collections.Generic;

namespace GreetingCards.Core.Interfaces
{
    public interface IGreetingCardRepository
    {
        IEnumerable<GreetingCardTemplate> AllGreetingCardTemplates();

        GreetingCardTemplate GetGreetingCard(int cardId);
    }
}