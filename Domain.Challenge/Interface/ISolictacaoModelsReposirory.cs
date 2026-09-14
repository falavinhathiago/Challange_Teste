using Domain.Challenge.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Challenge.Interface
{
    public interface ISolictacaoModelsReposirory
    {
        
        Task<SolicitacaoModels> GetByIdAsync(int id);
        Task<List<SolicitacaoModels>> GetAllAsync(string status, string prioridade, string search, int page, int pageSize);
        Task AddAsync(SolicitacaoModels solicitacao);
        Task UpdateAsync(SolicitacaoModels solicitacao);
        Task DeleteAsync(SolicitacaoModels solicitacao);
    }

}
