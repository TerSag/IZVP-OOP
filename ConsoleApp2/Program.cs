using System;
using System.Collections.Generic;

namespace AggregationPractice
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Player(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Гравець: {Name} (Позиція: {Position})");
        }
    }

    public class Team
    {
        public string TeamName { get; set; }

        private List<Player> _players;

        public Team(string teamName)
        {
            TeamName = teamName;
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            Console.WriteLine($"[Додано] {player.Name} приєднався до команди '{TeamName}'.");
        }

        public void RemovePlayer(Player player)
        {
            if (_players.Remove(player))
            {
                Console.WriteLine($"[Видалено] {player.Name} покинув команду '{TeamName}'.");
            }
        }

        public void ShowTeamInfo()
        {
            Console.WriteLine($"\n--- Склад команди: {TeamName} ---");
            if (_players.Count == 0)
            {
                Console.WriteLine("Команда порожня.");
            }
            else
            {
                foreach (var p in _players)
                {
                    p.ShowInfo();
                }
            }
            Console.WriteLine("---------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація Агрегації ===\n");

            Player player1 = new Player("Олександр Зінченко", "Захисник");
            Player player2 = new Player("Михайло Мудрик", "Півзахисник");

            Console.WriteLine("Створено незалежних гравців (вільні агенти):");
            player1.ShowInfo();
            player2.ShowInfo();
            Console.WriteLine();

            Team myTeam = new Team("Збірна України");

            myTeam.AddPlayer(player1);
            myTeam.AddPlayer(player2);

            myTeam.ShowTeamInfo();

            myTeam.RemovePlayer(player2);
            myTeam.ShowTeamInfo();

            Console.WriteLine("Перевірка статусу видаленого гравця:");
            Console.WriteLine($"Гравець {player2.Name} не був знищений. Він все ще існує в пам'яті!");
            player2.ShowInfo();

            Console.ReadLine();
        }
    }
}
