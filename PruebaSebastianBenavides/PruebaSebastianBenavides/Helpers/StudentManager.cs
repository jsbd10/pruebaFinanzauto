using PruebaSebastianBenavides.Models;

namespace PruebaSebastianBenavides.Helpers
{
    public class StudentManager
    {
        public DBStudentManager DBStudentManager { get; set; }
        public StudentManager()
        {
            DBStudentManager = new DBStudentManager();
        }

        public Student GetStudentById(string id)
        {
            try
            {
                return DBStudentManager.GetStudentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error obteniendo la informacion del usuario: {ex.Message}");
            }
        }

        public void CreateStudent(ref Student student)
        {
            try
            {
                student.id = DBStudentManager.CreateStudent(student).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error creando el estudiante: {ex.Message}");
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                DBStudentManager.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error actualizando el estudiante: {ex.Message}");
            }
        }

        public void DeleteStudent(string id)
        {
            try
            {
                DBStudentManager.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
