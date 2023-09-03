using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVCpracticeCRUD.Models;

namespace MVCpracticeCRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            DbOperations db = new DbOperations();
            List<Student>stud = db.GetAllStudents();
            return View(stud);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            DbOperations db =new DbOperations();
            
            Student s=db.findStudent(id);
            return View(s);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                Student s=new Student();
                DbOperations db=new DbOperations();
                s.Id = Convert.ToInt32(collection["Id"]);
                s.Name = collection["Name"].ToString();
                s.Department = collection["Department"].ToString();
                db.InsertStudent(s);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int Id)
        {
            DbOperations db=new DbOperations();
            Student s = db.findStudent(Id);
            return View(s);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Student s)
        {
            try
            {
                DbOperations db = new DbOperations();
                db.UpdateStudent(Id, s);       
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            DbOperations db=new DbOperations(); 
            Student stud=db.findStudent(id);
            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DbOperations db=new DbOperations();
                db.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
