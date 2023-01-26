using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;

namespace Infrastructure.Service;
public class AddressService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public AddressService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<AddressDto>>> GetAddress()
    {
        try
        {
            var result = await _context.Addresses.ToListAsync();
            var mapped = _mapper.Map<List<AddressDto>>(result);
            return new Response<List<AddressDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<AddressDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
    public async Task<Response<AddAddressDto>> AddAddress(AddAddressDto address)
    {
        try
        {

            var mapped = _mapper.Map<Address>(address);
            _context.Addresses.Add(mapped);
            await _context.SaveChangesAsync();
            address.Id = mapped.Id;
            return new Response<AddAddressDto>(address);

        }
        catch (Exception ex)
        {

            return new Response<AddAddressDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
    public async Task<Response<AddAddressDto>> UpdateAddress(AddAddressDto address)
    {
        {
            try
            {
                var find = await _context.Addresses.Where(x => x.Id == address.Id).AsNoTracking().FirstOrDefaultAsync();
                if(find == null) return new Response<AddAddressDto>(HttpStatusCode.BadRequest , new List<string>(){"Not found"});
                var mapped =  _mapper.Map<Address>(address);
                 _context.Addresses.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddAddressDto>(address);
            }
            catch (Exception ex)
            {
                return new Response<AddAddressDto>(HttpStatusCode.NotFound, new List<string>() { ex.Message });
            }

        }
    }
    public async Task<Response<AddressDto>> GetAdressId(int id)
    {
        try
        {
            var result = await _context.Addresses.FindAsync(id);
            var mapped = _mapper.Map<AddressDto>(result);
            return new Response<AddressDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<AddressDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        }

    }
    public async Task<Response<string>> DeleteAddress(int id)
    {
        try
        {
            var find = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("Address Deleteed");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        }


    }
}