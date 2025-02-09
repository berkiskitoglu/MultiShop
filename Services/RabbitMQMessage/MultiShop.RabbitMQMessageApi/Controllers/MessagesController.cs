using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public  async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
                
            };
            var connection = await connectionFactory.CreateConnectionAsync();

            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync("Kuyruk2", false, false, false, arguments: null);
            var messageContent = "Merhaba Bugün Hava Çok Sıcak";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            await channel.BasicPublishAsync(exchange:"",routingKey:"Kuyruk2",body:byteMessageContent);
            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        private static string message;

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            var consumer = new AsyncEventingBasicConsumer(channel);

            // TaskCompletionSource ile mesaj alınmasını bekleyeceğiz
            var tcs = new TaskCompletionSource<bool>();

            consumer.ReceivedAsync += async (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);

                // Mesaj alındığında TaskCompletionSource'ı tamamlıyoruz
                tcs.SetResult(true);
            };

            await channel.BasicConsumeAsync(queue: "Kuyruk1", autoAck: false, consumer: consumer);

            // Mesaj alınana kadar bekliyoruz
            await tcs.Task;

            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(message);
            }
        }

    }
}
