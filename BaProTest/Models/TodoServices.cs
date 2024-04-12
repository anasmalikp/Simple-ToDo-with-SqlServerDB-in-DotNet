using BaProTest.Models.DTO;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BaProTest.Models
{
    public class TodoServices : ITodoServices
    {
        private readonly IConfiguration _connectionstring;
        public TodoServices(IConfiguration connectionstring)
        {

            _connectionstring = connectionstring;

        }
        public async Task<IEnumerable<TodoModel>> getall()
        {
            using var connection = new SqlConnection(_connectionstring.GetConnectionString("DefaultConnection"));
            var todos = await alltodos(connection);
            return todos;
        }

        private static async Task<IEnumerable<TodoModel>> alltodos(SqlConnection connection)
        {
            return await connection.QueryAsync<TodoModel>("select * from todo_table");
        }

        public async Task<IEnumerable<TodoModel>> addtodo(Class x)
        {
            using var connection = new SqlConnection(_connectionstring.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into todo_table(Title) Values(@Title)", x);
            return await alltodos(connection);
        }

        public async Task<IEnumerable<TodoModel>> deletetodo(int Id)
        {
            using var connection = new SqlConnection(_connectionstring.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from todo_table where Id = @ID", new { ID = Id });
            return await alltodos(connection);
        }

        public async Task edittotdo(TodoModel todo)
        {
            using var connection = new SqlConnection(_connectionstring.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update todo_table set Title = @Title where Id = @Id", todo);
        }

        public async Task<IEnumerable<TodoModel>> getone(int Id)
        {
            using var connection = new SqlConnection(_connectionstring.GetConnectionString("DefaultConnection"));
            var single = await connection.QueryAsync<TodoModel>("select * from todo_table where Id = @Id", new { Id });
            return single;
        }

    }
}
