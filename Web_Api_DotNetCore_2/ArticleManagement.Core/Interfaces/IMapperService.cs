namespace ArticleManagement.Core.Interfaces
{
    public interface IMapperService
    {
        TDestination Map<TDestination>(object source);
    }
}
