using EmailExample.DTOs;
using EmailExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailExample.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase{

        private readonly EmailService emailService;

        public EmailController(EmailService emailService){
            this.emailService = emailService;
        }

        [HttpPost("/send-text-email")]
        public async Task<IActionResult> sendTextEmail(SendTextMailDTO email){
            bool flag = await emailService.sendText(email.Sender, email.Receiver, email.Content);

            return flag ? Ok(true) : BadRequest();
        }

        [HttpPost("/send-html-email")]
        public async Task<IActionResult> sendHtmlEmail(SendTextMailDTO email){
            bool flag = await emailService.sendHtml(email.Sender, email.Receiver, email.Content);

            return flag ? Ok(true) : BadRequest();
        }

        [HttpPost("/send-html-with-image-email")]
        public async Task<IActionResult> sendHtmlWithImageEmail(SendTextMailDTO email){
            bool flag = await emailService.sendHtmlWithImage(email.Sender, email.Receiver, email.Content);

            return flag ? Ok(true) : BadRequest();
        }

        [HttpPost("/send-html-with-image-and-attachment-email")]
        public async Task<IActionResult> sendHtmlWithImageAndAttachmentEmail(SendTextMailDTO email){
            bool flag = await emailService.sendHtmlWithImageAndAttachment(email.Sender, email.Receiver, email.Content);

            return flag ? Ok(true) : BadRequest();
        }

    }
}