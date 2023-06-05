using MyBookShopService.Data;
using MyBookShopService.Models;
using MyBookShopService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyBookShopService.Controllers
{
    public class ManageBooksController : Controller
    {
        private readonly BookRepository _BookService;

        public ManageBooksController(BookRepository BookService)
        {
			_BookService = BookService;

		}

        public IActionResult Index()
        {
            var models=_BookService.GetAll();
            return View(models);
        }

		public IActionResult Create()
		{
			var viewModel=_BookService.GetCreateViewModel();
			return View(viewModel);
		}

		public IActionResult Edit(int id)
		{
			var model = _BookService.GetEditViewModel(id);
			return View(model);
		}

		public IActionResult Save(BookDTO viewmodel)
		{
            if(ModelState.IsValid)
            {
				_BookService.Save(viewmodel);

                TempData["success"] = "Bilgiler kaydedildi.";
				return RedirectToAction("Index");
			}
			TempData["error"] = "Hata oluştu.";
			return View("Edit", viewmodel);
		}


		public IActionResult Delete(int id)
		{
			try
			{
				_BookService.Delete(id);
			} 
			catch (Exception ex) 
			{
				TempData["error"] = "Bir hata oluştu.";
				return RedirectToAction("Index");
			}
			
			TempData["success"] = "Kayıt silindi.";
			return RedirectToAction("Index");
		}
	}
}
