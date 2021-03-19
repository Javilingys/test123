using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        // для .Where() запросов
        Expression<Func<T, bool>> Criteria { get; }
        // для списка .Include() 
        List<Expression<Func<T, object>>> Includes { get; }
    }
}