using Microsoft.AspNetCore.Mvc;
using PruebaSebastianBenavides.Helpers;
using PruebaSebastianBenavides.Models;

namespace PruebaSebastianBenavides.Controllers
{
    /// <summary>
    /// Api Controller for manage all operation about a student
    /// </summary>
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Controller for get information student by id
        /// </summary>
        /// <param name="id">Identification student</param>
        /// <returns></returns>
        [Route("getStudentById")]
        [HttpGet]
        public IActionResult GetStudentByIdentification(string id)
        {
            try
            {
                var student = new StudentManager().GetStudentById(id);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(500,"Ocurrio un error en el proceso, intente de nuevo");
            }
        }

        /// <summary>
        /// Controller for create a new student
        /// </summary>
        /// <param name="student">Model of student</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public IActionResult CreateStudent(Student student)
        {
            try
            {
                new StudentManager().CreateStudent(ref student);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error en el proceso, intente de nuevo");
            }
        }

        /// <summary>
        /// Controller for update data student by id
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateStudent(Student student)
        {
            try
            {
                new StudentManager().UpdateStudent(student);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error en el proceso, intente de nuevo");
            }
        }

        /// <summary>
        /// Controller for delete student by id 
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteStudent(string id)
        {
            try
            {
                new StudentManager().DeleteStudent(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error en el proceso, intente de nuevo");
            }
        }
    }
}
