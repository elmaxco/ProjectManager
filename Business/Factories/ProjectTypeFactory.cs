using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectTypeFactory
{
    public static ProjectType? Map(ProjectTypeEntity entity) => entity == null ? null : new ProjectType
    {
        Id = entity.Id,
        TypeName = entity.TypeName,
        Price = entity.Price,
        PricingUnit = entity.PricingUnit
    };
}

