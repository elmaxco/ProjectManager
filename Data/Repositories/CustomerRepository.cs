using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<ConditionEntity>(context), ICustomerRepository
{
    public override async Task<ConditionEntity?> GetAsync(Expression<Func<ConditionEntity, bool>> expression)
    {
        var entity = await _db
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);

        return entity;
    }
}
