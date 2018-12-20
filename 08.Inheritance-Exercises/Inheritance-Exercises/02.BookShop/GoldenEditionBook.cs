namespace _02.BookShop
{
    public class GoldenEditionBook:Book
    {
        public GoldenEditionBook(string author, string title, decimal price):base(author, title, price)
        {
            Price += Price * 30 / 100;
        }
    }
}
