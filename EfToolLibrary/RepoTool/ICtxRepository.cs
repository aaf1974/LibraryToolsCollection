using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EfToolLibrary.RepoTool
{
    public interface ICtxRepository
    {
        IQueryable<TEntity> QueryableSelect<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        IQueryable<TEntity> QueryableSelect<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
    }

    public abstract class CtxRepositoryBase //: ICtxRepository
    {
    }
}
