using System.Collections.Generic;
using System.Linq;

namespace API.Helper
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestiny> CopyList<TSource, TDestiny>(IEnumerable<TSource> src)
        {
            var ret = new List<TDestiny>();
            if (src == null)
            {
                return ret;
            }

            ret.AddRange(src.Select(origin => (TDestiny)AutoMapper.Mapper.Map(origin, typeof(TSource), typeof(TDestiny))));
            return ret;
        }

        public static TDestiny Map<TSource, TDestiny>(TSource origin)
        {
            return AutoMapper.Mapper.Map<TDestiny>(origin);
        }
    }
}
