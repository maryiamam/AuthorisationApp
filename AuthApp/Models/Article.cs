using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Models
{
    public class Article
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }

        public static List<Article> GetTestData()
        {
            var testData = new List<Article>
            {
                new Article
                {
                    Name = "Article1",
                    Author = "Lesha",
                    Text = "Something text blabla",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Article2",
                    Author = "Masha",
                    Text = "Something text blabla",
                    CreatedOn = new DateTime(2016, 5, 22)
                }
            };
            return testData;
        }
    }
}