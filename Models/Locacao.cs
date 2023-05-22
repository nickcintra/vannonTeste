using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vannon_teste.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}