using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels;

namespace TradeDash.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public HomeController(
            IApiClient apiClient, 
            IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LongTerm()
        {
            return View();
        }

        public IActionResult ShortTerm()
        {
            return View();
        }
    }
}
