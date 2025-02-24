using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectTypeRepository(DataContext context) : BaseRepository<ProjectTypeEntity>(context), IProjectTypeRepository
{

}
