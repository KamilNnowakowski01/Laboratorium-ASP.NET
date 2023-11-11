using Lab_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lab_3.Controllers
{
    public class ComputerController : Controller
    {
       
        public ComputerController()
        {
            // Dodawanie przykładowych komputerów do kolekcji przy inicjalizacji kontrolera
            if (!_computers.Any())
            {
                CreateExampleComputers();
            }
        }

        static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();

        public void CreateExampleComputers ()
        {
            Computer komputer1 = new Computer
            {
                Id = 1,
                Name = "Komputer-2022",
                Processor = "Intel Core i5",
                MemoryRAM = "8",
                GraphicsCard = "NVIDIA GeForce GTX 1650",
                Manufacturer = "HP",
                ProductionDate = new DateTime(2022, 1, 15)
            };
            Computer komputer2 = new Computer
            {
                Id = 2,
                Name = "Komputer AMD",
                Processor = "AMD Ryzen 7",
                MemoryRAM = "16",
                GraphicsCard = "AMD Radeon RX 6700 XT",
                Manufacturer = "Dell",
                ProductionDate = new DateTime(2021, 8, 22)
            };
            Computer komputer3 = new Computer
            {
                Id = 3,
                Name = "Laptop For Coding",
                Processor = "Intel Core i7",
                MemoryRAM = "32",
                GraphicsCard = "NVIDIA GeForce RTX 3080",
                Manufacturer = "Asus",
                ProductionDate = new DateTime(2020, 5, 10)
            };
            _computers.Add(komputer1.Id, komputer1);
            _computers.Add(komputer2.Id, komputer2);
            _computers.Add(komputer3.Id, komputer3);
        }

        public IActionResult Index()
        {
            return View(_computers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create([FromForm] Computer model)
        {
            if (ModelState.IsValid)
            {
                int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() : 0;
                model.Id = id + 1;
                _computers.Add(model.Id, model);

                return RedirectToAction("Index");
            }
            return View("Form");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_computers.Keys.Contains(id))
            {
                return View(_computers[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computers[model.Id] = model;
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
            if (_computers.Keys.Contains(id))
            {
                return View(_computers[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_computers.Keys.Contains(id))
            {
                _computers.Remove(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_computers.Keys.Contains(id))
            {
                return View(_computers[id]);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
