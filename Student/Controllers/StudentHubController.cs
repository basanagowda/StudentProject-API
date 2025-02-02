using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Repository;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentHubController : ControllerBase
    {

        StudentHubRepository repo = new StudentHubRepository();
//get all the students data//
        [HttpGet("GetStudents")]
        public List<studentHubModel> GetStudents()
        {
            List<studentHubModel> students = repo.GetAllStudents();
            return students;
        }
//getall//
        [HttpGet]
        public studentHubModel GetStudentById(int id)
        {
            studentHubModel student = repo.GetStudentById(id);
            return student;
        }



        [HttpGet("{id}")]
        public studentHubModel GetStudentById(int id)
        {
            studentHubModel student = repo.GetStudentById(id);
            return student;
        }


        [HttpGet("{id}")]
        public studentHubModel GetStudentById(int id)
        {
            studentHubModel student = repo.GetStudentById(id);
            return student;
        }



        //updating//
        [HttpPost]
        public int AddStudent(studentHubModel student)
        {
            int count = repo.insertstudent(student);
            return count;
        }

        [HttpPut]
        public int UpdateStudent(studentHubModel student)
        {
            int count = repo.UpdateStudent(student);
            return count;
        }

        [HttpDelete]
        public int DeleteStudent(int id)
        {
            int count = repo.DeleteStudent(id);
            return count;
        }
    }
}





