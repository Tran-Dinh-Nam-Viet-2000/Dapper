using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Test_Dapper.Dapper;
using Test_Dapper.Dtos;
using Test_Dapper.Entites;
using Test_Dapper.Repositories.Interface;

namespace Test_Dapper.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperConfig _dapper;
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(DapperConfig dapper, ApplicationDbContext dbContext)
        {
            _dapper = dapper;
            _dbContext = dbContext;
        }

        public void Create(Student student)
        {
            var query = "EXEC Sp_CreateStudent @p1, @p2 ";
            var parameters = new DynamicParameters();
            parameters.Add("p1", student.studentName, DbType.String);
            parameters.Add("p2", student.Age, DbType.Int16);
            using (var connection = _dapper.CreateConnection())
            {
                  connection.Execute(query, parameters);
                //var query = _dbContext.Students.FromSqlRaw("EXEC Sp_CreateStudent " + "@p1, " + "@p2 ",
                //     studentDto.studentName,
                //     studentDto.Age
                //    ).AsEnumerable();
                //if (query == null)
                //{
                //    throw new Exception("The record already exists");
                //}
                //await _dbContext.AddAsync(query);
                //_dbContext.SaveChanges();
                //connection.Close();
                //return (Student)query;
            }
        }

        public void Delete(int id)
        {
            var query = "EXEC Sp_DeleteStudent ";
            using(var connection = _dapper.CreateConnection())
            {
                connection.Execute(query + id);
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var query = "SELECT * FROM Students";

            using (var connection = _dapper.CreateConnection())
            {
                var companies = await connection.QueryAsync<Student>(query);
                return companies.ToList();
            }
        }

        public async Task<IEnumerable<Student>> SP_GetAll()
        {
            var query = "EXEC Sp_GetAllStudent";

            using (var connection = _dapper.CreateConnection())
            {
                var getAll = await connection.QueryAsync<Student>(query);
                return getAll.ToList();
            }
        }

        public Student SP_GetById(int id)
        {
            var query = "EXEC Sp_GetById ";
            //var pamater = new DynamicParameters();
            //pamater.Add("@p1", id, DbType.Int64);
            using (var connection = _dapper.CreateConnection())
            {
                //Cách 1
                var result =  connection.QueryFirstOrDefault<Student>(query + id);

                //Cách 2
                //var result = _dbContext.Students.FromSqlRaw(query + id).AsEnumerable().FirstOrDefault();
                //if (result == null)
                //{
                //    return null;
                //}
                return result;
            }
        }

        public void Update(StudentDto studentDto, int id)
        {
            var query = "EXEC Sp_UpdateStudent ";
            using (var connection = _dapper.CreateConnection())
            {
                var result = connection.Execute(query + id + "," + "N'" + studentDto.StudentName + "'" + "," + studentDto.Age);
                connection.Close();
            }
        }
    }
}
