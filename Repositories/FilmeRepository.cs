using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Requests;

namespace vannon_teste.Repositories
{
    public class FilmeRepository
    {
        private readonly vannonDBContext _context;

        public FilmeRepository(vannonDBContext context)
        {
            _context = context;
        }
        public IQueryable<Filme> PegarFilmes()
        {
            return _context.Filmes.AsQueryable();
        }

        public Filme PegarFilmeId(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.id == id);
        }

        public void CriarFilme(FilmeRequest filmeRequest)
        {
            var filme = new Filme(filmeRequest.titulo, filmeRequest.genero, filmeRequest.descricao);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }

        public void AtualizarFilme(int id, Filme filmeAtualizado)
        {
            var filme = _context.Filmes.FirstOrDefault(film => film.id == id);

            if (filme == null)
            {
                throw new Exception("Filme não encontrado");
            }

            filme.titulo = filmeAtualizado.titulo;
            filme.genero = filmeAtualizado.genero;
            filme.descricao = filmeAtualizado.descricao;
            _context.SaveChanges();
        }

        public void DeletarFilme(int id)
        {
            var filme = _context.Filmes.Find(id);

            if (filme == null)
            {
                throw new Exception("Filme não encontrado");
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();
        }

    }
}