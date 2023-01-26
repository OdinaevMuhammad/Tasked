using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase
{
    private readonly SupplierService _SupplierService;

    public SupplierController(SupplierService SupplierService)
    {
        _SupplierService = SupplierService;
    }

    [HttpGet]
    public async Task<Response<List<SupplierDto>>> GetSupplier()
    {
        return await _SupplierService.GetSupplier();
    }

    [HttpGet("GetBYID")]
    public async Task<Response<SupplierDto>> GetById(int id)
    {
        return await _SupplierService.GetSupplierID(id);
    }

    [HttpPost]
    public async Task<Response<AddSupplierDto>> AddSupplier(AddSupplierDto sup)
    {

        return await _SupplierService.AddSuplier(sup);
    }
    [HttpPut]
    public async Task<Response<AddSupplierDto>> UpdateSupplier(AddSupplierDto sup)
    {
        return await _SupplierService.UpdateSupplier(sup);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteSupplier(int id)
    {
        return await _SupplierService.DeleteSupplier(id);
    }
}
