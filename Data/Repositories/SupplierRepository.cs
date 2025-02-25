using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class SupplierRepository(DataContext context) : BaseRepository<SupplierEntity>(context), ISupplierRepository
{
}
