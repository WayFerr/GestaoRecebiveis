using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Response
{
    public class LimiteEmpresaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal LimiteAntecipacao { get; set; }
    }
}
