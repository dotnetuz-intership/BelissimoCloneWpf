using BelissimoCloneWPF.Domain.Configurations;

namespace BelissimoCloneWPF.Service.Extentions
{
    public static class CollectionExtentions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            return @params.PageIndex > 0 && @params.PageSize >= 0
                ? source.Take(((@params.PageIndex - 1) * @params.PageSize)..@params.PageSize)
                : source;
        }
    }
}
