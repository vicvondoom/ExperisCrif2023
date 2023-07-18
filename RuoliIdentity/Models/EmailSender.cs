using Microsoft.AspNetCore.Identity.UI.Services;

namespace RuoliIdentity.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //throw new NotImplementedException();
            //Non sollevo l'errore ma ritorno task completato
            return Task.CompletedTask;
        }
    }
}
