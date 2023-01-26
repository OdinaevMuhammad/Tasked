using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<Response<List<CustomerDto>>> GetCustomer()
    {
        return await _customerService.GetCustomer();
    }

    [HttpGet("GetBYID")]
    public async Task<Response<CustomerDto>> GetById(int id)
    {
        return await _customerService.GetCustomerID(id);
    }

    [HttpPost]
    public async Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto customer)
    {

        return await _customerService.AddCustomer(customer);
    }
    [HttpPut]
    public async Task<Response<AddCustomerDto>> UpdateCutomer(AddCustomerDto customer)
    {
        {
            if (ModelState.IsValid)
            {
                return await _customerService.UpdateCustomer(customer);
            }
            else
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return new Response<AddCustomerDto>(System.Net.HttpStatusCode.NotFound, errors);
            }

        }
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteCustomer(int id)
    {
        return await _customerService.DeleteCustomer(id);
    }
}