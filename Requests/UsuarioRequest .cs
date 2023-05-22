using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vannon_teste.Requests
{
    public class UsuarioRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int ClienteId { get; set; }

    }
}