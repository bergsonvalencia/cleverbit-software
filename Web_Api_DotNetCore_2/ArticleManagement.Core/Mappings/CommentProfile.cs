using AutoMapper;
using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using Dto = CleverbitSoftware.WebApi.Integration.Dtos;
using Entity = ArticleManagement.Infrastructure.Data.Entities;
using Domain = ArticleManagement.Core.Domains;

namespace ArticleManagement.Core.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Entity.Comment, CreateCommentRequest>().ReverseMap();
            CreateMap<Entity.Comment, Dto.Comment>().ReverseMap();
            CreateMap<Entity.Comment, Domain.Comment>().ReverseMap();
            CreateMap<Dto.Comment, Domain.Comment>().ReverseMap();
        }
    }
}