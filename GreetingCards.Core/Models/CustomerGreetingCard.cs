namespace GreetingCards.Core.Models
{
    public class CustomerGreetingCard
    {
        public Customer Customer { get; }

        public GreetingCardInstance CardInstance { get; }

        public CustomerGreetingCard(Customer customer, GreetingCardInstance cardInstance)
        {
            Customer = customer;
            CardInstance = cardInstance;
        }
    }
}
