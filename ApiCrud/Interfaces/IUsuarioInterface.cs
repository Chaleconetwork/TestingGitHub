using ApiCrud.Models;

namespace ApiCrud.Interfaces
{
    public interface IUsuarioInterface
    {
        Task<List<Usuario>>? GetAll();

        Task<Usuario>? GetById(int id);
        
        Task<int>? InsertUser(Usuario usuario);
    }
}
