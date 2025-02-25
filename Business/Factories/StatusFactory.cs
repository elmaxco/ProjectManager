using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public static class StatusFactory
{
    public static Status? Map(StatusEntity entity) => entity == null ? null : new Status
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
}

