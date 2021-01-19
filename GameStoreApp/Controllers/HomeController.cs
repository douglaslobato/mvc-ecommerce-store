using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameStoreApp.Models;
using GameStoreApp.Repositories;
using GameStoreApp.ViewModels;

namespace GameStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJogoRepository _jogoRepository;

        public HomeController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                JogosPreferidos = _jogoRepository.JogosPreferidos
            };
            return View(homeViewModel);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }


        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
