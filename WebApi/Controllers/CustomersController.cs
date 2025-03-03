using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var customer = await _customerService.CreateCustomerAsync(form);
        return customer == null ? BadRequest() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        var customer = await _customerService.GetAllCustomerAsync();
        return Ok(customer);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(CustomerUpdate form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _customerService.UpdateCustomerAsync(form);
        return updated ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProject(int id)
    {
        var project = await _customerService.GetCustomerAsync(id);

        if (project == null)
            return NotFound();

        var deleted = await _customerService.DeleteCustomerAsync(customer);
        return deleted ? Ok() : BadRequest();
    }
}

