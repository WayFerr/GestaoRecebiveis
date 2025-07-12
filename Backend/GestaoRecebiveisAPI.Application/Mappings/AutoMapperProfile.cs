using AutoMapper;
using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.DTOs.Response;
using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //EmpresaRequest > Empresa
            CreateMap<EmpresaRequest, Empresa>()
                .ForMember(dest => dest.RamoDeAtividade, opt => opt.Ignore())
                .ForMember(dest => dest.RamoAtividadeId, opt => opt.Ignore());

            //Empresa > EmpresaRequest
            CreateMap<Empresa, EmpresaRequest>()
                .ForMember(dest => dest.DsRamoAtividade, opt => opt.MapFrom(src => src.RamoDeAtividade.Descricao));

            //Empresa > EmpresaResponse
            CreateMap<Empresa, EmpresaResponse>()
                .ForMember(dest => dest.DsRamoAtividade, opt => opt.MapFrom(src => src.RamoDeAtividade.Descricao));

            //EmpresaResponse > Empresa
            CreateMap<EmpresaResponse, Empresa>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
