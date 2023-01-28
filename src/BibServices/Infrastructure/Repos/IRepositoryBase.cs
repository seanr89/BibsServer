using System.Linq.Expressions;
using Infrastructure.Contexts;

namespace Infrastructure.Repos;

//https://code-maze.com/net-core-web-development-part4/
/// <summary>
/// Potential work to detail the planned operations for any repository layer!
/// /// </summary>
public interface IRepositoryBase<T>
{
    /// <summary>
    /// Generic/Simple get all process
    /// Not Advised to be used for all elements
    /// </summary>
    /// <returns></returns>
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    IQueryable<T> FindAllNotTracked();
    IQueryable<T> FindByConditionNotTracked(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

    /// <summary>
    /// Supports the assignment/setup of the app context to use!
    /// </summary>
    /// <param name="context"></param>
    void SetContext(AppDbContext context);

    /// <summary>
    /// Drives the Save process for create,update,delete process
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> Save(CancellationToken cancellationToken);
}
