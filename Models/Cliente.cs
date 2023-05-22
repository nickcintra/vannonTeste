using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vannon_teste.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Usuario Usuario { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;   
            Cpf = cpf;
        }

        public Cliente(int id, string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }


    }
}