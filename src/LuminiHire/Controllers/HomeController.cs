using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuminiHire.Models;
using Elasticsearch.Context.Application;
using Elasticsearch.Context.Representation;
using Elasticsearch.Context.Model;

namespace LuminiHire.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScorecardApplication _scorecardApplication;

        public HomeController(IScorecardApplication actorsApplication)
        {
            _scorecardApplication = actorsApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Get(string query, int page = 1)
        {
            Data _d = new Data();
            DateTime _inicio = DateTime.Now;

            _d.search = new Search() { query = query };

            ScorecardAggregationModel _agg = _scorecardApplication.GetScorecardAggregation(query);
            _d.qntFounded = Convert.ToInt32(_agg.qntFounded);
            _d.qntPages = _agg.qntPages;

            int from = (20 * (page - 1)) + 1;
            var result = _scorecardApplication.GetByName(query, from);

            _d.Schools = result.ToList();
            _d.timeToFind = DateTime.Now.Subtract(_inicio).TotalSeconds;

            return View(_d);
        }
    }
}
