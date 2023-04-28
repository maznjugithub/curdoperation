 using Demo5.Dataacess.Entities;
using Demo5.Dataacess;
using Microsoft.AspNetCore.Mvc;

namespace Demo5.Controllers
{
	public class TeacherController : Controller
	{
		private AppDbContext _dbcontext;
		private object data;

		public TeacherController(AppDbContext dbContext)
		{
			_dbcontext = dbContext;

		}
		public IActionResult Index()
		{
            List<Teacher> TeacherList = _dbcontext.Teacher.ToList();
            ViewBag.Teacher = TeacherList;
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
			var Tr = new Teacher();
			Tr.Name = name;
			Tr.Address = address;
		    _dbcontext.Teacher.Add(Tr);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		
			public IActionResult Edit(int id)
	    	{
			var data = _dbcontext.Teacher.ToList().Where(x => x.Id == id).FirstOrDefault();
			ViewBag.id = id;
			ViewBag.name = data.Name;
			ViewBag.address = data.Address ?? "";
			return View();
		    }
		public IActionResult Update(int id, string name, string address)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter your name";
				return View("Add");
			}
			var Tr = new Teacher();
			Tr.Id = id;
			Tr.Name = name;
			Tr.Address = address;
			_dbcontext.Teacher.Update(Tr);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{

			var data = _dbcontext.Teacher.ToList().Where(x => x.Id == id).FirstOrDefault();
			_dbcontext.Teacher.Remove(data);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
