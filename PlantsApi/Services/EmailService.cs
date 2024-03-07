using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plants.Api.Domain.Entities;
using Plants.Infrastructure.DBSettings;

using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Plants.Api.Services
{
    public class EmailService:IEmailService
    {
        private readonly IMongoCollection<User> _users;
        private readonly IConfiguration _configuration;

        public EmailService(IOptions<PlantsDatabaseSettings> options, IConfiguration configuration)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _users = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<User>(options.Value.UsersCollectionName);
            _configuration = configuration;
        }
      
        public async Task<User> CheckEmailExists(string Email) =>
            await _users.Find(m => m.Email == Email
            ).FirstOrDefaultAsync();

        public  void SendEmail(string email)
        {
            var subject = "hhk";
            var messageBody = "<img class=\"ajz\" src=\"images/cleardot.gif\" alt=\"\">\r\n</tr>\r\n<tr>\r\n  <td>\r\n    <table bgcolor=\"9357B7\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"min-width:332px;max-width:600px;border:1px solid #e0e0e0;border-bottom:0;border-top-left-radius:3px;border-top-right-radius:3px\">\r\n      <tbody>\r\n        <tr>\r\n          <td height=\"72px\" colspan=\"3\"></td>\r\n        </tr>\r\n        <tr>\r\n          <td width=\"32px\"></td>\r\n          <td style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:24px;color:#ffffff;line-height:1.25\">Código de verificación de Planter</td>\r\n          <td width=\"32px\"></td>\r\n        </tr>\r\n        <tr>\r\n          <td height=\"18px\" colspan=\"3\"></td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n  </td>\r\n</tr>\r\n<tr>\r\n  <td>\r\n    <table bgcolor=\"#FAFAFA\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"min-width:332px;max-width:600px;border:1px solid #f0f0f0;border-bottom:1px solid #c0c0c0;border-top:0;border-bottom-left-radius:3px;border-bottom-right-radius:3px\">\r\n      <tbody>\r\n        <tr height=\"16px\">\r\n          <td width=\"32px\" rowspan=\"3\"></td>\r\n          <td></td>\r\n          <td width=\"32px\" rowspan=\"3\"></td>\r\n        </tr>\r\n        <tr>\r\n          <td>\r\n            <p>Hola, Planter:</p>\r\n            <p>Hemos recibido una solicitud para acceder a tu cuenta de Google, <span style=\"color:#659cef\" dir=\"ltr\">\r\n                <a href=\"mailto:theplanterapp@gmail.com\" target=\"_blank\">theplanterapp@gmail.com</a>\r\n              </span>, a través de tu dirección de correo electrónico. Tu código de verificación de Google es: </p>\r\n            <div style=\"text-align:center\">\r\n              <p dir=\"ltr\">\r\n                <strong style=\"text-align:center;font-size:24px;font-weight:bold\">732362</strong>\r\n              </p>\r\n            </div>\r\n            <p>Si no has solicitado este código, puede que alguien esté intentado acceder a la cuenta de Google <span style=\"color:#659cef\" dir=\"ltr\">\r\n                <a href=\"mailto:theplanterapp@gmail.com\" target=\"_blank\">theplanterapp@gmail.com</a>\r\n              </span>. <strong>No reenvíes este correo electrónico ni des el código a nadie.</strong>\r\n            </p>\r\n            <p>Has recibido este mensaje porque esta dirección de correo electrónico figura como dirección alternativa de la cuenta de Google <span style=\"color:#659cef\">\r\n                <a href=\"mailto:theplanterapp@gmail.com\" target=\"_blank\">theplanterapp@gmail.com</a>\r\n              </span>. Si crees que no debería figurar como tal, puedes <a href=\"https://accounts.google.com/AccountDisavow?adt=AOX8kipAMq8WiSGTdNPU7ScrmggF0CwCSTPKvHWhkABIdfKVu0HoVFfJuXwD6-VkyHAVUv9txMk\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accounts.google.com/AccountDisavow?adt%3DAOX8kipAMq8WiSGTdNPU7ScrmggF0CwCSTPKvHWhkABIdfKVu0HoVFfJuXwD6-VkyHAVUv9txMk&amp;source=gmail&amp;ust=1709935058691000&amp;usg=AOvVaw0H5cTLeL32qr-ZnK_49FPb\">eliminarla de dicha cuenta</a>. </p>\r\n            <p>Atentamente,</p>\r\n            <p>El equipo de Cuentas de Planter</p>\r\n          </td>\r\n        </tr>\r\n        <tr height=\"32px\"></tr>\r\n      </tbody>\r\n    </table>\r\n  </td>\r\n</tr>\r\n<tr height=\"16\"></tr>\r\n<tr>\r\n  <td style=\"max-width:600px;font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:10px;color:#bcbcbc;line-height:1.5\">\r\n    <table>\r\n      <tbody>\r\n        <tr>\r\n          <td>\r\n            <table style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:10px;color:#666666;line-height:18px;padding-bottom:10px\">\r\n              <tbody>\r\n                <tr>\r\n                  <td>Este correo electrónico no puede recibir respuestas. Para obtener más información, accede al <a href=\"https://support.google.com/accounts/troubleshooter/2402620?ref_topic=2364467\" style=\"text-decoration:none;color:#4d90fe\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://support.google.com/accounts/troubleshooter/2402620?ref_topic%3D2364467&amp;source=gmail&amp;ust=1709935058691000&amp;usg=AOvVaw1_Pm-VdPIDpSnlCrKw1cyC\">Planter</td>\r\n                </tr>\r\n              </tbody>\r\n            </table>\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n  </td>\r\n</tr>\r\n</tbody>\r\n              <img class=\"mL\" src=\"images/cleardot.gif\" alt=\"\">";
            var emailApp = this._configuration.GetSection("Services").GetSection("Email")["EmailApp"];
            var passEmailApp = this._configuration.GetSection("Services").GetSection("Email")["PassEmailApp"];
            var emailName = this._configuration.GetSection("Services").GetSection("Email")["EmailName"];            
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailName, emailApp));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = messageBody };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(emailApp, passEmailApp);
                client.Send(message);
                client.Disconnect(true);
            }

            
        }

     
    }
}
