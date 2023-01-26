using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Wrapper;
using System.Net;
namespace Infrastructure.Service;
public class CustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CustomerService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper=mapper;
    }
       public async Task<Response<List<CustomerDto>>> GetCustomer()
    {
        try
        {
            var result = await _context.Customers.ToListAsync();
            var mapped = _mapper.Map<List<CustomerDto>>(result);
            return new Response<List<CustomerDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<CustomerDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
   public async Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto customer)
    {
        try
        {
            var mapped = _mapper.Map<Customer>(customer);
            _context.Customers.Add(mapped);
            await _context.SaveChangesAsync();
            mapped.Id = mapped.Id;
            return new Response<AddCustomerDto>(customer);
        }
        catch (Exception ex)
        {

            return new Response<AddCustomerDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
    public async Task<Response<AddCustomerDto>> UpdateCustomer(AddCustomerDto customer)
    {
        try
        {
             var find = await _context.Customers.FindAsync(customer.Id);
        {
            find.FirstName = customer.FirstName;
            find.LastName = customer.LastName;
            find.PhoneNumber = customer.PhoneNumber;
            find.Email = customer.Email;
            await _context.SaveChangesAsync();
            return new Response<AddCustomerDto>(customer);
        }
        }
        catch (Exception ex)
        {
           return new Response<AddCustomerDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
       
    }
    public async Task<Response<CustomerDto>> GetCustomerID(int id)
    {
        try
        {
            var result = await _context.Customers.FindAsync(id);
          var mapped = _mapper.Map<CustomerDto>(result);
            return new Response<CustomerDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<CustomerDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }

    }
      public async Task<Response<string>>DeleteCustomer(int id)
    {
        try
        {
                 var find = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
        }
        catch (Exception ex)
        {
           return new Response<string>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
   

    }
}