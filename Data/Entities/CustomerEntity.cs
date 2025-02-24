﻿using Microsoft.EntityFrameworkCore;

namespace Data.Entities;


[Index(nameof(Email), IsUnique = true)]
public class ConditionEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? ContactPerson { get; set; } 

    public ICollection<ProjectEntity> Projects { get; set; } = [];

}

