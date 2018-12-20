namespace _02.BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    public class Book
    {
        const int MinLength = 3;
        const string ErrorMessage = "{0} not valid!";

        protected string title;
        protected string author;
        protected decimal price;

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }
        public string Title
        {
            get { return title; }
            protected set
            {
                if (value.Length < MinLength)
                {
                    throw new ArgumentException(string.Format(ErrorMessage,nameof(Title)));
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            protected set
            {
                var authorFullName = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (authorFullName.Length > 1)
                {
                    var firstLetterSecondName = authorFullName[1][0];
                    if (char.IsDigit(firstLetterSecondName))
                    {
                        throw new ArgumentException(string.Format(ErrorMessage, nameof(Author)));
                    }
                    author = value;
                }
            }
        }

        public decimal Price
        {
            get { return price; }
            protected set
            {
                if (value <= 0)
                {

                    throw new ArgumentException(string.Format(ErrorMessage, nameof(Price)));
                }
                price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var type = this.GetType().Name;
            sb.AppendLine($"Type: {type}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Author: {Author}");
            sb.Append($"Price: {Price:F2}");
            return sb.ToString().Trim();
        }
    }
}
