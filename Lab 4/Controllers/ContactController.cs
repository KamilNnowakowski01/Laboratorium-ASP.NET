using Lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_4.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.FindById(id);
            return contact != null ? View(contact) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.FindById(id);
            return contact != null ? View(contact) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _contactService.FindById(id);
            return contact != null ? View(contact) : NotFound();
        }
    }
}
