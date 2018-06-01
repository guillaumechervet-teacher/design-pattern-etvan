namespace Basket.Domain
{
    public class Article    
    {
        private readonly int _price;
        private readonly string _catergory;

        public Article(int price, string catergory)
        {
            _price = price;
            _catergory = catergory;
        }

        public int Calculate()
        {
            var amount = 0;
            var articlePrice = _price;
            switch (_catergory)
            {
                case "food":
                    amount += articlePrice * 100 + articlePrice * 12;
                    break;
                case "electronic":
                    amount += articlePrice * 100 + articlePrice * 20 + 4;
                    break;
                case "desktop":
                    amount += articlePrice * 100 + articlePrice * 20;
                    break;
            }

            return amount;
        }
    }
}