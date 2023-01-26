namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Order{
    public int Id{get;set;}
         [ Required,MaxLength(100)]
    public string OrderNumber{get;set;}
    public int CustomerId{get;set;}
    public Customer Customer{get;set;}
         [Required, MaxLength(100)]
    public  DateTime OrderDate{get;set;}
         [Required, MaxLength(100)]
    public decimal TotalAmount{get;set;}
    public List<OrderItem>OrderItems{get;set;}
}
