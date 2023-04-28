using Demo5.Dataacess.Entities;
using Demo5.Dataacess;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml;

namespace Demo5.Controllers
{
	public class ClassController : Controller
	{
		private AppDbContext _dbcontext;
		public ClassController (AppDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public IActionResult Index()
		{
            List<Class> classList = _dbcontext.Class.ToList();
            ViewBag.Class = classList;
            return View();
		}
		public IActionResult Add()
		{
			return View("Add");
		}
		public IActionResult Insert(string name, int ClassRoom, int Capacity)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter the name";
				return View("Add");
			}
			var classobj = new Class();
			classobj.Name = name;
			classobj.ClassRoom = ClassRoom;
			classobj.Capacity = Capacity;
			_dbcontext.Class.Add(classobj);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var data = _dbcontext.Class.ToList().Where(x => x.Id == id).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.name = data.Name;
            ViewBag.classroom = data.ClassRoom ;
			ViewBag.capacity = data.Capacity;
            return View();
        }
       public IActionResult Update(int id, string name, int classRoom, int Capacity)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter the name";
				return View("Add");
			}
			var Classobj = _dbcontext.Class.ToList().Where(x => x.Id == id).FirstOrDefault();
            Classobj.Id = id;
			Classobj.Name = name;
			Classobj.ClassRoom =classRoom;
			Classobj.Capacity = Capacity;
            _dbcontext.Class.Update(Classobj);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");

		}
		public IActionResult Delate(int id)
		{
            var data = _dbcontext.Class.Where(x => x.Id == id).FirstOrDefault();
            _dbcontext.Class.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
