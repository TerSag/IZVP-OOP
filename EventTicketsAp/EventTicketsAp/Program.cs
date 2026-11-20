using System;
using System.Collections.Generic;
using System.Text;

namespace EventTicketsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Ticket> tickets = new List<Ticket>
            {
                new RegularTicket("Концерт", 200),
                new StudentTicket("Концерт", 200)
            };

            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine($"{ticket.EventName} — {ticket.TicketType} — {ticket.CalculatePrice():0.##} грн");
            }
        }
    }
}