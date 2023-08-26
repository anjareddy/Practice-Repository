using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Users.DAL.Repositories.Interfaces;
using Users.ReadModels;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Logging;

namespace Users.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly ILogger<AlertsController> _logger;
        private IUserRepository _userRepository;

        public AlertsController(ILogger<AlertsController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<string> Ping()
        {
            _logger.LogError("[LOGGED_AS_ERROR]Logging Error from {0}->{1}", nameof(AlertsController), nameof(Ping));
            return "Hello from Capstone Alert System!";
        }

        [HttpPost]
        public async Task AlertEmergencyUser(int userId)
        {
            _logger.LogError("[LOGGED_AS_ERROR]Start of {0}->{1}", nameof(AlertsController), nameof(AlertEmergencyUser));
            var user = _userRepository.GetUserById(userId);
            await AlertUserBySendingMessage(user);
            _logger.LogError("[LOGGED_AS_ERROR]End of {0}->{1}", nameof(AlertsController), nameof(AlertEmergencyUser));
        }

        private async Task AlertUserBySendingMessage(User user)
        {
            _logger.LogError("[LOGGED_AS_ERROR]Start of {0}->{1}", nameof(AlertsController), nameof(AlertUserBySendingMessage));
            string accountSid = "AC488cf12cc86316c47ae81f831d7cae62";//ORad3f97b2add13898619220d436032bc0
            string authToken = "46ccf35231e8c1c2fcfd87c0c3225f3e";

            TwilioClient.Init(accountSid, authToken);

            try
            {
               
                var message = MessageResource.Create(
                    body: $"IMPORTANT: Hello {user.EmergencyContactName}, {user.Name} is driving car while drowsy!!!!!, please alert",
                    from: new Twilio.Types.PhoneNumber("+18447801056"),
                    to: new Twilio.Types.PhoneNumber(user.EmergencyContactMobileNumber)
                );

            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR WHILE SENDING DROWSINESS ALERT MESSAGE for User {0}", user.Name);
                var message = MessageResource.Create(
                    body: $"IMPORTANT: Hello Admin, Error occured while sending message to {user.EmergencyContactName} and {user.Name}!!!!!, please alert the driver.\nError Message: {ex.Message}",
                    from: new Twilio.Types.PhoneNumber("+18447801056"),
                    to: new Twilio.Types.PhoneNumber("3305547237")
                );
            }

            try
            {
                

                var message2 = MessageResource.Create(
                    body: $"IMPORTANT: Hello {user.Name}, it seems you are drowsy, its time to take rest:)",
                    from: new Twilio.Types.PhoneNumber("+18447801056"),
                    to: new Twilio.Types.PhoneNumber(user.MobileNumber)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR WHILE SENDING DROWSINESS ALERT MESSAGE for User {0}", user.Name);
                var message = MessageResource.Create(
                    body: $"IMPORTANT: Hello Admin, Error occured while sending message to {user.EmergencyContactName} and {user.Name}!!!!!, please alert the driver.\nError Message: {ex.Message}",
                    from: new Twilio.Types.PhoneNumber("+18447801056"),
                    to: new Twilio.Types.PhoneNumber("3305547237")
                );
            }
            _logger.LogError("[LOGGED_AS_ERROR]End of {0}->{1}", nameof(AlertsController), nameof(AlertUserBySendingMessage));
        }

        private async Task SendEmailToUserEmergencyContact(User user)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("anjareddygaddam@yahoo.com");
                message.To.Add(new MailAddress("argaddam1161@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html
                message.Body = "BODY";
                smtp.Port = 465;
                smtp.Host = "smtp.mail.yahoo.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("anjareddygaddam@yahoo.com", "wrwewerwe");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}