using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Repositories;
using vannon_teste.Requests;

namespace vannon_teste.Services
{
    public class FilmeService
    {

        private readonly FilmeRepository filmeRepository;

        public FilmeService(vannonDBContext context)
        {
            filmeRepository = new FilmeRepository(context);
        }

        public IQueryable PegarFilmes()
        {
            return filmeRepository.PegarFilmes();
        }

        public Filme PegarFilmeId(int id)
        {
            return filmeRepository.PegarFilmeId(id);
        }

        public bool CriarFilme(FilmeRequest filmeRequest)
        {
            try
            {
                filmeRepository.CriarFilme(filmeRequest);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AtualizarFilme(int id, Filme filmeAtualizado)
        {

            try
            {
                filmeRepository.AtualizarFilme(id, filmeAtualizado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarFilme(int id)
        {

            try
            {
                filmeRepository.DeletarFilme(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}