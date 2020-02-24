using EasyNetQ;
using System;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "host=localhost;username=user;password=pass";
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                var input = "";
                Console.WriteLine("Enter a recipient. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message.Subsidy
                    {
                        ProjectCode = "123456abcd",
                        Recipient = input,
                        Value = 1000000
                    });
                }
            }
        }
    }
}
