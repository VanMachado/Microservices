namespace GeekShopping.Email.Messages
{
    public class UpdatePaymenteResultMessage
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }   
        public string Email { get; set; }
    }
}
