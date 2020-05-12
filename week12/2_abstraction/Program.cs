using System;

namespace _2_abstraction
{
    public class MailService
    {
        public void SendEmail()
        {
            Connect();
            Authenticate();
            // Send the email here
            Disconnect();
        }

        private void Connect()
        {
            Console.WriteLine("Connect");
        }

        private void Disconnect()
        {
            Console.WriteLine("Disconnect");
        }

        private void Authenticate()
        {
            Console.WriteLine("Authenticate");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mailService = new MailService();
            mailService.SendEmail();
        }
    }
}
