using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Entidades
{
    public class RamoDeAtividade
    {
        public RamoDeAtividade()
        {
            Empresas = new Collection<Empresa>();
        }

        public int RamoAtividadeId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
    }
}
