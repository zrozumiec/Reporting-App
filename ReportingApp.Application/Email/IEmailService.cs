namespace ReportingApp.Application.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailModel email, bool mode = true);
    }
}