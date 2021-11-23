using Identity.Models;
using Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequest _requestRepository;
        public HomeController(IRequest requestRepository)
        {
            _requestRepository = requestRepository;
        }
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult Index()
        {
            var model = _requestRepository.GetAllRequests();
            return View(model);
        }
        public ViewResult Request()
        {
            var model = _requestRepository.GetAllRequests();
            return View(model);
        }
        public ViewResult RequestDetails(int? id)
        {
            HomeRequestsViewModel homeRequestsViewModel = new HomeRequestsViewModel()
            {
                Request = _requestRepository.GetRequest(id ?? 1)
            };
            return View(homeRequestsViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Request request)
        {
            if (request.RequestName != null)
            {
                Request newRequest = _requestRepository.AddRequest(request);
                request.Id = newRequest.Id;
                return RedirectToAction("RequestDetails", new { id = newRequest.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Request request = _requestRepository.GetRequest(id);
            
            Request newRequest = new Request
            {
                RequestName = request.RequestName,
                Department = request.Department,
                DateAccepted = request.DateAccepted.Date,
                Description = request.Description
            };
            return View(newRequest);
        }
        [HttpPost]
        public IActionResult Edit(Request model)
        {
            Request request = _requestRepository.GetRequest(model.Id);
            request.RequestName = model.RequestName;
            request.Department = model.Department;
            request.Description = model.Description;
            request.DateAccepted = model.DateAccepted;
            if (ModelState.IsValid)
            {
                _requestRepository.UpdateRequest(request);
                return RedirectToAction("Request");
            }
            return View();
        }


        //public ViewResult RequestDetails(int? id)
        //{
        //    HomeRequestsViewModel homeRequestsViewModel = new HomeRequestsViewModel()
        //    {
        //        Request = _requestRepository.GetRequest(id ?? 1)
        //    };
        //    return View(homeRequestsViewModel);
        //}

        [HttpGet]
        public ViewResult Delete(int id)
        {
            if (id != 0)
            {
                HomeRequestsViewModel homeRequestsViewModel = new HomeRequestsViewModel()
                {
                    Request = _requestRepository.GetRequest(id)
                };
                return View(homeRequestsViewModel); 
            }
            return View(nameof(Request));
        }
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            Request requestToDelete = _requestRepository.GetRequest(id);
            _requestRepository.DeleteRequest(requestToDelete.Id);

            return View("DeleteMessage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
