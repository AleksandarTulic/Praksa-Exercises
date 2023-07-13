using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;

namespace EmailExample.Services{
    public class EmailService{

        public async Task<bool> sendText(string sender, string receiver, string content){
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", sender));
            email.To.Add(new MailboxAddress("Receiver Name", receiver));

            email.Subject = "Testing out email sending";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { 
                Text = content
            };

            try{
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("localhost", 1025, false);

                // Note: only needed if the SMTP server requires authentication
                //smtp.Authenticate("smtp_username", "smtp_password");

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> sendHtml(string sender, string receiver, string content){
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", sender));
            email.To.Add(new MailboxAddress("Receiver Name", receiver));

            email.Subject = "Testing out email sending";
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = "<p>Hey,<br>Just wanted to say hi all the way from the land of C#.<br>-- Code guy</p>";

            bodyBuilder.TextBody = "Hey, Just wanted to say hi all the way from the land of C#. -- Code guy"; 

            email.Body = bodyBuilder.ToMessageBody();

            try{
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("localhost", 1025, false);

                // Note: only needed if the SMTP server requires authentication
                //smtp.Authenticate("smtp_username", "smtp_password");

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> sendHtmlWithImage(string sender, string receiver, string content){
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", sender));
            email.To.Add(new MailboxAddress("Receiver Name", receiver));

            email.Subject = "Testing out email sending";
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = @"Hey, Just wanted to say hi all the way from the land of C#. -- Code guy"; 
            var image = bodyBuilder.LinkedResources.Add(@"C:\Users\Windows10\Desktop\postgres1.png");

            image.ContentId = MimeUtils.GenerateMessageId();
            bodyBuilder.HtmlBody = string.Format(@"<p>Hey,<br>Just wanted to say hi all the way from the land of C#.<br>-- Code guy</p><br>
            <center><img src=""cid:{0}""></center>", image.ContentId);

            email.Body = bodyBuilder.ToMessageBody();

            try{
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("localhost", 1025, false);

                // Note: only needed if the SMTP server requires authentication
                //smtp.Authenticate("smtp_username", "smtp_password");

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> sendHtmlWithImageAndAttachment(string sender, string receiver, string content){
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", sender));
            email.To.Add(new MailboxAddress("Receiver Name", receiver));

            email.Subject = "Testing out email sending";
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = @"Hey, Just wanted to say hi all the way from the land of C#. -- Code guy"; 
            var image = bodyBuilder.LinkedResources.Add(@"C:\Users\Windows10\Desktop\postgres1.png");

            image.ContentId = MimeUtils.GenerateMessageId();
            bodyBuilder.HtmlBody = string.Format(@"<p>Hey,<br>Just wanted to say hi all the way from the land of C#.<br>-- Code guy</p><br>
            <center><img src=""cid:{0}""></center>", image.ContentId);

            //ATTACHEMNT
            bodyBuilder.Attachments.Add(@"C:\Users\Windows10\Desktop\p2p plaćanje.pdf");

            email.Body = bodyBuilder.ToMessageBody();

            try{
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("localhost", 1025, false);

                // Note: only needed if the SMTP server requires authentication
                //smtp.Authenticate("smtp_username", "smtp_password");

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }

            return false;
        }

        /*
        
            SENDING MESSAGE TO MULTIPLE USERS

            InternetAddressList list = new InternetAddressList();
            list.Add(new MailboxAddress("First Receiver", "first@email.com"));
            list.Add(new MailboxAddress("Second Receiver", "second@email.com"));
            list.Add(new MailboxAddress("Third Receiver", "third@email.com"));

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
            message.To.AddRange(RecipientList);
        
        */

    }
}