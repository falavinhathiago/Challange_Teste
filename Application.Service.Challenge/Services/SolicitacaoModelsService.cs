using Application.Service.Challenge.Dtos;
using Application.Service.Challenge.Interfaces;
using AutoMapper;
using Domain.Challenge.Entitys;
using Domain.Challenge.Interface;

namespace Application.Service.Challenge.Services
{
    public class SolicitacaoModelsService : ISolicitacaoModelsService
    {
        private readonly  ISolictacaoModelsReposirory _repository;
        private readonly IMapper _mapper;
        public SolicitacaoModelsService(ISolictacaoModelsReposirory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SolicitacaoModels> CriarAsync(SolicitacaoCreateDto dto)
        {
            var solicitacao = new SolicitacaoModels(dto.Titulo, dto.Descricao, dto.Solicitante, dto.Prioridade);
            await _repository.AddAsync(solicitacao);
            return solicitacao;
        }

        public async Task<SolicitacaoModels> ObterPorIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<List<SolicitacaoModels>> ListarAsync(string? status, string? prioridade, string? search, int page, int pageSize) =>
            await _repository.GetAllAsync(status, prioridade, search, page, pageSize);

        public async Task<SolicitacaoModels> AtualizarAsync(int id, SolicitacaoUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Dados de atualização não informados.");

            var solicitacao = await _repository.GetByIdAsync(id);
            if (solicitacao == null)
                return null;

            // Validações básicas
            if (string.IsNullOrWhiteSpace(dto.Titulo))
                throw new InvalidOperationException("O título é obrigatório.");
            if (string.IsNullOrWhiteSpace(dto.Solicitante))
                throw new InvalidOperationException("O solicitante é obrigatório.");
            if (string.IsNullOrWhiteSpace(dto.Status))
                throw new InvalidOperationException("O status é obrigatório.");
            if (string.IsNullOrWhiteSpace(dto.Prioridade))
                throw new InvalidOperationException("A prioridade é obrigatória.");

            // Mapeia
            _mapper.Map(dto, solicitacao);
           
            await _repository.UpdateAsync(solicitacao);
            return solicitacao;

        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var solicitacao = await _repository.GetByIdAsync(id);
            if (solicitacao == null) return false;

            if (solicitacao.Status != "Aberta")
                throw new InvalidOperationException("Apenas solicitações abertas podem ser excluídas.");

            await _repository.DeleteAsync(solicitacao);
            return true;
        }


       

    }
}
