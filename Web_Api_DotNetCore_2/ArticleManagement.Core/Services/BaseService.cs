using ArticleManagement.Core.Interfaces;

namespace ArticleManagement.Core.Services
{
    public class BaseService
    {
        protected readonly IMapperService Mapper;

        public BaseService(IMapperService mapper)
        {
            Mapper = mapper;
        }
    }
}
