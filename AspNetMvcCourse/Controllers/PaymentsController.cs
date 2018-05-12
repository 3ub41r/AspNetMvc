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
                const string sql = @"SELECT * FROM Payments a 
                JOIN Students b ON b.Id = a.StudentId 
                WHERE StudentId = @StudentId";

                var payments = c.Query<Payment, Student, Payment>(sql, (payment, student) =>
                    {
                        payment.Student = student;
                        return payment;
                    }, new { StudentId = id });

                return View(payments);
            }
        }
    }
}