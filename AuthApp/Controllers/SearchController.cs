﻿using AuthApp.Models;
using AuthApp.Models.ViewModels;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AuthApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: StoreManager
        public async Task<ActionResult> StartIndexAsync()
        {
            var settings = new ConnectionSettings().DefaultIndex("defaultindex");
            var client = new ElasticClient(settings);
            client.DeleteIndex("defaultindex");
            var testData = Article.GetTestData();
            var response = await client.IndexManyAsync(testData);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> FindAsync(SearchViewModel searchModel)
        {
            var settings = new ConnectionSettings().DefaultIndex("defaultindex");
            var client = new ElasticClient(settings);
            var searchResponse = await client.SearchAsync<Article>(s => s
            .Query(q => q
            .Match(m => m
            .Field(f => f.Text)
            .Query(searchModel.Phrase))));
            var results = searchResponse.Documents;
            var viewModels = results.Select(res => new SearchResultViewModel()
            {
                Text = res.Text,
                Title = res.Name
            });
            return View("SearchResult", viewModels);
        }
    }
}