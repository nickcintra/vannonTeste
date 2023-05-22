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
    public class ClienteService
    {
        private readonly ClienteRepository clienteRepository;
        private readonly UsuarioService usuarioService;

        public ClienteService(vannonDBContext context)
        {
            clienteRepository = new ClienteRepository(context);
        }

        public IQueryable GetClientes()
        {
            return clienteRepository.GetClientes();
        }

        public Cliente PegarClienteId(int id)
        {
            return clienteRepository.PegarClienteId(id);
        }

        public bool CriarCliente(ClienteRequest clienteRequest)
        {
            try
            {
                var cliente = clienteRepository.criarCliente(clienteRequest);
                if (cliente != null)
                {
                    var usuario = new Usuario(clienteRequest.Email, clienteRequest.Senha, cliente.Id);
                    usuarioService.CriarUsuario(usuario);
                }
                return true;

                
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AtualizarCliente(int id, Cliente ClienteAtualizado)
        {

            try
            {
                clienteRepository.AtualizarCliente(id, ClienteAtualizado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarCliente(int id)
        {

            try
            {
                clienteRepository.DeletarCliente(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}