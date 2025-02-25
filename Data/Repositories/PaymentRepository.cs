using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class PaymentRepository(DataContext context) : BaseRepository<PaymentEntity>(context), IPaymentRepository
{
}
