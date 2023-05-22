using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vannon_teste.Models
{
    public class Filme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string titulo { get; set; }
        public string genero { get; set; }
        public string descricao { get; set;}

        public Filme()
        {
            
        }

        public Filme(string titulo, string genero, string descricao)
        {
            this.titulo = titulo;
            this.genero = genero;
            this.descricao = descricao;
        }

        public Filme(int id, string titulo, string genero, string descricao)
        {
            this.id = id;
            this.titulo = titulo;
            this.genero = genero;
            this.descricao = descricao;
        }

    }
}