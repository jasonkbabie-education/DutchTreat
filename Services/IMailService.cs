namespace DutchTreat.Services
{
    public interface IMailService
    {
        void SendMail(string name, string mailTo, string mailFrom, string message, string subject);
    }
}