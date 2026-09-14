using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Challenge.Dtos
{
    public class SolicitacaoCreateDto
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Solicitante { get; set; } = null!;
        public string Prioridade { get; set; } = "Baixa";
    }
}
