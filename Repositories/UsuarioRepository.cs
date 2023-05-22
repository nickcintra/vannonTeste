using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Requests;

namespace vannon_teste.Repositories
{
    public class UsuarioRepository
    {
        private readonly vannonDBContext _context;

        public UsuarioRepository(vannonDBContext context)
        {
            _context = context;
        }


        public Usuario PegarUsuarioId(int id)
        {
            return _context.Usuarios.FirstOrDefault(Usuario => Usuario.Id == id);
        }

        public IQueryable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.AsQueryable();
        }

        public void CriarUsuario(Usuario usuario)
        {
            var Usuario = new Usuario(usuario.Email, usuario.Senha, usuario.ClienteId);
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
        }
      

        public void AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            var Usuario = _context.Usuarios.FirstOrDefault(cli => cli.Id == id);

            if (Usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            Usuario.Email = usuarioAtualizado.Email;
            Usuario.Senha = usuarioAtualizado.Senha;
            
            _context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            var Usuario = _context.Usuarios.Find(id);

            if (Usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _context.Usuarios.Remove(Usuario);
            _context.SaveChanges();
        }
    }
}