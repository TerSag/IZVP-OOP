namespace EventTicketsApp
{
    public class Ticket
    {
        public string EventName { get; set; }
        public decimal BasePrice { get; set; }

        public virtual string TicketType => "Базовий квиток";

        public Ticket(string eventName, decimal basePrice)
        {
            EventName = eventName;
            BasePrice = basePrice;
        }

        public virtual decimal CalculatePrice()
        {
            return BasePrice;
        }
    }
}