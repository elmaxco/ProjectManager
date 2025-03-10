﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class DepartmentRepository(DataContext context) : BaseRepository<DepartmentEntity>(context), IDepartmentRepository
{
}
