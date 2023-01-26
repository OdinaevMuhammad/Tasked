using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Wrapper;
using System.Net;

namespace Infrastructure.Service;
public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ProductService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper=mapper;
    }
     public async Task<Response<List<ProductDto>>> GetProduct()
    {
        try
        {
            var result = await _context.Products.ToListAsync();
            var mapped = _mapper.Map<List<ProductDto>>(result);
            return new Response<List<ProductDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<ProductDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
     public async Task<Response<AddProductDto>> AddProduct(AddProductDto product)
    {
        try
        {
            var mapped = _mapper.Map<Product>(product);
            _context.Products.Add(mapped);
            await _context.SaveChangesAsync();
            product.Id = mapped.Id;
            return new Response<AddProductDto>(product);
        }
        catch (Exception ex)
        {

            return new Response<AddProductDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto Product)
    {
        try
        {
              var find = await _context.Products.FindAsync(Product.Id);
        {
            find.Id = Product.Id;
           find. ProductName = Product.ProductName;
            find.Supplied = Product.Supplied;
            find.TotalAmount = Product.TotalAmount;
           find. OrderDate=Product.OrderDate;
            await _context.SaveChangesAsync();
            return new Response<AddProductDto>(Product);
        }
        }
        catch (Exception ex)
        {
         return new Response<AddProductDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});    
        }
      
    }
   public async Task<Response<ProductDto>> GetProductID(int id)
    {
        try
        {
            var result = await _context.Products.FindAsync(id);
            var mapped = _mapper.Map<ProductDto>(result);
            return new Response<ProductDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<ProductDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        }

    }
   public async Task<Response<string>> DeleteProduct(int id)
    {
        try
        {
            var find = await _context.Products.FindAsync(id);
            _context.Products.Remove(find);
            _context.SaveChangesAsync();
            return new Response<string>("Sucessfully");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        }


    }
    
}