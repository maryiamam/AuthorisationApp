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
		private const int ItemsPerPage = 20;

		// GET: StoreManager
		public async Task<ActionResult> StartIndexAsync()
		{
			var client = CreateElasticClient();
			var testData = Article.GetTestData();
			var response = await client.IndexManyAsync(testData);

			return Json(response, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public async Task<ActionResult> FindAsync(SearchViewModel searchModel)
		{
			var settings = CreateConnectionSettings();
			var client = new ElasticClient(settings);
			var pageNumber = searchModel.Page ?? 0;
			var itemsPerPage = searchModel.ItemsPerPage ?? ItemsPerPage;
			var searchResponse = await client.SearchAsync<Article>(descriptor => descriptor
			.From(pageNumber * itemsPerPage)
			.Size(itemsPerPage)
			.Query(q => q
				.QueryString(queryDescriptor => queryDescriptor
					.Query(searchModel.Phrase)
					.Fields(fs => fs
						.Field(f1 => f1.Text)
						.Field(f1 => f1.Name)
					)
				)
			));
			var results = searchResponse.Documents;
			var viewModel = new SearchResultViewModel()
			{
				Hints = results.Select(res => new HintViewModel()
				{
					Text = res.Text,
					Title = res.Name
				}),
				TotalCount = searchResponse.Total
			};

			return View("SearchResult", viewModel);
		}

		private static IElasticClient CreateElasticClient()
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
								.MaxGram(50)
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