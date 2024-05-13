using GeekShopping.MessageBus;

namespace GeekShopping.PaymentAPI.Messages
{
    public class UpdatePaymenteResultMessage : BaseMessage
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }   
        public string Email { get; set; }
    }
}
