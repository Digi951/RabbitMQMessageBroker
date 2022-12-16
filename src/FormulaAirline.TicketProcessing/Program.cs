using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the ticekting service");

var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "user",
            Password = "mypass",
            VirtualHost = "/"
        };

        var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare("bookings", durable: true, exclusive: false);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eventArgs) =>
        {
            // getting Byte[]
            Byte[] body = eventArgs.Body.ToArray();

            String message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"New ticket received: {message}");
        };

channel.BasicConsume("bookings", autoAck: true, consumer);

Console.ReadKey();