using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services.MailerSend
{
    public class EmailService : IEmailService
    {

        private readonly HttpClient _httpClient;
        private readonly string? _ApiKey;
        private readonly string? _fromEmail;


        public EmailService(HttpClient httpClient, IConfiguration configuration){

            _ApiKey = configuration["MailerSend:ApiKey"];
            _fromEmail = configuration["MailerSend:FromEmail"];
            _httpClient = httpClient;
        }

        public async Task<string> SendEmail(Quote quote, string toEmail)
        {
            var subject = "Confirmación de Cita veterianario!";
            string body = $"<h1>Confirmación de Cita</h1><br><p>La cita para tu mascota se ha generado con exito!</p>";


            var requestContent = new {
                from = new {email= _fromEmail},
                to = new[] {new{ email =  toEmail}},
                subject,
                text = body
            };

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _ApiKey);
        
        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://api.mailersend.com/v1/email", requestContent);

            response.EnsureSuccessStatusCode();
            return "Se ha enviado con exito !";
        }
        catch (HttpRequestException ex)
        {
            // Manejo de errores
            // Puedes registrar el error o lanzar una excepción personalizada
            return "Error  : " + ex.Message;
            throw new ApplicationException("Error sending email through MailerSend -:", ex);
        }
            
        }
    }
}