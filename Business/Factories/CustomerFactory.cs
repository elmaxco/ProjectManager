using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    
    
        public static CustomerRegistrationForm Map() => new();

        public static Customer? Map(CustomerEntity entity)
        {
            var customer = new Customer()
            {
                Id = entity.Id,
                CustomerName = entity.CustomerName,
                Email = entity.Email,
                Projects = []
            };

            if (entity.Projects != null)
            {
                var projects = new List<Project>();
                foreach (var project in entity.Projects)
                    projects.Add(new Project
                    {
                        Id = project.Id,
                        Description = project.Description,
                    });

                customer.Projects = projects;
            }

            return customer;
        }

        public static CustomerEntity Create(CustomerRegistrationForm form) => new()
        {
            CustomerName = form.CustomerName,
            Email = form.Email
        };


        public static CustomerUpdate Create(Customer customer) => new()
        {
            Id = customer.Id,
            CustomerName = customer.CustomerName,
            Email = customer.Email
        };

        public static CustomerEntity Create(CustomerUpdate form) => new()
        {
            Id = form.Id,
            CustomerName = form.CustomerName,
            Email = form.Email
        };
}

