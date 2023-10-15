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

        public void SetEmailToAddress(string emailAddress)
        {
            this.To = emailAddress;
        }

        public void SetEmailFromAddress(string emailAddress)
        {
            this.From = emailAddress;
        }
    }
}
