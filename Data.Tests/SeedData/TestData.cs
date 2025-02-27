using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests.SeedData;

public class TestData
{
    
    public static readonly CustomerEntity[] CustomerEntities =
    [
        new CustomerEntity {Id = 1, CustomerName = "Nackademin AB", Email = "Nackademin@domain.com" },
        new CustomerEntity {Id = 2, CustomerName = "Saab AB", Email = "Saab@domain.com" },
        new CustomerEntity {Id = 3, CustomerName = "Ericsson AB", Email = "Ericsson@domain.com"  }
    ];

    public static readonly EmployeeEntity[] EmployeeEntities =
    [
       new EmployeeEntity {Id = 1, Employee = "Carl"  ,FirstName = "Carl", LastName = "Svensson", Email = "carl@domain.com" },
       new EmployeeEntity {Id = 2, Employee = "Martin" ,FirstName = "Martin", LastName = "Gustavson", Email = "martin@domain.com" },
       new EmployeeEntity {Id = 3, Employee = "Nils" ,FirstName = "Nils", LastName = "Dahlson", Email = "nils@domain.com" }
    ];

    public static readonly ProjectEntity[] ProjectEntities =
    [
        new ProjectEntity {ProjectName = "Databasteknik", Description = "Databaser", StartDate = new DateTime(2025, 02, 03), EndDate = new DateTime(2025, 02, 28), StatusId = 2, CustomerId = 1, ProjectManagerId = 1, ProjectTypeId = 1 }
    ];

    public static readonly ProjectTypeEntity[] ProjectTypeEntities =
    [
            new ProjectTypeEntity {Id = 1, TypeName = "Webbprojekt", Price = 100, PricingUnit = "Tim" },
            new ProjectTypeEntity {Id = 2, TypeName = "Mjukvaruprojekt", Price = 100, PricingUnit = "Tim" },
            new ProjectTypeEntity {Id = 3, TypeName = "Övrigt", Price = 100, PricingUnit = "Tim" }
    ];

    public static readonly StatusEntity[] StatusEntities =
    [
        new StatusEntity {Id = 1, StatusName = "Ej påbörjad" },
        new StatusEntity {Id = 2, StatusName = "Pågår" }, 
        new StatusEntity {Id = 3, StatusName = "Avslutad" }        
    ];

}
