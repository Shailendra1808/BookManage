using BookManageProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManageProject.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext context;
        private readonly IWebHostEnvironment environment;

        public BookController(BookDbContext context,IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var data=context.BookData.ToList();
            return View(data);
        }
        public IActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(Book model)
        {
            if (ModelState.IsValid)
            {
                var email=context.Book.FirstOrDefault(x=>x.EmailAddress == model.EmailAddress);
                if (email == null)
                {
                    Book NewBook = new Book()
                    {
                        Name = model.Name,
                        Gender = model.Gender,
                        Address = model.Address,
                        EmailAddress = model.EmailAddress,
                        Password = model.Password,
                        ContactNumber = model.ContactNumber,
                    };
                    context.Book.Add(NewBook);
                    context.SaveChanges();
                    return RedirectToAction("Login");

                }
                else
                {
                    TempData["Error"] = "Already Registered";
                    return RedirectToAction("SignUp");
                }
             
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = context.Book.FirstOrDefault(x => x.EmailAddress == model.EmailAddress && x.Password == model.Password);
                if (data != null)
                {
                    return RedirectToAction("AddBook");
                }
                else
                {


                    return RedirectToAction("Login");
                }

            }
            return View("Login", model);
        }
        public IActionResult AddBook()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddBook(BookData model, IFormFile BookImage)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (BookImage != null)
                {
                    string uploadsFolder = Path.Combine(environment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(BookImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        BookImage.CopyTo(fileStream);
                    }
                }

                BookData newBookData = new BookData
                {
                    BookName = model.BookName,
                    BookPrice = model.BookPrice,
                    BookDescription = model.BookDescription,
                    BookImage = uniqueFileName
                };

                context.BookData.Add(newBookData);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
            {
                var data = context.BookData.Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    context.BookData.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Details");
                }
                return View(data);
            }

        public IActionResult Details()
        {
            var data=context.BookData.ToList();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = context.BookData.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(BookData model)
        {
            if(ModelState.IsValid)
            {
                context.BookData.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }




    }
}
