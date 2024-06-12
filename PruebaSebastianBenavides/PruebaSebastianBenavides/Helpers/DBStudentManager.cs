using Dapper;
using MySql.Data.MySqlClient;
using PruebaSebastianBenavides.Models;

namespace PruebaSebastianBenavides.Helpers
{
    public class DBStudentManager
    {
        public string Connection { get; set; }


        /// <summary>
        /// Get od appsetting.json configuration for connection to database
        /// </summary>
        public DBStudentManager()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();
            Connection = configuration["connectionDb:main"].ToString();
        }

        public Student GetStudentById(string id)
        {
            try
            {
                var query = $"SELECT * FROM student WHERE id={id}";
                var result = new Student();
                using (var connection = new MySqlConnection(Connection))
                {
                    result = connection.Query<Student>(query).FirstOrDefault();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CreateStudent(Student student)
        {
            try
            {
                var query = $@"INSERT INTO student VALUES (null,'{student.title}','{student.firstName}',
'{student.lastName}','{student.picture}','{student.gender}','{student.email}','{student.dateOfBirth.ToString("yyyy-MM-dd 00:00:00")}',
'{student.phone}',now(),now())";

                var query2 = "SELECT id FROM student ORDER BY id DESC LIMIT 1";

                using (var connection = new MySqlConnection(Connection))
                {
                    var rows = connection.Execute(query);
                    return connection.Query<int>(query2).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                var query = $@"UPDATE student SET title='{student.title}', SET firstName=='{student.firstName}',
lastName=='{student.lastName}', picture=='{student.picture}',dateOfBith='{student.dateOfBirth.ToString("yyyy-MM-dd 00:00:00")}',
phone='{student.phone}', updateDate=now() WHERE id={student.id}";

                using (var connection = new MySqlConnection(Connection))
                {
                    var rows = connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStudent(string id)
        {
            try
            {
                var query = $"DELETE student WHERE id='{id}'";
                using (var connection = new MySqlConnection(query))
                {
                    var rows = connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
