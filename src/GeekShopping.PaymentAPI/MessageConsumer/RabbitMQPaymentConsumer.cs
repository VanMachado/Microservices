﻿using GeekShopping.PaymentAPI.Messages;
using GeekShopping.PaymentAPI.RabbitMQSender;
using GeekShopping.PaymentProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IProcessPayment _processPayment;

        public RabbitMQPaymentConsumer(IProcessPayment processPayment,
            IRabbitMQMessageSender rabbitMQMessageSender)
        {            
            _processPayment = processPayment;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentMessage dto = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(dto).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("orderpaymentprocessqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage dto)
        {
            var result = _processPayment.PaymentProcessor();
            UpdatePaymenteResultMessage paymenteResultMessage = new()
            {
                Status = result,
                OrderId = dto.OrderId,
                Email = dto.Email
            };
            try
            {
                _rabbitMQMessageSender.SendMessage(paymenteResultMessage);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
