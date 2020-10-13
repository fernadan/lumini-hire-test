using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Context.Representation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuminiHire.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IScorecardApplication _scorecardApplication;

        public DashboardController(IScorecardApplication actorsApplication)
        {
            _scorecardApplication = actorsApplication;
        }

        public IActionResult Index()
        {
            ViewBag.qntDocs = _scorecardApplication.GetCountDocs();
            return View();
        }
    }
}
