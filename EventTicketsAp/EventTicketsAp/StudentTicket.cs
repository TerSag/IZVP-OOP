namespace EventTicketsApp
{
    public class StudentTicket : Ticket
    {
        public override string TicketType => "Студентський квиток";

        public StudentTicket(string eventName, decimal basePrice)
            : base(eventName, basePrice)
        {
        }

        public override decimal CalculatePrice()
        {
            return BasePrice * 0.5m;
        }
    }
}