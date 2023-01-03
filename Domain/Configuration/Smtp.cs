namespace Domain.Configuration
{
    public class Smtp
    {
        public string? From { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}
