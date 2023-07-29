namespace Practice.CityInfo.API.Services
{
    public class LocalMailService: IMailService
    {
        private string fromMail = string.Empty;
        private string toMail = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            fromMail = configuration.GetSection("MailService").GetValue<string>("fromMail");
            toMail = configuration["MailService:toMail"];
        }

        public Task Send(string subject, string message)
        {
            
            Console.WriteLine(fromMail);
            Console.WriteLine(toMail);
            Console.WriteLine(subject);
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
