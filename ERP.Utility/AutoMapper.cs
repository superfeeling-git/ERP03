using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utility
{
    public static class AutoMapper
    {
        public static T MapTo<T>(this object source)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(m => m.CreateMap(source.GetType(), typeof(T)));
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<T>(source);
        }

        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> objList)
        {
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<TSource, TDestination>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<TSource>, List<TDestination>>(objList);
        }
    }
}
