namespace DSRNetSchool.Services.EmailSender;

using Microsoft.Extensions.Logging;

public class EmailSender : IEmailSender
{
    public ILogger<EmailSender> logger { get; }

    public EmailSender(ILogger<EmailSender> logger)
    {
        this.logger = logger;
    }
    public async Task Send(EmailModel model)
    {
        await Task.Delay(2000);

        logger.LogDebug($"Email sended: {model.Email} {model.Subject} {model.Message}");
    }
}
