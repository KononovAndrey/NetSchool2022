namespace DSRNetSchool.Services.EmailSender;

public interface IEmailSender
{
    Task Send(EmailModel email);
}