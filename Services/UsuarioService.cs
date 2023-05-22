using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Repositories;
using vannon_teste.Requests;

namespace vannon_teste.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository UsuarioRepository;

        public UsuarioService(vannonDBContext context)
        {
            UsuarioRepository = new UsuarioRepository(context);
        }

        public IQueryable GetUsuarios()
        {
            return UsuarioRepository.GetUsuarios();
        }

        public Usuario PegarUsuarioId(int id)
        {
            return UsuarioRepository.PegarUsuarioId(id);
        }

        public bool CriarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioRepository.CriarUsuario(usuario);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AtualizarUsuario(int id, Usuario UsuarioAtualizado)
        {

            try
            {
                UsuarioRepository.AtualizarUsuario(id, UsuarioAtualizado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarUsuario(int id)
        {

            try
            {
                UsuarioRepository.DeletarUsuario(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}