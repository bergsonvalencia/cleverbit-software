using AutoMapper;
using Dto = CleverbitSoftware.WebApi.Integration.Dtos;
using Entity = ArticleManagement.Infrastructure.Data.Entities;
using Domain = ArticleManagement.Core.Domains;

namespace ArticleManagement.Core.Mappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Entity.Article, Dto.Article>().ReverseMap();
            CreateMap<Entity.Article, Domain.Article>().ReverseMap();
            CreateMap<Dto.Article, Domain.Article>().ReverseMap();
        }
    }
}