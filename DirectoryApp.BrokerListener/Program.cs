using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RestSharp;
using RestSharp.Authenticators;
using System.Text;

var factory = new ConnectionFactory() { 
    HostName = "localhost",
    UserName = "guest",
    Password = "guest" 
};

using(var connection = factory.CreateConnection())

using(var channel = connection.CreateModel()) {
    channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, ea) =>
    {
        //var body = ea.Body.ToArray();
        //var message = Encoding.UTF8.GetString(body);
        //Console.WriteLine(" [x] Received {0}", message);

        // Herhangi bir mesaj alındığında bugünkü kayıtları getiren bir rapor tetiklenecek.
        // O yüzden mesaj içeriğine bakmıyorum.

        try {
            var client = new RestClient("http://localhost:5000") { };
            var request = new RestRequest("report");
            var response = await client.GetAsync(request);
        } catch(Exception ex) {

        }
    };

    channel.BasicConsume(queue: "hello",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}