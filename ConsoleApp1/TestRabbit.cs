using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class TestRabbit
	{
		private readonly ConnectionFactory _factoryRabbit;
		private const string QUEUE_NAME = "messagesTeste";

		public TestRabbit()
		{
			_factoryRabbit = new ConnectionFactory
			{
				HostName = "localhost"
			};
		}

		public void PostarMensagem(MessageInputModel message)
		{
			using (var connection = _factoryRabbit.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(
						queue: QUEUE_NAME,
						durable: false,
						exclusive: false,
						autoDelete: false,
						arguments: null
						);

					var stringfiedMessage = JsonConvert.SerializeObject(message);
					var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

					channel.BasicPublish(
						exchange: "",
						routingKey: QUEUE_NAME,
						basicProperties: null,
						body: bytesMessage
						);
				}
			}
		}

		public void PegarMensagens()
		{
			using (var connection = _factoryRabbit.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(
						queue: QUEUE_NAME,
						durable: false,
						exclusive: false,
						autoDelete: false,
						arguments: null
						);

					var consumer = new EventingBasicConsumer(channel);
					consumer.Received += (model, ea) =>
					{
						var body = ea.Body.ToArray();
						var message = Encoding.UTF8.GetString(body);
						Console.WriteLine(" [x] Received {0}", message);
					};
					channel.BasicConsume(queue: QUEUE_NAME,
										 autoAck: true,
										 consumer: consumer);
				}
			}
		}

	}
}
