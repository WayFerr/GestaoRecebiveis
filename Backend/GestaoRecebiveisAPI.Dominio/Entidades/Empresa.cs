using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Entidades
{
    public class Empresa
    {
        public Empresa()
        {
            NotasFiscais = new Collection<NotaFiscal>();
        }

        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal FaturamentoMensal { get; set; }
        public int RamoAtividadeId { get; set; }
        public RamoDeAtividade RamoDeAtividade { get; set; }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}
