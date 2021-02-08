using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Project.IRepository;
using Test_Project.Models;

namespace Test_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Student> students= _repository.GetAll();
                return View(students);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Student student = _repository.GetById(id);
                return View(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        // GET: StudentController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(IFormCollection collection,Student model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _repository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                Student student = _repository.GetById(id);
                return View(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, IFormCollection collection,Student model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByName(string search)
        {
            try
            {
                IEnumerable<Student> students = _repository.SearchByName(search);
                return View("Index",students);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
