using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
namespace Infrastructure.MapperProfiles;
 public class InfrastructureProfile:Profile
 {
    public InfrastructureProfile()
    {
        CreateMap<Customer,CustomerDto>().ReverseMap();
        CreateMap<AddCustomerDto,Customer>();
        CreateMap<Address,AddressDto>().ReverseMap();
        CreateMap<AddAddressDto,Address>().ReverseMap();
        CreateMap<Order,OrderDto>().ReverseMap();
        CreateMap<AddOrderDto,Order>().ReverseMap();
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<AddProductDto,Product>();
        CreateMap<Supplier,SupplierDto>().ReverseMap();
        CreateMap<AddSupplierDto,Supplier>().ReverseMap();

    }
 }