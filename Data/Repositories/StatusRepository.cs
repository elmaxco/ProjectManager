using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<ConditionEntity>(context), IStatusRepository
{ 

}
