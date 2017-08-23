using AuthApp.Models;
using AuthApp.Models.ViewModels;
using Nest;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    public class SearchController : Controller
    {

        private const string DefaultIndexName = "defaultindex";
        private const string ElasticSearchServerUri = @"http://localhost:9200";
        private const string ArticlesIndexName = "articles";

        // GET: StoreManager
        public async Task<ActionResult> StartIndexAsync()
        {
            var settings = new ConnectionSettings().DefaultIndex(DefaultIndexName);
            var client = new ElasticClient(settings);
            client.DeleteIndex(DefaultIndexName);
            var testData = Article.GetTestData();
            var response = await client.IndexManyAsync(testData);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> FindAsync(SearchViewModel searchModel)
        {
            var client = CreateElasticClient();
            var searchResponse = await client.SearchAsync<Article>(s => s
            .Query(q => q
            .Match(m => m
                .Field(f => f.Text)
                .Field(f => f.Name)
                .Query(searchModel.Phrase))));
            var results = searchResponse.Documents;
            var viewModels = results.Select(res => new SearchResultViewModel()
            {
                Text = res.Text,
                Title = res.Name
            });
            return View("SearchResult", viewModels);
        }

        private IElasticClient CreateElasticClient()
        {
            var settings = CreateConnectionSettings();
            var client = new ElasticClient(settings);

            if (client.IndexExists(ArticlesIndexName).Exists)
            {
                client.DeleteIndex(ArticlesIndexName);
            }

            client.CreateIndex(ArticlesIndexName, descriptor => descriptor
                .Mappings(ms => ms
                    .Map<Article>(m => m
                        .AutoMap()
                        .Properties(ps => ps
                            .Text(t => t
                                .Name(n => n.Text)
                                .Analyzer("substring_analyzer"))
                             .Text(t => t
                                .Name(n => n.Name)
                                .Analyzer("substring_analyzer"))
                        )
                    )
                )
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(analyzer => analyzer
                            .Custom("substring_analyzer", analyzerDescriptor => analyzerDescriptor
                                .Tokenizer("standard")
                                .Filters("lowercase", "substring")
                            )
                        )
                        .TokenFilters(tf => tf
                            .NGram("substring", filterDescriptor => filterDescriptor
                                .MinGram(2)
                                .MaxGram(15)
                            )
                        )
                    )
                )
            );

            return client;
        }

        private static ConnectionSettings CreateConnectionSettings()
        {
            var uri = new Uri(ElasticSearchServerUri);
            var settings = new ConnectionSettings(uri)
            .DefaultIndex(DefaultIndexName)
            .InferMappingFor<Article>(d => d
            .IndexName(ArticlesIndexName)
            );

            return settings;
        }
    }
}