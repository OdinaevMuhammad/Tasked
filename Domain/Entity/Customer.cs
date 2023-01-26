namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Customer
{
    public int  Id{get;set;}
     [Required, MaxLength(100)]
    public string FirstName{get;set;}

     [Required, MaxLength(100)]
    public string LastName{get;set;}

         [Required, MaxLength(100)]
    public string PhoneNumber{get;set;}
         [Required, MaxLength(100)]
    public string Email{get;set;}
    public List<Order>Orders{get;set;}
}