using EasyNetQ;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "host=localhost;username=user;password=pass";
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                bus.Subscribe<Message.Subsidy>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(Message.Subsidy subsidy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Received subsidy [{subsidy.ProjectCode}] for {subsidy.Recipient}: {subsidy.Value} Kc");
            Console.ResetColor();
        }
    }
}
