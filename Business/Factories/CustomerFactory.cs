using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static Customer? Map(CustomerEntity entity) => entity == null ? null : new Customer
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName

    };
}
