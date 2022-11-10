using ApiCrud.Data;
using ApiCrud.Interfaces;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ApiCrud.Repositories
{
    public class UsuarioRepository: IUsuarioInterface
    {
        public readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Usuario>>? GetAll()
        {
            var usuarios = await _context.Usuarios.OrderBy(i => i.Name).AsNoTracking().ToListAsync();

            return usuarios;
        }

        public async Task<Usuario>? GetById(int id)
        {
            var usuario = await _context.Usuarios.Where(i => i.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<int>? InsertUser(Usuario usuario)
        {

            //var Name = usuario.Name;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario.Id;
        }
    }
}