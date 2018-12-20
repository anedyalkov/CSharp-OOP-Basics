namespace _04.Telephony.Models
{
    using _04.Telephony.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone(List<string> phones, List<string> urls)
        {
            this.phoneNumbers = phones;
            this.urls = urls;
        }
        private List<string> phoneNumbers;
        private List<string> urls;

        public string Call()
        {
            var sb = new StringBuilder();
            foreach (var number in phoneNumbers)
            {
                if (!number.All(char.IsDigit))
                {
                    sb.AppendLine("Invalid number!");
                }
                else
                {
                    sb.AppendLine($"Calling... {number}");
                }
            }
            return sb.ToString().Trim();
        }

        public string Browse()
        {
            var sb = new StringBuilder();
            foreach (var url in urls)
            {
                if (url.Any(char.IsDigit))
                {
                    sb.AppendLine("Invalid URL!");
                }
                else
                {
                    sb.AppendLine($"Browsing: {url}!");
                }
            }
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Call())
                .AppendLine(Browse());

            return sb.ToString().Trim();
        }
    }
}
