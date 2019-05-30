using GreetingCards.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GreetingCards.Tests
{
    [TestClass]
    public class GreetingCardRepositoryTests
    {
        [TestMethod]
        public void Should_Return_All_Greeting_Cards()
        {
            var repo = new GreetingCardRepository();

            var allCards = repo.AllGreetingCardTemplates().ToList();

            Assert.AreEqual(3, allCards.Count());
            CollectionAssert.AllItemsAreNotNull(allCards);
            Assert.IsFalse(allCards.Any(c => c.CardImage == null));
        }
    }
}
