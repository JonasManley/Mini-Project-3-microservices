using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MiniProject2Client
{
    public class Client
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly string replyQueueName;
        private readonly EventingBasicConsumer consumer;
        private readonly BlockingCollection<string> respQueue = new BlockingCollection<string>();
        private readonly IBasicProperties props;

        public Client()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new EventingBasicConsumer(channel);
            props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var response = Encoding.UTF8.GetString(body);
                if (ea.BasicProperties.CorrelationId == correlationId)
                {
                    respQueue.Add(response);
                }
            };
        }


        //EIP - Request & Reply ----------------------------------------
        public string Call(string message)
        {
            //EIP  "Message" -----------------------------
            var messageBytes = Encoding.UTF8.GetBytes(message);
            //EIP  "Message" -----------------------------
            channel.BasicPublish(
                exchange: "",
                routingKey: "rpc_queue",    //Identifyer for the queue
                basicProperties: props,     //expecting response
                body: messageBytes);        //The message  

            channel.BasicConsume(
                consumer: consumer,
                queue: replyQueueName,
                autoAck: true);

            return respQueue.Take();
        }
        //EIP - Request & Reply ----------------------------------------


        public void Close()
        {
            connection.Close();
        }
    }

    public class Rpc
    {
        public static void Main()
        {
            var client = new Client();

            Console.WriteLine(" [x] Requesting fib(30)");
            var response = client.Call("30");

            Console.WriteLine(" [.] Got '{0}'", response);
            client.Close();
        }
    }
}

