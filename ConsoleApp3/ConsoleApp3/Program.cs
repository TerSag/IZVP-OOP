using System;

namespace ConsoleApp3
{

    public class AlarmClock
{

    public event Action<string>? Alarm;

    public void TriggerAlarm(string time)
    {
        Console.WriteLine($"\n[AlarmClock] Настав час {time}! Будильник спрацював.");

        Alarm?.Invoke(time);
    }
}

public class MessagePrinter
{
    public void ShowWakeUpMessage(string time)
    {
        Console.WriteLine($"  -> [MessagePrinter] УВАГА На екрані: Прокидайся! Вже {time}!");
    }
}

public class Logger
{
    public void LogEvent(string time)
    {
        Console.WriteLine($"  -> [Logger] Запис у журнал: Будильник успішно спрацював о {time}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Демонстрація подієвої взаємодії ===");

        // Створюємо об'єкти
        AlarmClock clock = new AlarmClock();
        MessagePrinter printer = new MessagePrinter();
        Logger logger = new Logger();

        clock.Alarm += printer.ShowWakeUpMessage;
        clock.Alarm += logger.LogEvent;
        Console.WriteLine("Підписано два об'єкти: MessagePrinter та Logger.");

        clock.TriggerAlarm("07:00");

        Console.WriteLine("\n--- Відписуємо Logger від події будильника ---");
        clock.Alarm -= logger.LogEvent;

        clock.TriggerAlarm("07:05");

        Console.ReadLine();
    }
}
}
