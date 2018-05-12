using AspNetMvcCourse.Models;
using AspNetMvcCourse.Services;
using Dapper;
using System.Web.Mvc;

namespace AspNetMvcCourse.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments
        public ActionResult Index(int id)
        {
            // Get payments by students by id
            using (var c = ConnectionHelper.GetConnection())
            {
                const string studentSql = @"SELECT * FROM Students WHERE Id = @Id";

                var student = c.QueryFirstOrDefault<Student>(studentSql, new { Id = id });

                ViewBag.Student = student;

                const string sql = @"
                SELECT * FROM Payments
                WHERE StudentId = @StudentId";

                var payments = c.Query<Payment>(sql, new { StudentId = student.Id });

                return View(payments);
            }
        }

        public ActionResult Create(int id)
        {
            using (var c = ConnectionHelper.GetConnection())
            {
                // This can be refactored to another class
                const string sql = @"SELECT * FROM Students WHERE Id = @Id";

                var student = c.QueryFirstOrDefault<Student>(sql, new { Id = id });

                if (student == null) return HttpNotFound();

                ViewBag.Student = student;
                
                return View();
            }
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "Description,PaymentDate,Amount,StudentId")] Payment payment)
        {
            if (!ModelState.IsValid) return View(payment);

            using (var c = ConnectionHelper.GetConnection())
            {
                const string sql =@"
                    INSERT INTO Payments (Description, PaymentDate, Amount, StudentId) 
                    VALUES (@Description, @PaymentDate, @Amount, @StudentId)";
                
                c.Execute(sql, payment);
                return RedirectToAction("Index", new { id = payment.StudentId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (var c = ConnectionHelper.GetConnection())
            {
                // Get payment
                const string paymentSql = @"SELECT * FROM Payments WHERE Id = @Id";
                var payment = c.QueryFirstOrDefault<Payment>(paymentSql, new { Id = id });
                
                const string sql = @"DELETE FROM Payments WHERE Id = @Id";
                c.Execute(sql, new { Id = id });

                return RedirectToAction("Index", new { id = payment.StudentId });
            }
        }
    }
}