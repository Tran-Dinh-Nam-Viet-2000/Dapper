using Test_Dapper.Dtos;
using Test_Dapper.Entites;

namespace Test_Dapper.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> SP_GetAll();
        Student SP_GetById(int id);
        void Create(Student student);
        void Update(StudentDto studentDto, int id);
        void Delete(int id);
    }
}
