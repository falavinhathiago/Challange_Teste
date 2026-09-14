using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Challenge.Entitys
{
    public class SolicitacaoModels
    {

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Solicitante { get; private set; }
        public string Prioridade { get; private set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; private set; }

        public SolicitacaoModels(string titulo, string descricao, string solicitante, string prioridade)
        {
            Titulo = titulo;
            Descricao = descricao;
            Solicitante = solicitante;
            Prioridade = prioridade;
            Status = "Aberta";
            DataCriacao = DateTime.UtcNow;
        }

        public void Concluir()
        {
            if (Status == "Concluída")
                throw new InvalidOperationException("Já está concluída.");
            Status = "Concluída";
            DataConclusao = DateTime.UtcNow;
        }

        public void AtualizarStatus(string novoStatus)
        {
            if (Status == "Concluída" && novoStatus == "Aberta")
                throw new InvalidOperationException("Não pode reabrir concluída.");
            Status = novoStatus;
        }

        public void AtualizarPrioridade(string prioridade) => Prioridade = prioridade;
    }
}
