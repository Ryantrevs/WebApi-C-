using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace teste.Services
{
    public class MailService
    {

        public async Task<SendGrid.Response> EnviarEmail(String nome,String destinatario, List<links> links)
        {
            var htmlContent = "<strong>";
            var client = new SendGridClient("");
            var from = new EmailAddress("mailmkt@suportetcc.com", "TccSuporte");
            var subject = "Temos Boas Novas";
            var to = new EmailAddress(destinatario, nome);
            var plainTextContent = "Seu trabalho acaba de ser finalizado, estamos muito feliz em poder estar te ajudando nessa etapa ´da vida, aproveite e se puder, recomende para seus amigos o nosso serviço";
            foreach(var link in links)
            {
                htmlContent += link.link + "\n\n\n   ";
                if (links[links.Count - 1] == link)
                {
                    htmlContent += "</strong>";
                }
            }
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}
