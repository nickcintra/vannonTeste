using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Requests;

namespace vannon_teste.Repositories
{
    public class ClienteRepository
    {
        private readonly vannonDBContext _context;

        public ClienteRepository(vannonDBContext context)
        {
            _context = context;
        }


        public Cliente PegarClienteId(int id)
        {
            return _context.Clientes.FirstOrDefault(Cliente => Cliente.Id == id);
        }

        public IQueryable<Cliente> GetClientes()
        {
            return _context.Clientes.AsQueryable();
        }

        public Cliente criarCliente(ClienteRequest clienteRequest)
        {
            var cliente = new Cliente(clienteRequest.Nome, clienteRequest.Cpf);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }
      

        public void AtualizarCliente(int id, Cliente ClienteAtualizado)
        {
            var Cliente = _context.Clientes.FirstOrDefault(cli => cli.Id == id);

            if (Cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            Cliente.Nome = ClienteAtualizado.Nome;
            Cliente.Cpf = ClienteAtualizado.Cpf;
            
            _context.SaveChanges();
        }

        public void DeletarCliente(int id)
        {
            var Cliente = _context.Clientes.Find(id);

            if (Cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            _context.Clientes.Remove(Cliente);
            _context.SaveChanges();
        }
    }
}