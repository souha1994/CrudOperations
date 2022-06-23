using CrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext dbContext;

        public StudentsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var Data = dbContext.Students.Include(x => x.filiere).OrderBy(x => x.StudentName).ToList();
            return View(Data);
        }
        public IActionResult Create()
        {
            ViewBag.Filieres = dbContext.Filieres.OrderBy(x => x.FiliereName).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            UpImg(student);
            if(ModelState.IsValid)
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fileres = dbContext.Filieres.OrderBy(x => x.FiliereName).ToList();
            return View();
        }
        private void UpImg(Student student)
        {
            var studentImg = HttpContext.Request.Form.Files;
            if (studentImg.Count > 0)
            {
                var ImgName = Guid.NewGuid().ToString() + Path.GetExtension(studentImg[0].FileName);
                var file_stream = new FileStream(Path.Combine(@"wwwroot/", "img", ImgName), FileMode.Create);
                studentImg[0].CopyTo(file_stream);
                student.StudentImage = ImgName;
            }
            else if (student.StudentImage == null)
            {
                student.StudentImage = "img.png";
            }
            else
            {
                student.StudentImage = student.StudentImage;
            }
        }
        public IActionResult Edit(int? ID)
        {
            ViewBag.Fileres = dbContext.Filieres.OrderBy(x => x.FiliereName).ToList();
            return View(dbContext.Students.Find(ID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            UpImg(student);
            if (ModelState.IsValid)
            {
                dbContext.Students.Update(student);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fileres = dbContext.Filieres.OrderBy(x => x.FiliereName).ToList();
            return View(student);
        }
        public IActionResult Delete(int? ID)
        {
            var data = dbContext.Students.Find(ID);
            if (data != null)
            {
                dbContext.Remove(data);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
