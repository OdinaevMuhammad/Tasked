using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _ProductService;

    public ProductController(ProductService ProductService)
    {
        _ProductService = ProductService;
    }

    [HttpGet]
    public async Task<Response<List<ProductDto>>> GetProduct()
    {
        return await _ProductService.GetProduct();
    }

    [HttpGet("GetBYID")]
    public async Task<Response<ProductDto>> GetById(int id)
    {
        return await _ProductService.GetProductID(id);
    }

    [HttpPost]
    public async Task<Response<AddProductDto>> AddProduct(AddProductDto pro)
    {

        return await _ProductService.AddProduct(pro);
    }
    [HttpPut]
    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto pro)
    {
        {
            if (ModelState.IsValid)
            {
                return await _ProductService.AddProduct(pro);
            }
            else
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return new Response<AddProductDto>(System.Net.HttpStatusCode.NotFound, errors);
            }

        }
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(int id)
    {
        return await _ProductService.DeleteProduct(id);
    }
}