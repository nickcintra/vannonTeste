using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vannon_teste.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public Usuario(string email, string senha, int clienteId) : this(email, senha)
        {
            ClienteId = clienteId;
        }

        public Usuario(int id, string email, string senha, int clienteId, Cliente cliente)
        {
            Id = id;
            Email = email;
            Senha = senha;
            ClienteId = clienteId;
            Cliente = cliente;
        }
    }
}