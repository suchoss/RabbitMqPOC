using EasyNetQ;
using System;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "host=myServer;username=user;password=topsecret";
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message.Subsidy
                    {
                        ProjectCode = "ABCD!",
                        Recipient = "SZDC",
                        Value = 1000000
                    });

                    bus.Publish(new Message.Subsidy
                    {
                        ProjectCode = "Second project",
                        Recipient = "RSD",
                        Value = 200000
                    });

                    bus.Publish(new Message.Subsidy
                    {
                        ProjectCode = "Third message",
                        Recipient = "Agropodnik",
                        Value = 3
                    });
                }
            }
        }
    }
}
