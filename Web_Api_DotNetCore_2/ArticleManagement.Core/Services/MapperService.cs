using AutoMapper;
using ArticleManagement.Core.Interfaces;

namespace ArticleManagement.Core.Services
{
    public sealed class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}