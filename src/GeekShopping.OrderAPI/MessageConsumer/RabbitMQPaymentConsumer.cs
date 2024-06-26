﻿using GeekShopping.OrderApi.Repository;
using GeekShopping.OrderAPI.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        private const string ExchangeName = "DirectPaymentUpdateExchange";        
        private const string PaymentOrderUpdateQueueName = "PaymentOrderUpdateQueueName";        

        public RabbitMQPaymentConsumer(OrderRepository repository)
        {
            _repository = repository;            
            var factory = new ConnectionFactory            
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, false);
            _channel.QueueDeclare(PaymentOrderUpdateQueueName, false, false, false);
            _channel.QueueBind(PaymentOrderUpdateQueueName, ExchangeName, "PaymentOrder");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                UpdatePaymenteResultDto dto = JsonSerializer.Deserialize<UpdatePaymenteResultDto>(content);
                UpdatePaymentStatus(dto).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(PaymentOrderUpdateQueueName, false, consumer);

            return Task.CompletedTask;
        }

        private async Task UpdatePaymentStatus(UpdatePaymenteResultDto dto)
        {            
            try
            {
                await _repository.UpdateOrderPaymentStatus(dto.OrderId, dto.Status);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
