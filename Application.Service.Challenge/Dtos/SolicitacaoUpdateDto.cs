using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Challenge.Dtos
{
    public class SolicitacaoUpdateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Solicitante { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Prioridade { get; set; } = string.Empty;
        public string? Descricao { get; set; }

    }
}
