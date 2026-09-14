using Application.Service.Challenge.Dtos;
using Domain.Challenge.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Challenge.Interfaces
{
    public interface ISolicitacaoModelsService
    {
            Task<SolicitacaoModels> CriarAsync(SolicitacaoCreateDto dto);
            Task<SolicitacaoModels> ObterPorIdAsync(int id);
            Task<List<SolicitacaoModels>> ListarAsync(string? status, string? prioridade, string? search, int page, int pageSize);
            Task<SolicitacaoModels?> AtualizarAsync(int id, SolicitacaoUpdateDto dto);
            Task<bool> ExcluirAsync(int id);
        
    }
}
