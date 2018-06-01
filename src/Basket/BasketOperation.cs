using System.Collections.Generic;

namespace Basket.Domain
{
    public class BasketOperation
    {
        private readonly Infrastructure.BasketService _basketService;
        public BasketOperation(Infrastructure.BasketService basketService)
        {
            _basketService = basketService;
        }
        public int CalculateAmout(IList<BasketLineArticle> basketLineArticles)
        {
            Basket1 basket =
                _basketService.GetBasket(basketLineArticles);
            return basket.Calculate();
        }
    }
}