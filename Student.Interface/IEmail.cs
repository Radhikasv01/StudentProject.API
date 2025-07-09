using System.Threading.Tasks;
using Student.Model;

namespace Student.Interface
{
    public interface IEmail
    {
        Task SendEmailAsync(EmailModel emailModel); // Simple async method for sending email
    }
}
