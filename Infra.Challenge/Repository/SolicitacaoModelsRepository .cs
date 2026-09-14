using Domain.Challenge.Entitys;
using Domain.Challenge.Interface;
using Infra.Challenge.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Challenge.Repository
{
    public class SolicitacaoModelsRepository : ISolictacaoModelsReposirory
    {
        private readonly AppDbContext _context;

        public SolicitacaoModelsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SolicitacaoModels?> GetByIdAsync(int id) =>
            await _context.Solicitacoes.FindAsync(id);

        public async Task<List<SolicitacaoModels>> GetAllAsync(string? status, string? prioridade, string? search, int page, int pageSize)
        {
            var query = _context.Solicitacoes.AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(s => s.Status == status);

            if (!string.IsNullOrEmpty(prioridade))
                query = query.Where(s => s.Prioridade == prioridade);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(s => s.Titulo.Contains(search) || s.Solicitante.Contains(search));

            return await query
                .OrderByDescending(s => s.DataCriacao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(SolicitacaoModels solicitacao)
        {
            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SolicitacaoModels solicitacao)
        {
            _context.Solicitacoes.Update(solicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SolicitacaoModels solicitacao)
        {
            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();
        }
       
    }
}
