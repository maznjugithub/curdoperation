using Demo5.Dataacess.Entities;
using Demo5.Dataacess;
using Microsoft.AspNetCore.Mvc;
                          
namespace Demo5.Controllers
{
	public class BookController : Controller
	{
		private AppDbContext _dbcontext;

        public BookController(AppDbContext dbContext)
		{
			_dbcontext = dbContext;

		}

		public IActionResult Index()
		{
			List<Book> bookList = _dbcontext.Book.ToList(); 
			ViewBag.Books = bookList;
			return View();
			}		
		public IActionResult Add()
		{
			return View();
		}
		public IActionResult Insert(string name, string writerName)
		{
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter the name";
				return View("Add");
			}
			var book = new Book();
			book.Name = name;
		    book.WriterName = writerName;
			_dbcontext.Book.Add(book);
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit( int id)
		{
            var data = _dbcontext.Book.ToList().Where(x => x.Id == id).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.name = data.Name;
            ViewBag.writername = data.WriterName?? "";
            return View();

        }
        public IActionResult Update(int id, string name, string Writername)
        {
			if(string.IsNullOrEmpty(name))
			{
				ViewBag.errorname = "please enter the name";
				return View("Add");
			}
            var Book = new Book();
            Book.Id = id;
            Book.Name = name;
            Book.WriterName = Writername;
            _dbcontext.Book.Update(Book);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult Delete(int id)
		{

            var data = _dbcontext.Book.ToList().Where(x => x.Id == id).FirstOrDefault();
			_dbcontext.Book.Remove(data); 
			_dbcontext.SaveChanges();
		return RedirectToAction("Index");
        }
    }
}