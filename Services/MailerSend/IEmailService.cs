using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services.MailerSend
{
    public interface IEmailService
    {
        Task <string> SendEmail(Quote quote, string toEmail);
    }
}