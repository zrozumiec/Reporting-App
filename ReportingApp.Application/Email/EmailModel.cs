namespace ReportingApp.Application.Email
{
    public class EmailModel
    {
        public string To { get; private set; }

        public string From { get; private set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public void SetEmailToFromAddress(string emailAddress)
        {
            this.To = emailAddress;
            this.From = emailAddress;
        }
    }
}
