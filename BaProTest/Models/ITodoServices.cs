using BaProTest.Models.DTO;
using Microsoft.Data.SqlClient;

namespace BaProTest.Models
{
    public interface ITodoServices
    {
        public Task<IEnumerable<TodoModel>> getall();
        public Task<IEnumerable<TodoModel>> addtodo(Class x);
        public Task<IEnumerable<TodoModel>> deletetodo(int Id);
        public Task edittotdo(TodoModel todo);
        public Task<IEnumerable<TodoModel>> getone(int Id);
    }
}
