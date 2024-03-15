using Dapper;
using ProyectoEstetica.Models;
using System.Data.SqlClient;

namespace ProyectoEstetica.Rules
{
    public class PublicacionRule

    {

        private readonly IConfiguration _configuration;
        public PublicacionRule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Publicacion GetOnePost()
        {
            var connectionString = _configuration.GetConnectionString("NuevaBase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open();
                var post = connection.Query<Publicacion>("Select top 1 * from publicacion");
                return post.First();
            }
        }
        public Publicacion GetPostById(int id)
        {
            var connectionString = _configuration.GetConnectionString("NuevaBase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open();
                var query = "Select  * from publicacion where id = @id";
                var post = connection.QueryFirstOrDefault<Publicacion>(query, new {id});
                return post;
            }
        }
        public List<Publicacion> GetOnePostHome()
        {
            var connectionString = _configuration.GetConnectionString("NuevaBase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open();
                var post = connection.Query<Publicacion>("select top 4 * from publicacion order by Creacion asc");
                return post.ToList();
            }
        }
    }
}
