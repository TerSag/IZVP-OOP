namespace EventTicketsApp
{
    public class RegularTicket : Ticket
    {
        public override string TicketType => "Звичайний квиток";

        public RegularTicket(string eventName, decimal basePrice)
            : base(eventName, basePrice)
        {
        }

        public override decimal CalculatePrice()
        {
            return BasePrice;
        }
    }
}