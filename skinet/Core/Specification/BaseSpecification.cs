using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specification
{
  public class BaseSpecification<T> : ISpecification<T>
  {
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
      Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } =
        new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpresion)
    {
      Includes.Add(includeExpresion);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpresion)
    {
      OrderBy = orderByExpresion;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpresion)
    {
      OrderByDescending = orderByDescendingExpresion;
    }
  }
}