using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
            private static List <Student>students= new List<Student>()
            {
             new Student()
             {

                Id = 1,
                Name = "Ranju",
                City = "Dublin",
                Age = 39
             },
             new Student()
             {

                Id = 2,
                Name = "Ranju1",
                City = "Dublin1",
                Age = 40
             }
            };
        [HttpGet]
        [Route("getStudents")]
        public async Task<ActionResult> GetStudents()
        {
            return Ok(students);
        }

        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null) {
                return BadRequest("No record found");
                    }

            return Ok(student);
        }
        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student request)
        {
            students.Add(request);

            return Ok(students);
        }
        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student request)
        {
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
            {
                return BadRequest("No record found");
            }
            student.Name = request.Name;
            student.Age = request.Age;
            student.City= request.City;

         return Ok(students);
        }


        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
            {
                return BadRequest("No record found");
            }
            students.Remove(student);   
            return Ok(students);
        }
    }
}
