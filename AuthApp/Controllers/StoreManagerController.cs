using AuthApp.Models;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    public class StoreManagerController : Controller
    {
        // GET: StoreManager
        public async Task<ActionResult> StartIndexAsync()
        {
            var settings = new ConnectionSettings().DefaultIndex("defaultindex");
            var client = new ElasticClient(settings);
            var testData = Article.GetTestData();
            var response = await client.IndexManyAsync(testData);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> FindAsync(string phraze)
        {
            var settings = new ConnectionSettings().DefaultIndex("defaultindex");
            var client = new ElasticClient(settings);
            var searchResponse = await client.SearchAsync<Article>(s => s
            .Query(q => q
            .Match(m => m
            .Field(f => f.Text)
            .Query(phraze)
            )
            )
            );

            var results = searchResponse.Documents;
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}