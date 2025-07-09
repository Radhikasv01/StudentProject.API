using Microsoft.AspNetCore.Mvc;
using Student.Interface;
using Student.Model;

public class EmailController : ControllerBase
{
    private readonly IEmail _emailService;

    public EmailController(IEmail emailService)
    {
        _emailService = emailService;
    }

    public async Task<IActionResult> SendTestEmail()
    {
        var emailModel = new EmailModel
        {
            To = new List<string> { "recipient@example.com" },
            Subject = "Test Subject",
            Body = "Test Body"
        };

        await _emailService.SendEmailAsync(emailModel);
        return Ok("Email sent successfully!");
    }
}
