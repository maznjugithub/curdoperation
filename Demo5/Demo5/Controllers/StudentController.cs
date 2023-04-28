using Demo5.Dataacess.Entities;
using Demo5.Dataacess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Demo5.Controllers
{
	public class StudentController : Controller
	{
		private AppDbContext _dbcontext;

		public StudentController(AppDbContext dbContext)
		{
			_dbcontext = dbContext;
		}
		public IActionResult Index()
		{
			List<Student> studentList = _dbcontext.Students.ToList();
			ViewBag.Students = studentList;
			return View();
		}
		public IActionResult Add()
		{
			return View();
		}
		public IActionResult Insert(string name, string address)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter your name";
				return View("Add");
			}
			var st = new Student();
			st.Name = name;
			st.Address = address;
			_dbcontext.Students.Add(st);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var data = _dbcontext.Students.ToList().Where(x => x.Id == id).FirstOrDefault();
			ViewBag.id = id;
			ViewBag.name = data.Name;
			ViewBag.address = data.Address ?? "";
			return View();
		}

		public IActionResult Update(int id, string name, string address)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter your name ";
				return View("Add");
			}
			var st = new Student();
			st.Id = id;
			st.Name = name;
			st.Address = address;
			_dbcontext.Students.Update(st);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
            var data =_dbcontext.Students.ToList().Where(x => x.Id == id).FirstOrDefault();
			_dbcontext.Students.Remove(data);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");

        }
			
	}
}
