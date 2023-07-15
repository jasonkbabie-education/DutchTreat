using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this.logger = logger;
        }
        public void SendMail(string name, string mailTo, string mailFrom, string message, string subject)
        {
            logger.LogInformation($"To: {mailTo}\nSubject: {subject}\nFrom: {mailFrom}\nMessage {message}");
        }
    }
}
