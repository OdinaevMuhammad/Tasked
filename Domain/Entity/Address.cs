namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Address{
    public int Id{get;set;}
    [Required,MaxLength(100)]
    public string Address1{get;set;}
    public string Address2{get;set;}
    public int CityId{get;set;}
    public int PostalCode{get;set;}
    public int  CustomerId{get;set;}
    public Customer Customer{get;set;}
    }

