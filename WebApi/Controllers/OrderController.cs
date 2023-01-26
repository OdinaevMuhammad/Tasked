using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _OrderService;

    public OrderController(OrderService OrderService)
    {
        _OrderService = OrderService;
    }

    [HttpGet]
    public async Task<Response<List<OrderDto>>> GetOrder()
    {
        return await _OrderService.GetOrder();
    }

    [HttpGet("GetBYID")]
    public async Task<Response<OrderDto>> GetById(int id)
    {
        return await _OrderService.GetOrderID(id);
    }

    [HttpPost]
    public async Task<Response<AddOrderDto>> AddOrder(AddOrderDto order)
    {

        return await _OrderService.AddOrder(order);
    }
    [HttpPut]
    public async Task<Response<AddOrderDto>> UpdateOrder(AddOrderDto order)
    {
        {
            if (ModelState.IsValid)
            {
                return await _OrderService.AddOrder(order);
            }
            else
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return new Response<AddOrderDto>(System.Net.HttpStatusCode.NotFound, errors);
            }

        }
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteOrder(int id)
    {
        return await _OrderService.DeleteOrdr(id);
    }
}