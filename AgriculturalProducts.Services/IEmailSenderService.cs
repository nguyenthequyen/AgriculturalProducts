using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IEmailSenderService
    {
        void SendEmail(string email, string subject, string body);
    }
}
