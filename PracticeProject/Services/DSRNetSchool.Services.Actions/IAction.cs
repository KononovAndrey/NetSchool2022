namespace DSRNetSchool.Services.Actions;

using DSRNetSchool.Services.EmailSender;
using System.Threading.Tasks;

public interface IAction
{
    Task SendEmail(EmailModel email);
}
