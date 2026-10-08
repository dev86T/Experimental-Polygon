IMessageService emailService = new EmailService();
var notificationService = new NotificationService(emailService);
notificationService.Notify("Message");

class NotificationService
{
        
    private readonly IMessageService _messageService;
    public NotificationService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendEmail("Сообщение отправлено по почте");
    }
}

interface IMessageService
{
    void SendEmail(string message);
}

class EmailService : IMessageService
{
    public void SendEmail(string message)
    {
        Console.WriteLine(message);
    }
}