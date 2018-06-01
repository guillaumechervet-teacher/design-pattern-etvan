using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Basket.Domain;
using Newtonsoft.Json;

namespace Basket.Infrastructure
{
    public class BasketService
    {
        public Basket1 GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            var liste = new List<BasketLine>();
            // here your code implementation
            foreach (var basketLineArticle in basketLineArticles)
            {
                var a = ArticleDatabase(basketLineArticle.Id);

                liste.Add(new BasketLine(new Article(a.Price,a.Category),basketLineArticle.Number ));
            }

            return  new Basket1(liste); 
        }

        private ArticleDatabase ArticleDatabase(string id)
        {
            // Retrive article from database
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");
            IList<ArticleDatabase> articleDatabases =
                JsonConvert.DeserializeObject<List<ArticleDatabase>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase => { return articleDatabase.Id == id; });
            return article;
        }
    }
} 